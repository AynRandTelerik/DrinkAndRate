namespace DrinkAndRate.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BeerRating
    {
        public int ID { get; set; }

        public int BeerID { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }

        public DateTime? RatedOn { get; set; }

        public virtual Beer Beer { get; set; }

        public virtual AppUser User { get; set; }
    }
}