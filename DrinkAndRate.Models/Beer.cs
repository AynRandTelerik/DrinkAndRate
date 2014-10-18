namespace DrinkAndRate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Beer
    {
        public Beer()
        {
            Articles = new HashSet<Article>();
            BeerRatings = new HashSet<BeerRating>();
            Comments = new HashSet<Comment>();
            Images = new HashSet<Image>();
        }

        public int ID { get; set; }

        public int BrandID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? AlchoholPercentage { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Creator")]
        public string CreatorID { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<BeerRating> BeerRatings { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }

        public virtual AppUser Creator { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}