using DrinkAndRate.Data;
using DrinkAndRate.Models;
using DrinkAndRate.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkAndRate.Web.User
{
    public partial class BeerDetails : System.Web.UI.Page
    {
        private IDrinkAndRateData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dbContext = new DrinkAndRateDbContext();
                data = new DrinkAndRateData(dbContext);

                SetPageTitle(1);    //TODO
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public IQueryable<BeerDetailsViewModel> DetailsViewBeer_GetItem([QueryString("id")] int? id)
        {
            var currentBeer = data.Beers.All().Where(b => b.ID == id)   //TODO
                    .Select(x => new BeerDetailsViewModel
                    {
                        Name = x.Name,
                        AlchoholPercentage = x.AlchoholPercentage,
                        BeerRatings = x.BeerRatings.Count,
                        BrandName = x.Brand.Name,
                        BrandCountry = x.Brand.Country.Name,
                        BrandEstablished = x.Brand.Established,
                        CategoryName = x.Category.Name,
                        CreatedOn = x.CreatedOn,
                        CreatorName = x.Creator.UserName,
                        Description = x.Description,
                        ID = x.ID,
                        Image = x.Images.FirstOrDefault(),
                        Comments = x.Comments,
                        Articles = x.Articles,
                        Images = x.Images

                    });

            return currentBeer;
        }

        private void SetPageTitle(int ID)
        {
            var currentBeer = data.Beers.Find(ID);
            Page.Title = currentBeer.Name;
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        //public IEnumerable<CommentsViewModel> FormViewComments_GetAll(int? id)
        //{
        //    var comments = data.Comments.All().Where(c => c.BeerID == id)    //TODO
        //        .Select(x => new CommentsViewModel
        //        {
        //            Content = x.Content,
        //            CreatedOn = x.CreatedOn,
        //            CreatorName = x.Creator.UserName,
        //        }).ToList();

        //    //this.ListViewComments.DataSource = comments;
        //    //this.ListViewComments.DataBind();

        //    return comments;
        //}
    }
}