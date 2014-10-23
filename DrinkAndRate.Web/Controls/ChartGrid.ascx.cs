namespace DrinkAndRate.Web.Controls
{
    using System;
    using System.Web.UI;

    public partial class ChartGrid : UserControl
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.TitleText.InnerText = Title;
                this.DescriptionText.InnerText = Description;
                this.ChartDetailsLink.PostBackUrl = string.Format("~/User/ChartDetails?Type={0}", this.Type);
            }
        }
    }
}