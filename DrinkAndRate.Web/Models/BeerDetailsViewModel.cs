namespace DrinkAndRate.Web.Models
{
    using DrinkAndRate.Models;
    using System;
    using System.Collections.Generic;

    public class BeerDetailsViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? AlchoholPercentage { get; set; }

        public int BeerRatings { get; set; }

        public string BrandName { get; set; }

        public string BrandCountry { get; set; }

        public DateTime? BrandEstablished { get; set; }

        public string CategoryName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string CreatorName { get; set; }

        public string Description { get; set; }

        public Image Image { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<Article> Articles { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}