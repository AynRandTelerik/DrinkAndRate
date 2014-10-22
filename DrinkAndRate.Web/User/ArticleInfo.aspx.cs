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
    public partial class ArticleInfo : Page
    {
        private IDrinkAndRateData data;
        public Article article;
        public ArticleViewModel articleModel;
        public void SaveButton_Command(object sender, CommandEventArgs e)
        {
            this.PanelView.Visible = true;
            this.PanelEdit.Visible = false;

            article.Title = this.TextBoxArticleTitle.Text;
            article.Content = this.TextBoxArticleContent.Text;

            this.data.Articles.Update(article);
            this.data.SaveChanges();

            Response.Redirect(Request.RawUrl);
        }

        public void EditButton_Command(object sender, CommandEventArgs e)
        {
            this.PanelView.Visible = false;
            this.PanelEdit.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new DrinkAndRateDbContext();
            this.data = new DrinkAndRateData(dbContext);

            string rawId = Request.QueryString["articleID"];
            int articleId;

            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out articleId))
            {
                article = this.data.Articles.All()
                    .SingleOrDefault(a => a.ID == articleId);

                articleModel = new ArticleViewModel
                {
                    ArticleId = article.ID,
                    ArticleTitle = article.Title,
                    Beer = article.Beer.Name,
                    Content = article.Content,
                    Creator = article.Creator.UserName
                };

                if (!IsPostBack)
                {
                    Page.DataBind();                    
                }
            }
        }
    }
}