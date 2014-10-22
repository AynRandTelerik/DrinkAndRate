namespace DrinkAndRate.Web.User
{
    using DrinkAndRate.Data;
    using DrinkAndRate.Web.Models;
    using DrinkAndRate.Models;
    using System;
    using System.Linq;
    using System.Web;

    public partial class EventDetails : BaseUserPage
    {
        private const string JOIN_EVENT = "Join The Event";
        private const string ALREADY_JOINED = "You Are Part Of The Event";

        private IDrinkAndRateData data;
        private int eventId;
        private string currentUserId;

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

            var loggedInUserName = HttpContext.Current.User.Identity.Name;
            this.currentUserId = this.data.Users.All().FirstOrDefault(x => x.UserName == loggedInUserName).Id;

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            var eventData = data.Events.Find(eventId);

            if (eventData == null)
            {
                Response.Redirect("~/User/Events");
            }

            if (eventData.CreatorID == this.currentUserId)
            {
                this.EditEventContainer.Visible = true;
            }

            this.ImageContainer.BackImageUrl = eventData.Image.Path;
            this.EventName.InnerText = eventData.Title;
            this.LocationTxt.InnerText = eventData.Location;
            this.CreatorTxt.InnerText = eventData.Creator.UserName;
            this.EventDateTxt.InnerText = eventData.Date.ToString();

            this.EventTitleEditText.Text = eventData.Title;
            this.LocationEditText.Text = eventData.Location;
            this.DateTimeEditText.Text = eventData.Date.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");

            var currentJoinButtonText = JOIN_EVENT;

            var isUserJoined = eventData.UsersEvents.Any(userEvent => userEvent.UserID == this.currentUserId);

            if (isUserJoined)
            {
                currentJoinButtonText = ALREADY_JOINED;
                this.JoinEventButton.Enabled = false;
            }

            this.JoinEventButton.Text = currentJoinButtonText;

            this.ListViewUsers.DataSource = eventData.UsersEvents
                .Select(userEvents => new JoinedUsersViewModel
                {
                    UserName = userEvents.User.UserName,
                    ID = userEvents.User.Id,
                    Image = userEvents.User.Image
                });

            this.ListViewUsers.DataBind();
        }

        protected void JoinEventButton_Click(object sender, EventArgs e)
        {
            var newJoinedUser = new UsersEvents
            {
                EventID = this.eventId,
                UserID = this.currentUserId
            };

            this.data.UsersEvents.Add(newJoinedUser);
            this.data.SaveChanges();

            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void EditEventButton_Click(object sender, EventArgs e)
        {
            this.EditDataContainer.Visible = true;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var eventData = data.Events.Find(eventId);

            eventData.Date = Convert.ToDateTime(this.DateTimeEditText.Text);
            eventData.Title = this.EventTitleEditText.Text;
            eventData.Location = this.LocationEditText.Text;

            this.data.Events.Update(eventData);
            this.data.SaveChanges();

            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            this.EditDataContainer.Visible = false;
        }
    }
}