namespace DrinkAndRate.Web.Controls
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class BeerGrid : UserControl
    {
        public ListView BeerList
        {
            get;
            set;
        }

        public bool IsNotAuthenticated { get; set; }

        public bool HasPaging { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.BeerList = ListViewBeers;

            if (this.HasPaging)
            {
                this.BeersDataPagingPanel.Visible = true;
            }

            
        }
    }
}