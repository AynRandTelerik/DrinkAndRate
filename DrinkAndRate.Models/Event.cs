namespace DrinkAndRate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event
    {
        public Event()
        {
            UsersEvents = new HashSet<UsersEvents>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        [StringLength(150)]
        public string Location { get; set; }

        public int ImageID { get; set; }

        [Required]
        [ForeignKey("Creator")]
        public string CreatorID { get; set; }

        public virtual AppUser Creator { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<UsersEvents> UsersEvents { get; set; }
    }
}