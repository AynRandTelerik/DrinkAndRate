namespace DrinkAndRate.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Country()
        {
            Brands = new HashSet<Brand>();
            Users = new HashSet<AppUser>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }
    }
}
