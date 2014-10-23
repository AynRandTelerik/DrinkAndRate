namespace DrinkAndRate.Web.User
{
    using DrinkAndRate.Data;
    using DrinkAndRate.Models;
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    public partial class EventCreate : BaseUserPage
    {
        private IDrinkAndRateData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new DrinkAndRateDbContext();
            this.data = new DrinkAndRateData(dbContext);
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string filePathAndName = string.Empty;

                try
                {
                    filePathAndName = FileUploadControl.Upload();
                }
                catch (InvalidOperationException ex)
                {
                    this.DivLabelErrorMessage.Visible = true;
                    this.LabelErrorMessage.Text = ex.Message;

                    return;
                }

                var loggedInUserName = HttpContext.Current.User.Identity.Name;
                var currentUserId = this.data.Users.All().FirstOrDefault(x => x.UserName == loggedInUserName).Id;

                var newImage = new Image
                {
                    Path = filePathAndName
                };

                this.data.Images.Add(newImage);
                this.data.SaveChanges();

                var newEvent = new Event
                {
                    Title = this.title.Value,
                    ImageID = newImage.ID,
                    Location = this.location.Value,
                    Date = Convert.ToDateTime(this.date.Value),
                    CreatorID = currentUserId
                };

                this.data.Events.Add(newEvent);

                newEvent.UsersEvents.Add(new UsersEvents
                {
                    UserID = currentUserId,
                    EventID = newEvent.ID
                });

                this.data.SaveChanges();

                Response.Redirect("~/User/Events");
            }
            else
            {
                throw new InvalidOperationException("Error occured while saving the element!");
            }
        }
    }
}