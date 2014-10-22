﻿namespace DrinkAndRate.Web.Account
{
    using DrinkAndRate.Data;
    using DrinkAndRate.Web.Models;
    using DrinkAndRate.Web.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class AccountDetails : BaseUserPage
    {
        private IDrinkAndRateData data;
        private string currentUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            var queryParameterId = Request.QueryString["Id"];

            if (string.IsNullOrEmpty(queryParameterId))
            {
                Response.Redirect("~/default");
            }

            var dbContext = new DrinkAndRateDbContext();
            data = new DrinkAndRateData(dbContext);

            this.currentUserId = queryParameterId;

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            var currentUser = this.data.Users.Find(currentUserId);

            if (currentUser==null)
            {
                Response.Redirect("~/default");
            }

            this.fullNameText.InnerText = string.Format("{0} {1}", currentUser.FirstName, currentUser.LastName);
            this.userNameText.InnerText = currentUser.UserName;
            this.CountryTxt.InnerText = currentUser.Country.Name;
            this.ImageContainer.BackImageUrl = currentUser.Image.Path;

            var events = this.data.UsersEvents.All()
                .Where(ev => ev.UserID == currentUserId)
                .Select(ev => new EventViewModel
                {
                    ID = ev.EventID,
                    CreatorName = ev.Event.Creator.UserName,
                    Image = ev.Event.Image,
                    Location = ev.Event.Location,
                    PeopleJoined = ev.Event.UsersEvents.Count(),
                    Title = ev.Event.Title,
                    CreatedOn = ev.Event.Date
                })
                .ToList();

            this.ListViewEvents.DataSource = events;
            this.ListViewEvents.DataBind();
        }
    }
}