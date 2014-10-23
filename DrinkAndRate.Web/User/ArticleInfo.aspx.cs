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
    public partial class ArticleInfo : BaseUserPage
    {
        private IDrinkAndRateData data;
        public Article article;
        public ArticleViewModel articleModel;

        public ArticleInfo()
        {
            var dbContext = new DrinkAndRateDbContext();
            this.data = new DrinkAndRateData(dbContext);
        }

        public void SaveButton_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                this.PanelView.Visible = true;
                this.PanelEdit.Visible = false;

                article.Title = this.TextBoxArticleTitle.Text;
                article.Content = this.TextBoxArticleContent.Text;

                this.data.Articles.Update(article);
                this.data.SaveChanges();

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                throw new InvalidOperationException("Error occure while saving the element!");
            }
        }

        public void EditButton_Command(object sender, CommandEventArgs e)
        {
            this.PanelView.Visible = false;
            this.PanelEdit.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["articleID"];
            int articleId;

            if (String.IsNullOrEmpty(rawId))
            {
                this.Response.Redirect("~/User/Articles");
            }

            if (int.TryParse(rawId, out articleId))
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

                var loggedUser = HttpContext.Current.User.Identity.Name;

                if (loggedUser == article.Creator.UserName)
                {
                    this.EditButton.Visible = true;
                }

                if (!IsPostBack)
                {
                    Page.DataBind();                    
                }
            }
        }
    }
}