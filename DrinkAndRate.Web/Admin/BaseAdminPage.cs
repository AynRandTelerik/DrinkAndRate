namespace DrinkAndRate.Web.User
{
	using DrinkAndRate.Data;
	using System.Data.Entity.Infrastructure;
	using System.Linq;
	using System.Web;
	using System.Web.UI;

	public abstract class BaseAdminPage : Page
	{
		protected IDrinkAndRateDbContext dbContext;
		protected IDrinkAndRateData data;

		public BaseAdminPage()
		{
			dbContext = new DrinkAndRateDbContext();
			data = new DrinkAndRateData(dbContext);

			bool isAuthenticatedAndAdmin = this.User.Identity.IsAuthenticated;

			if (isAuthenticatedAndAdmin)
			{
				var user = data.Users.All()
					.Single(x => x.UserName == this.Context.User.Identity.Name);
				var adminRole = data.Roles.All()
					.Single(x => x.Name == "admin");

				isAuthenticatedAndAdmin = user.Roles.Any(role => role.RoleId == adminRole.Id);
			}

			if (!isAuthenticatedAndAdmin)
			{
				HttpContext.Current.Response.Redirect("~/Default");
			}
		}

		protected void dataSource_ContextCreating(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceContextCreatingEventArgs e)
		{
			e.Context = (new DrinkAndRateDbContext() as IObjectContextAdapter).ObjectContext;
		}
	}
}