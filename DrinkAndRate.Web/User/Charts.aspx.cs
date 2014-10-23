namespace DrinkAndRate.Web.User
{
    using DrinkAndRate.Web.Models;
    using System;
    using System.Collections.Generic;

    public partial class Charts : BaseUserPage
    {
        private IEnumerable<ChartViewModel> chartsCollection;

        protected void Page_Init(object sender, EventArgs e)
        {
            var allCharts = new List<ChartViewModel>
            {
                new ChartViewModel 
                {
                    Title = "TOP 10",
                    Description = "The legendary top 10 rated beers ever.",
                    Type = "Top10"
                },
                new ChartViewModel 
                {
                    Title = "MOST RATED 10",
                    Description = "Most popular beers ever.",
                    Type = "MostRated"
                }
            };

            this.chartsCollection = allCharts;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            this.ChartsListView.DataSource = this.chartsCollection;
            this.ChartsListView.DataBind();
        }
    }
}