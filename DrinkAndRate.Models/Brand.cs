namespace DrinkAndRate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Brand
    {
        public Brand()
        {
            Beers = new HashSet<Beer>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int CountryID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Established { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }

        public virtual Country Country { get; set; }
    }
}
