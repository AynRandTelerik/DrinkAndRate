using DrinkAndRate.Data;
using DrinkAndRate.Models;
using DrinkAndRate.Web.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkAndRate.Web.User
{
    public partial class BeerDetails : System.Web.UI.Page
    {
        private IDrinkAndRateData data;
        private int beerId;
        private string currentUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            var queryParameterId = Request.QueryString["Id"];

            if (string.IsNullOrEmpty(queryParameterId))
            {
                Response.Redirect("~/User/Beers");
            }

            this.beerId = int.Parse(queryParameterId);

            var dbContext = new DrinkAndRateDbContext();
            data = new DrinkAndRateData(dbContext);

            var loggedInUserName = HttpContext.Current.User.Identity.Name;
            if (string.IsNullOrEmpty(loggedInUserName))
            {
                Response.Redirect("~/");
            }
            else
            {
                this.currentUserId = this.data.Users.All().FirstOrDefault(x => x.UserName == loggedInUserName).Id;

                if (!IsPostBack)
                {
                    LoadData();
                }
            }
        }

        private void LoadData()
        {
			LoadBeerData();
			LoadListViewComments();
        }

		private void LoadBeerData()
		{
			var beerData = data.Beers.All().FirstOrDefault(b => b.ID == beerId);
			if (beerData == null)
			{
				Response.Redirect("~/User/Beers");
			}

			if (beerData.CreatorID == this.currentUserId)
			{
				this.EditBeerContainer.Visible = true;
				this.RemoveBeerContainer.Visible = true;
			}

			this.BeerName.InnerText = beerData.Name;
			this.ImageContainer.BackImageUrl = beerData.Images.Count > 0 ? beerData.Images.FirstOrDefault().Path : "../Images/default.png";
			this.Alco.InnerText = string.Format("Alco: {0} %", beerData.AlchoholPercentage != null ? beerData.AlchoholPercentage.Value.ToString("0.0") : "N/A");
			this.CategoryName.InnerText = beerData.Category.Name;
			this.Description.InnerText = beerData.Description;
			this.BrandName.InnerText = beerData.Brand.Name;
			this.BrandCountry.InnerText = beerData.Brand.Country.Name;
			this.BrandEstablished.InnerText = beerData.Brand.Established.ToShortDateString();
			this.Creator.InnerText = "Creator: " + beerData.Creator.UserName;
			this.CreatedOn.InnerText = beerData.CreatedOn.ToString();

			int allRatings = 0;
			var currentBeerRating = 0;
			foreach (var beerRating in beerData.BeerRatings)
			{
				allRatings += beerRating.Rating;
			}

			if (beerData.BeerRatings.Count > 0)
			{
				currentBeerRating = allRatings / beerData.BeerRatings.Count;
			}

			this.BeerRatings.InnerText = currentBeerRating + " / " + beerData.BeerRatings.Count + " reviews";

			//Edit
			this.BeerNameEditText.Text = beerData.Name;

            this.AlcoEditText.Text = beerData.AlchoholPercentage != null ? beerData.AlchoholPercentage.Value.ToString("0.0") : "0";
			this.DescriptionEditText.Text = beerData.Description;

			var allCategories = this.data.Categories.All().ToList();
			this.CategoriesEditDropDown.DataSource = allCategories;
			this.CategoriesEditDropDown.DataBind();

			var allBrands = this.data.Brands.All().ToList();
			this.BrandNameEditDropDown.DataSource = allBrands;
			this.BrandNameEditDropDown.DataBind();
		}

        private void SetPageTitle(int ID)
        {
            var currentBeer = data.Beers.Find(ID);
            Page.Title = currentBeer.Name;
        }

        protected void EditBeerButton_Click(object sender, EventArgs e)
        {
            this.EditDataContainer.Visible = true;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var beerData = data.Beers.All().FirstOrDefault(b => b.ID == beerId);

            beerData.Name = this.BeerNameEditText.Text;
            beerData.AlchoholPercentage = double.Parse(this.AlcoEditText.Text);
            beerData.Description = this.DescriptionEditText.Text;
            beerData.CategoryID = int.Parse(this.CategoriesEditDropDown.SelectedValue);
            beerData.BrandID = int.Parse(this.BrandNameEditDropDown.SelectedValue);

            this.data.Beers.Update(beerData);
            this.data.SaveChanges();

			LoadBeerData();
			backButton_Click(null, null);
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            this.EditDataContainer.Visible = false;
        }

        protected void RemoveBeerButton_Click(object sender, EventArgs e)
        {
            var currentBeer = this.data.Beers.Find(this.beerId);

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

            this.data.Beers.Delete(currentBeer);
            this.data.SaveChanges();

            this.Response.Redirect("~/User/Beers");
        }

        public void LoadListViewComments()
        {
            this.ListViewComments.DataSource = data.Comments.All().Where(c => c.BeerID == beerId)
                .Select(x => new CommentsViewModel
                    {
                        Content = x.Content,
                        CreatedOn = x.CreatedOn,
                        CreatorName = x.Creator.UserName,
                    }).OrderByDescending(item => item.CreatedOn).ToArray();
			this.ListViewComments.DataBind();
        }

        protected void ButtonAddNewComment_Click(object sender, EventArgs e)
        {
            this.PanelAddNewCommentData.Visible = true;
        }

        protected void backButtonComments_Click(object sender, EventArgs e)
        {
            this.PanelAddNewCommentData.Visible = false;
        }

        protected void ButtonAddCommentData_Click(object sender, EventArgs e)
        {
            var newComment = new Comment
            {
                Content = this.TextBoxAddComment.Text,
                CreatedOn = DateTime.Now,
                CreatorID = currentUserId,
                BeerID = beerId
            };

            this.data.Comments.Add(newComment);
            this.data.SaveChanges();

			LoadListViewComments();
			this.TextBoxAddComment.Text = string.Empty;
			backButtonComments_Click(null, null);
        }

        protected void Star_Select(object sender, EventArgs e)
        {
            var selectedRadioButtonId = ((RadioButton)sender).ID;
            var selectedValue = selectedRadioButtonId.Split('_')[1];

            var rating = int.Parse(selectedValue);

            var alreadyRatedBeer = this.data.BeerRatings.All()
                .FirstOrDefault(rate => rate.BeerID == this.beerId && rate.UserID == this.currentUserId);

            if (alreadyRatedBeer != null)
            {
                alreadyRatedBeer.Rating = rating;
                alreadyRatedBeer.RatedOn = DateTime.Now;
                this.data.BeerRatings.Update(alreadyRatedBeer);
            }
            else
            {
                var newRating = new BeerRating
                {
                    BeerID = beerId,
                    UserID = currentUserId,
                    RatedOn = DateTime.Now,
                    Rating = rating
                };

                this.data.BeerRatings.Add(newRating);
            }

            this.data.SaveChanges();

			LoadBeerData();
        }
    }
}