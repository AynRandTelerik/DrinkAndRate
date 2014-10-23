namespace DrinkAndRate.Web
{
	using DrinkAndRate.Data;
	using DrinkAndRate.Models;
	using DrinkAndRate.Web.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.UI;

	public partial class _Default : Page
	{
		private IDrinkAndRateData data;

		private IEnumerable<Beer> AllBeers
		{
			get
			{
				return this.Cache[SiteMaster.BEER_CACHE_KEY] as IEnumerable<Beer>;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				var dbContext = new DrinkAndRateDbContext();
				data = new DrinkAndRateData(dbContext);

				LoadData();
			}

			Master.FindControl("panelSiteMapPath").Visible = false;
		}

		private void LoadData()
		{
			var allBeers = !this.User.Identity.IsAuthenticated ? this.AllBeers : data.Beers.All();

			this.UserControlBeerGrid.BeerList.DataSource = allBeers
				.OrderByDescending(beer => beer.CreatedOn)
				.Take(9)
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
				.ToList(); ;
			this.UserControlBeerGrid.BeerList.DataBind();
		}
	}
}