using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkAndRate.Web.Models
{
    public class CommentsViewModel
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public string CreatorName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}