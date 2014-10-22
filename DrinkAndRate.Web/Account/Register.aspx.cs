using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DrinkAndRate.Models;
using DrinkAndRate.Data;

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

            if (string.IsNullOrEmpty(filePathAndName))
            {
                filePathAndName = "~/Images/default.png";
            }

            user.Image = new Image
            {
                Path = filePathAndName
            };

            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

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