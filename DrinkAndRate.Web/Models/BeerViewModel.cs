namespace DrinkAndRate.Web.Models
{
    using DrinkAndRate.Models;
    using System;

    public class BeerViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? AlchoholPercentage { get; set; }

        public int BeerRatings { get; set; }

        public string BrandName { get; set; }

        public string CategoryName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string CreatorName { get; set; }

        public string Description { get; set; }

        public Image Image { get; set; }
    }
}