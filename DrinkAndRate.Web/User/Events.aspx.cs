namespace DrinkAndRate.Web.User
{
    using DrinkAndRate.Data;
    using DrinkAndRate.Web.Models;
    using System;
    using System.Web.UI;
    using System.Linq;

    public partial class Events : BaseUserPage
    {
        private IDrinkAndRateData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new DrinkAndRateDbContext();
            data = new DrinkAndRateData(dbContext);

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {

            var events = data.Events.All()
                .Select(ev => new EventViewModel
                {
                    CreatorName = ev.Creator.UserName,
                    CreatedOn = ev.Date,
                    ID = ev.ID,
                    Image = ev.Image,
                    Location = ev.Location,
                    Title = ev.Title,
                    PeopleJoined = ev.UsersEvents.Count()+1
                })
                .ToList();


            this.ListViewEvents.DataSource = events;
            this.ListViewEvents.DataBind();
        }
    }
}