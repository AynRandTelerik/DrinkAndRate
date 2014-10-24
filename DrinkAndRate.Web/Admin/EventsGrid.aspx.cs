namespace DrinkAndRate.Web.Admin
{
	using DrinkAndRate.Data;
	using DrinkAndRate.Models;
	using DrinkAndRate.Web.Models;
	using DrinkAndRate.Web.User;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.UI;

	public partial class EventsGrid : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void gridView_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var eventId = int.Parse(e.Values["ID"].ToString());

            var allUserEvents = this.data.UsersEvents.All()
                .Where(userEvent => userEvent.EventID == eventId)
                .ToList();

            foreach (var userEvent in allUserEvents)
            {
                this.data.UsersEvents.Delete(userEvent);
            }

            this.data.SaveChanges();
        }
    }
}