namespace DrinkAndRate.Web.Admin
{
	using DrinkAndRate.Data;
	using DrinkAndRate.Models;
	using DrinkAndRate.Web.Models;
	using DrinkAndRate.Web.User;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.UI;

	public partial class BeersGrid : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void gridView_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var currentBeerId = int.Parse(e.Values["ID"].ToString());
            var currentBeer = this.data.Beers.Find(currentBeerId);

            if (currentBeer.Images.Any())
            {
                this.data.Images.Delete(currentBeer.Images.FirstOrDefault());
            }

            foreach (var comment in currentBeer.Comments.ToList())
            {
                this.data.Comments.Delete(comment);
            }

            foreach (var rating in currentBeer.BeerRatings.ToList())
            {
                this.data.BeerRatings.Delete(rating);
            }

            foreach (var article in currentBeer.Articles.ToList())
            {
                this.data.Articles.Delete(article);
            }

            this.data.SaveChanges();
        }
    }
}