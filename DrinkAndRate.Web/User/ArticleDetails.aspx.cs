using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkAndRate.Web.User
{
    public partial class ArticleDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["articleID"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                

            }
        }
    }
}