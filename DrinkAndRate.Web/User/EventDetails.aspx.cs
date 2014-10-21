namespace DrinkAndRate.Web.User
{
    using DrinkAndRate.Data;
    using DrinkAndRate.Web.Models;
    using System;
    using System.Linq;

    public partial class EventDetails : BaseUserPage
    {
        private IDrinkAndRateData data;
        private int eventId;

        protected void Page_Load(object sender, EventArgs e)
        {
            var queryParameterId = Request.QueryString["Id"];

            if (string.IsNullOrEmpty(queryParameterId))
            {
                Response.Redirect("~/User/Events");
            }

            this.eventId = int.Parse(queryParameterId);

            var dbContext = new DrinkAndRateDbContext();
            data = new DrinkAndRateData(dbContext);

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            var eventData = data.Events.Find(eventId);

            this.ImageContainer.BackImageUrl = eventData.Image.Path;
            this.EventName.InnerText = eventData.Title;

            this.LocationTxt.InnerText = eventData.Location;
            this.CreatorTxt.InnerText = eventData.Creator.UserName;

            this.EventDateTxt.InnerText = eventData.Date.ToString();

            this.ListViewUsers.DataSource = eventData.UsersEvents
                .Select(userEvents => new JoinedUsersViewModel 
                {
                    UserName = userEvents.User.UserName,
                    ID = userEvents.User.Id
                });
            this.ListViewUsers.DataBind();
        }
    }
}