using DrinkAndRate.Data;
using DrinkAndRate.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkAndRate.Web.User
{
    public partial class Articles : BaseUserPage
    {
        private IDrinkAndRateData data;

        public Articles()
        {
            var dbContext = new DrinkAndRateDbContext();
            data = new DrinkAndRateData(dbContext); 
        }

        public void ButtonAllArticlesRedirect_Click(object sender, EventArgs e)
        {
            this.ButtonAllArticlesRedirect.Visible = false;
            this.ButtonMyArticleRedirect.Visible = true;
            LoadData();
        }

        public void ButtonMyArticleRedirect_Click(object sender, EventArgs e)
        {
            this.ButtonAllArticlesRedirect.Visible = true;
            this.ButtonMyArticleRedirect.Visible = false;
            LoadMyData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {       
                LoadData();
            }
        }

        private void LoadData()
        {
            var allArticles = data.Articles.All()
                .Take(9)
                .Select(x => new ArticleViewModel
                {
                    ArticleId = x.ID,
                    Beer = x.Beer.Name,
                    ArticleTitle = x.Title,
                    Creator = x.Creator.UserName,
                    Content = x.Content
                })
                .ToList();

            this.ListViewArticles.DataSource = allArticles;
            this.ListViewArticles.DataBind();
        }

        private void LoadMyData()
        {
            var loggedInUserName = HttpContext.Current.User.Identity.Name;
            var currentUserId = this.data.Users.All().FirstOrDefault(x => x.UserName == loggedInUserName).Id;

            var myArticles = data.Articles.All()
                .Where(x => x.CreatorID == currentUserId)
                .Take(9)
                .Select(x => new ArticleViewModel
                {
                    ArticleId = x.ID,
                    Beer = x.Beer.Name,
                    ArticleTitle = x.Title,
                    Creator = x.Creator.UserName,
                    Content = x.Content
                })
                .ToList();

            this.ListViewArticles.DataSource = myArticles;
            this.ListViewArticles.DataBind();
        }
    }
}