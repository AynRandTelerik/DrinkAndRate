﻿using DrinkAndRate.Data;
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

        //// The id parameter should match the DataKeyNames value set on the control
        //// or be decorated with a value provider attribute, e.g. [QueryString]int id
        //public IQueryable<BeerDetailsViewModel> DetailsViewBeer_GetItem([QueryString("id")] int? id)
        //{
        //    var currentBeer = data.Beers.All().Where(b => b.ID == id)   //TODO
        //            .Select(x => new BeerDetailsViewModel
        //            {
        //                Name = x.Name,
        //                AlchoholPercentage = x.AlchoholPercentage,
        //                BeerRatings = x.BeerRatings.Count,
        //                BrandName = x.Brand.Name,
        //                BrandCountry = x.Brand.Country.Name,
        //                BrandEstablished = x.Brand.Established,
        //                CategoryName = x.Category.Name,
        //                CreatedOn = x.CreatedOn,
        //                CreatorName = x.Creator.UserName,
        //                Description = x.Description,
        //                ID = x.ID,
        //                Image = x.Images.FirstOrDefault(),
        //                Comments = x.Comments,
        //                Articles = x.Articles,
        //                Images = x.Images

        //            });

        //    return currentBeer;
        //}

        private void LoadData()
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
            this.ImageContainer.BackImageUrl = beerData.Images.FirstOrDefault().Path; //beerData.Images.FirstOrDefault().Path == string.Empty ? beerData.Images.FirstOrDefault().Path : "/Images/default.png";
            this.Alco.InnerText = "Alco: " + beerData.AlchoholPercentage.ToString() + "%";
            this.CategoryName.InnerText = beerData.Category.Name;
            this.BeerRatings.InnerText = beerData.BeerRatings.Count + " reviews";
            this.Description.InnerText = beerData.Description;
            this.BrandName.InnerText = beerData.Brand.Name;
            this.BrandCountry.InnerText = beerData.Brand.Country.Name;
            this.BrandEstablished.InnerText = beerData.Brand.Established.ToShortDateString();
            this.Creator.InnerText = "Creator: " + beerData.Creator.UserName;
            this.CreatedOn.InnerText = beerData.CreatedOn.ToString();
            
            //Edit
            this.BeerNameEditText.Text = beerData.Name;
            this.AlcoEditText.Text = beerData.AlchoholPercentage.ToString();
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
            beerData.AlchoholPercentage = int.Parse(this.AlcoEditText.Text);
            beerData.Description = this.DescriptionEditText.Text;
            beerData.CategoryID = int.Parse(this.CategoriesEditDropDown.SelectedValue);
            beerData.BrandID = int.Parse(this.BrandNameEditDropDown.SelectedValue);

            this.data.Beers.Update(beerData);
            this.data.SaveChanges();

            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            this.EditDataContainer.Visible = false;
        }

        protected void RemoveBeerButton_Click(object sender, EventArgs e)
        {
            var currentBeer = this.data.Beers.Find(this.beerId);
            this.data.Beers.Delete(currentBeer);
            this.data.SaveChanges();

            this.Response.Redirect("~/User/Beers");
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<DrinkAndRate.Web.Models.CommentsViewModel> ListViewComments_GetData()
        {
            var currentBeerComments = data.Comments.All().Where(c => c.BeerID == beerId)
                .Select(x => new CommentsViewModel
                    {
                        Content = x.Content,
                        CreatedOn = x.CreatedOn,
                        CreatorName = x.Creator.UserName,
                    });

            return currentBeerComments;
        }

        protected void ButtonAddNewComment_Click(object sender, EventArgs e)
        {
            this.PanelAddNewCommentData.Visible = true;
        }

        protected void backButtonComments_Click(object sender, EventArgs e)
        {
            this.PanelAddNewCommentData.Visible = false;
        }
    }
}