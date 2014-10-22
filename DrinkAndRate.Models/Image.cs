namespace DrinkAndRate.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public Image()
        {
            Events = new HashSet<Event>();
            Beers = new HashSet<Beer>();
            Users = new HashSet<AppUser>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Path { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }
    }
}