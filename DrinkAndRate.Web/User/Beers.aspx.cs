namespace DrinkAndRate.Web.User
{
    using DrinkAndRate.Data;
    using DrinkAndRate.Web.Models;
    using DrinkAndRate.Models;
    using System;
    using System.Linq;
    using System.Web.UI;

    public partial class Beers : Page
    {
        //TODO Ninject
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
            var allBeers = data.Beers.All()
                .Select(x => new BeerViewModel
                {
                    Name = x.Name,
                    AlchoholPercentage = x.AlchoholPercentage,
                    BeerRatings = x.BeerRatings.Count,
                    BrandName = x.Brand.Name,
                    CategoryName = x.Category.Name,
                    CreatedOn = x.CreatedOn,
                    CreatorName = x.Creator.UserName,
                    Description = x.Description,
                    ID = x.ID,
                    Image = x.Images.FirstOrDefault()
                })
                .ToList();

            this.UserControlBeerGrid.BeerList.DataSource = allBeers;
            this.UserControlBeerGrid.BeerList.DataBind();
        }
    }
}