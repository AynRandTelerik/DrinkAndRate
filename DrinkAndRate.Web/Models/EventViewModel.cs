namespace DrinkAndRate.Web.Models
{
    using DrinkAndRate.Models;
    using System;

    public class EventViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string CreatorName { get; set; }

        public Image Image { get; set; }

        public int PeopleJoined { get; set; }
    }
}