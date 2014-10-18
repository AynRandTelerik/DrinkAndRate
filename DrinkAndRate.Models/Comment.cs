namespace DrinkAndRate.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey("Creator")]
        public string CreatorID { get; set; }

        [Required]
        public int BeerID { get; set; }

        public virtual Beer Beer { get; set; }

        public virtual AppUser Creator { get; set; }
    }
}