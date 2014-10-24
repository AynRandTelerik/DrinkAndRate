namespace DrinkAndRate.Web.Controls
{
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class BeerGrid : UserControl
    {
        public ListView BeerList
        {
            get;
            set;
        }

        public bool IsAuthenticated { get; set; }

        public bool HasPaging { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.BeerList = ListViewBeers;

            if (this.HasPaging)
            {
                this.BeersDataPagingPanel.Visible = true;
            }

            this.IsAuthenticated = HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}