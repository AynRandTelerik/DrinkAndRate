namespace DrinkAndRate.Web.User
{
    using DrinkAndRate.Data;
    using DrinkAndRate.Models;
    using DrinkAndRate.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;

    public partial class Beers : BaseUserPage
    {
        private const string SHOW_MESSAGE = "Show filters";
        private const string HIDE_MESSAGE = "Hide filters";

        private HashSet<OrderModel> orderByCollection;
        private HashSet<OrderModel> orderTypeCollection;


        private bool IsFilterOn
        {
            get
            {
                if (Session["IsFilterOn"] == null)
                {
                    return false;
                }

                return (bool)Session["IsFilterOn"];
            }
            set
            {
                Session["IsFilterOn"] = value;
            }
        }

        //TODO Ninject
        private IDrinkAndRateData data;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.orderByCollection = new HashSet<OrderModel>
            {
                new OrderModel{ID=1, Name="Asc"},
                new OrderModel{ID=2, Name="Desc"}
            };

            this.orderTypeCollection = new HashSet<OrderModel>
            {
                new OrderModel{ID=1, Name="Date added"},
                new OrderModel{ID=2, Name="Creator name"},
                new OrderModel{ID=3, Name="Rating"},
                new OrderModel{ID=4, Name="Comments count"},
                new OrderModel{ID=5, Name="Beer name"},
                new OrderModel{ID=6, Name="Brand name"},
                new OrderModel{ID=7, Name="Alcohol percentage"}
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new DrinkAndRateDbContext();
            data = new DrinkAndRateData(dbContext);

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            if (!IsFilterOn)
            {
                var allBeers = data.Beers.All();
                SetListViewData(allBeers);
            }
            else
            {
                GetFilteredBeers(null, null);
            }

            LoadFilterData();
        }

        private void LoadFilterData()
        {
            this.OrderType.DataSource = this.orderByCollection;
            this.OrderType.DataBind();

            this.OrderBy.DataSource = this.orderTypeCollection;
            this.OrderBy.DataBind();
        }

        protected void FilterButton_Click(object sender, EventArgs e)
        {
            this.FilterContainer.Visible = !this.FilterContainer.Visible;

            if (this.FilterButton.Text.IndexOf(SHOW_MESSAGE) != -1)
            {
                this.FilterButton.Text = HIDE_MESSAGE;
            }
            else
            {
                this.FilterButton.Text = SHOW_MESSAGE;
            }
        }

        protected void GetFilteredBeers(object sender, EventArgs e)
        {
            Session["IsFilterOn"] = true;

            if (!string.IsNullOrEmpty(this.OrderBy.SelectedValue))
            {
                Session["OrderBy"] = this.OrderBy.SelectedValue;
            }
            if (!string.IsNullOrEmpty(this.OrderType.SelectedValue))
            {
                Session["OrderType"] = this.OrderType.SelectedValue;
            }

            var orderBy = (string)Session["OrderBy"];
            var orderType = (string)Session["OrderType"];

            var allBeers = this.data.Beers.All();

            if (orderType == "1")
            {
                switch (orderBy)
                {
                    case "1":
                        allBeers = allBeers.OrderBy(beer => beer.CreatedOn);
                        break;
                    case "2":
                        allBeers = allBeers.OrderBy(beer => beer.Creator.UserName);
                        break;
                    case "3":
                        allBeers = allBeers.OrderBy(beer => beer.BeerRatings);
                        break;
                    case "4":
                        allBeers = allBeers.OrderBy(beer => beer.Comments.Count);
                        break;
                    case "5":
                        allBeers = allBeers.OrderBy(beer => beer.Name);
                        break;
                    case "6":
                        allBeers = allBeers.OrderBy(beer => beer.Brand.Name);
                        break;
                    case "7":
                        allBeers = allBeers.OrderBy(beer => beer.AlchoholPercentage);
                        break;
                    default:
                        throw new ArgumentException("Wrong order type");
                }
            }
            else
            {
                switch (orderBy)
                {
                    case "1":
                        allBeers = allBeers.OrderByDescending(beer => beer.CreatedOn);
                        break;
                    case "2":
                        allBeers = allBeers.OrderByDescending(beer => beer.Creator.UserName);
                        break;
                    case "3":
                        allBeers = allBeers.OrderByDescending(beer => beer.BeerRatings);
                        break;
                    case "4":
                        allBeers = allBeers.OrderByDescending(beer => beer.Comments.Count);
                        break;
                    case "5":
                        allBeers = allBeers.OrderByDescending(beer => beer.Name);
                        break;
                    case "6":
                        allBeers = allBeers.OrderByDescending(beer => beer.Brand.Name);
                        break;
                    case "7":
                        allBeers = allBeers.OrderByDescending(beer => beer.AlchoholPercentage);
                        break;
                    default:
                        throw new ArgumentException("Wrong order type");
                }
            }

            SetListViewData(allBeers);
        }

        protected void SearchTextbox_TextChanged(object sender, EventArgs e)
        {
            var searchTextValue = this.SearchTextbox.Text;

            var allBeers = this.data.Beers.All();

            if (!string.IsNullOrEmpty(searchTextValue))
            {
                allBeers = allBeers.Where(beer => beer.Name.IndexOf(searchTextValue) != -1);
            }

            SetListViewData(allBeers);
        }

        private IEnumerable<BeerViewModel> GetBeersData(IQueryable<Beer> queryableBeerData)
        {
            var beerData = queryableBeerData.Select(x => new BeerViewModel
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

            return beerData;
        }

        private void SetListViewData(IQueryable<Beer> queryableBeerData)
        {
            var listViewDataBeers = GetBeersData(queryableBeerData);

            this.UserControlBeerGrid.BeerList.DataSource = listViewDataBeers;
            this.UserControlBeerGrid.BeerList.DataBind();
        }
    }
}