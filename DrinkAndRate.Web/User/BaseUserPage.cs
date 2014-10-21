namespace DrinkAndRate.Web.User
{
    using System.Web;
    using System.Web.UI;

    public abstract class BaseUserPage : Page
    {
        public BaseUserPage()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpContext.Current.Response.Redirect("~/Default");
            }
        }
    }
 }