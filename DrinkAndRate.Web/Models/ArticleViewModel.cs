using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkAndRate.Web.Models
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }
        public string Beer { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Content { get; set; }
    }
}