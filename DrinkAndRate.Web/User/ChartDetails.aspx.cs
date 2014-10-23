namespace DrinkAndRate.Web.User
{
    using DrinkAndRate.Data;
    using DrinkAndRate.Web.Models;
    using System;
    using System.Data;
    using System.Linq;
    using System.Web.UI.WebControls;

    public partial class ChartDetails : BaseUserPage
    {
        private IDrinkAndRateData data;
        private string beerType;

        protected void Page_Load(object sender, EventArgs e)
        {
            var queryParameterId = Request.QueryString["Type"];

            if (string.IsNullOrEmpty(queryParameterId))
            {
                Response.Redirect("~/User/Charts");
            }

            this.beerType = queryParameterId;

            var dbContext = new DrinkAndRateDbContext();
            data = new DrinkAndRateData(dbContext);

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            IQueryable<BeerChartViewModel> allBeers = null;

            if (this.beerType == "Top10")
            {
                allBeers = GetAllBeers()
                    .OrderByDescending(beer => beer.Rating)
                    .Take(10);

                this.ChartGridView.Columns[4].Visible = false;
                this.ChartHeaderInfo.InnerText = "The legendary top 10 rated beers ever!";
            }
            else if (this.beerType == "MostRated")
            {
                allBeers = GetAllBeers()
                    .OrderByDescending(beer => beer.CountRatings)
                    .Take(10);

                this.ChartGridView.Columns[3].Visible = false;
                this.ChartHeaderInfo.InnerText = "Most popular beers ever!";
            }

            this.ChartGridView.DataSource = allBeers.ToList();
            this.ChartGridView.DataBind();
        }

        protected void ChartGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.ChartGridView, "Select$" + e.Row.RowIndex);


                switch (e.Row.RowIndex)
                {
                    case 0:
                        e.Row.CssClass = "success ultra-huge-font";
                        break;
                    case 1:
                        e.Row.CssClass = "info huge-font";
                        break;
                    case 2:
                        e.Row.CssClass = "warning big-font";
                        break;
                }
            }
        }

        protected void ChartGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.ChartGridView.Rows)
            {
                if (row.RowIndex == this.ChartGridView.SelectedIndex)
                {
                    var currentBeerId = row.Cells[0].Text;

                    this.Response.Redirect("~/User/BeerDetails?Id=" + currentBeerId);
                }
            }
        }

        private IQueryable<BeerChartViewModel> GetAllBeers()
        {
            var allBeers = this.data.Beers.All()
                .Select(beer => new BeerChartViewModel
                {
                    ID = beer.ID,
                    FullBeerName = beer.Brand.Name + " " + beer.Name,
                    Image = beer.Images.FirstOrDefault(),
                    Rating = beer.BeerRatings.Average(rating => rating.Rating),
                    CountRatings = beer.BeerRatings.Count
                });

            return allBeers;
        }
    }
}