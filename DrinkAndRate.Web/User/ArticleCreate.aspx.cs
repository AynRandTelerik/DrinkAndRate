using DrinkAndRate.Data;
using DrinkAndRate.Models;
using DrinkAndRate.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkAndRate.Web.User
{
    public partial class ArticleCreate : BaseUserPage
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
        public void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var loggedInUserName = HttpContext.Current.User.Identity.Name;
                var currentUserId = this.data.Users.All().FirstOrDefault(x => x.UserName == loggedInUserName).Id;

                var newArticle = new Article
                {
                    BeerID = int.Parse(this.Beers.SelectedValue),
                    Title = this.ArticleTitle.Value,
                    Content = this.Content.Value,
                    CreatorID = currentUserId
                };

                this.data.Articles.Add(newArticle);
                this.data.SaveChanges();

                Response.Redirect("~/User/Articles");
            }
            else
            {
                throw new InvalidOperationException("Error occure while saving the element!");
            }
        }
        private void LoadData()
        {
            var allBeers = this.data.Beers.All().ToList();

            this.Beers.DataSource = allBeers;
            this.Beers.DataBind();
        }
    }
}