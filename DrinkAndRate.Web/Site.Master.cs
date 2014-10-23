using DrinkAndRate.Data;
using System;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkAndRate.Web
{
	public partial class SiteMaster : MasterPage
	{
		public const string BEER_CACHE_KEY = "BeersCache";

		private const string AntiXsrfTokenKey = "__AntiXsrfToken";
		private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
		private string _antiXsrfTokenValue;
		private IDrinkAndRateData data;

		protected void Page_Init(object sender, EventArgs e)
		{
			// The code below helps to protect against XSRF attacks
			var requestCookie = Request.Cookies[AntiXsrfTokenKey];
			Guid requestCookieGuidValue;
			if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
			{
				// Use the Anti-XSRF token from the cookie
				_antiXsrfTokenValue = requestCookie.Value;
				Page.ViewStateUserKey = _antiXsrfTokenValue;
			}
			else
			{
				// Generate a new Anti-XSRF token and save to the cookie
				_antiXsrfTokenValue = Guid.NewGuid().ToString("N");
				Page.ViewStateUserKey = _antiXsrfTokenValue;

				var responseCookie = new HttpCookie(AntiXsrfTokenKey)
				{
					HttpOnly = true,
					Value = _antiXsrfTokenValue
				};
				if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
				{
					responseCookie.Secure = true;
				}
				Response.Cookies.Set(responseCookie);
			}

			Page.PreLoad += master_Page_PreLoad;
		}

		protected void master_Page_PreLoad(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// Set Anti-XSRF token
				ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
				ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
			}
			else
			{
				// Validate the Anti-XSRF token
				if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
					|| (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
				{
					throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
				}
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			var dbContext = new DrinkAndRateDbContext();
			data = new DrinkAndRateData(dbContext);

			if (Context.User.Identity.IsAuthenticated)
			{
				var user = data.Users.All()
					.Single(x => x.UserName == this.Context.User.Identity.Name);
				var adminRole = data.Roles.All()
					.Single(x => x.Name == "admin");

				if (user.Roles.Any(role => role.RoleId == adminRole.Id))
				{
					this.panelAdminMenu.Visible = true;
				}
			}

			CacheBeerInfo();
		}

		protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
		{
			Context.GetOwinContext().Authentication.SignOut();
		}

		private void CacheBeerInfo()
		{
			if (this.Cache[BEER_CACHE_KEY] == null)
			{
				var beersCollection = data.Beers.All().ToList();
				Cache.Insert(BEER_CACHE_KEY, beersCollection, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration, CacheItemPriority.Default, (k, v, r) => CacheBeerInfo());
			}
		}
	}
}