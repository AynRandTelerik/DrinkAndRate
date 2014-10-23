namespace DrinkAndRate.Web.Models
{
    using DrinkAndRate.Models;

    public class BeerChartViewModel
    {
        public int ID { get; set; }

        public string FullBeerName { get; set; }

        public double? Rating { get; set; }

        public int CountRatings { get; set; }

        public Image Image { get; set; }
    }
}