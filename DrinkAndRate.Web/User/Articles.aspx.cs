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
    public partial class Articles : Page
    {
        private IDrinkAndRateData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dbContext = new DrinkAndRateDbContext();
                data = new DrinkAndRateData(dbContext);

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

    }
}