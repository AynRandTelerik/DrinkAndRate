using DrinkAndRate.Data;
using DrinkAndRate.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace DrinkAndRate.Web.Account
{
	public partial class Register : Page
	{
		private IDrinkAndRateData data;

		protected void Page_Load(object sender, EventArgs e)
		{
			var dbContext = new DrinkAndRateDbContext();
			this.data = new DrinkAndRateData(dbContext);

			if (!IsPostBack)
			{
				LoadData();
			}
		}

		protected void CreateUser_Click(object sender, EventArgs e)
		{
			var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
			var user = new AppUser()
			{
				UserName = Email.Text,
				Email = Email.Text,
				FirstName = FirstName.Text,
				LastName = LastName.Text,
				CountryID = int.Parse(Countries.SelectedValue)
			};

			string filePathAndName = string.Empty;

			try
			{
				filePathAndName = FileUploadControl.Upload();
			}
			catch (InvalidOperationException ex)
			{
				this.DivLabelErrorMessage.Visible = true;
				this.LabelErrorMessage.Text = ex.Message;

				return;
			}

			Image image = null;
			if (string.IsNullOrEmpty(filePathAndName))
			{
				image = this.data.Images.Find(1);
			}
			else
			{
				image = new Image { Path = filePathAndName };
			}

			user.Image = image;

			IdentityResult result = manager.Create(user, Password.Text);
			if (result.Succeeded)
			{
				manager.AddToRole(user.Id, "user");
				IdentityHelper.SignIn(manager, user, isPersistent: false);
				IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
			}
			else
			{
				ErrorMessage.Text = result.Errors.FirstOrDefault();
			}
		}

		private void LoadData()
		{
			var allCountries = this.data.Countries.All().ToList();
			this.Countries.DataSource = allCountries;
			this.Countries.DataBind();
		}
	}
}