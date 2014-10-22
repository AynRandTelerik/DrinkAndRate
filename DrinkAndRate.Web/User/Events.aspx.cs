namespace DrinkAndRate.Web.User
{
    using DrinkAndRate.Data;
    using DrinkAndRate.Web.Models;
    using System;
    using System.Web.UI;
    using System.Linq;
    using DrinkAndRate.Models;
    using System.Collections.Generic;

    public partial class Events : BaseUserPage
    {
        private const string SHOW_MESSAGE = "Show filters";
        private const string HIDE_MESSAGE = "Hide filters";

        private HashSet<OrderModel> orderByCollection;
        private HashSet<OrderModel> orderTypeCollection;

        private IDrinkAndRateData data;

        private bool IsFilterOn
        {
            get
            {
                if (Session["IsFilterOn"] == null)
                {
                    return false;
                }

                return (bool)Session["IsFilterOn"];
            }
            set
            {
                Session["IsFilterOn"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.orderByCollection = new HashSet<OrderModel>
            {
                new OrderModel{ID=1, Name="Asc"},
                new OrderModel{ID=2, Name="Desc"}
            };

            this.orderTypeCollection = new HashSet<OrderModel>
            {
                new OrderModel{ID=1, Name="Location"},
                new OrderModel{ID=2, Name="Creator name"},
                new OrderModel{ID=3, Name="Title"},
                new OrderModel{ID=4, Name="Date"},
                new OrderModel{ID=5, Name="Joined users"},
            };
        }

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
                    PeopleJoined = ev.UsersEvents.Count()
                })
                .ToList();


            this.ListViewEvents.DataSource = events;
            this.ListViewEvents.DataBind();

            LoadFilterData();
        }

        private void LoadFilterData()
        {
            this.OrderType.DataSource = this.orderByCollection;
            this.OrderType.DataBind();

            this.OrderBy.DataSource = this.orderTypeCollection;
            this.OrderBy.DataBind();
        }

        protected void GetFilteredEvents(object sender, EventArgs e)
        {
            Session["IsFilterOn"] = true;

            if (!string.IsNullOrEmpty(this.OrderBy.SelectedValue))
            {
                Session["OrderBy"] = this.OrderBy.SelectedValue;
            }
            if (!string.IsNullOrEmpty(this.OrderType.SelectedValue))
            {
                Session["OrderType"] = this.OrderType.SelectedValue;
            }

            var orderBy = (string)Session["OrderBy"];
            var orderType = (string)Session["OrderType"];

            var allEvents = this.data.Events.All();

            if (orderType == "1")
            {
                switch (orderBy)
                {
                    case "1":
                        allEvents = allEvents.OrderBy(ev => ev.Location);
                        break;
                    case "2":
                        allEvents = allEvents.OrderBy(ev => ev.Creator.UserName);
                        break;
                    case "3":
                        allEvents = allEvents.OrderBy(ev => ev.Title);
                        break;
                    case "4":
                        allEvents = allEvents.OrderBy(ev => ev.Date);
                        break;
                    case "5":
                        allEvents = allEvents.OrderBy(ev => ev.UsersEvents.Count());
                        break;
                    default:
                        throw new ArgumentException("Wrong order type");
                }
            }
            else
            {
                switch (orderBy)
                {
                    case "1":
                        allEvents = allEvents.OrderByDescending(ev => ev.Location);
                        break;
                    case "2":
                        allEvents = allEvents.OrderByDescending(ev => ev.Creator.UserName);
                        break;
                    case "3":
                        allEvents = allEvents.OrderByDescending(ev => ev.Title);
                        break;
                    case "4":
                        allEvents = allEvents.OrderByDescending(ev => ev.Date);
                        break;
                    case "5":
                        allEvents = allEvents.OrderByDescending(ev => ev.UsersEvents.Count());
                        break;
                    default:
                        throw new ArgumentException("Wrong order type");
                }
            }

            SetListViewData(allEvents);
        }

        private IEnumerable<EventViewModel> GetEventsData(IQueryable<Event> queryableEventData)
        {
            var eventData = queryableEventData.Select(ev => new EventViewModel
            {
                CreatorName = ev.Creator.UserName,
                CreatedOn = ev.Date,
                ID = ev.ID,
                Image = ev.Image,
                Location = ev.Location,
                Title = ev.Title,
                PeopleJoined = ev.UsersEvents.Count()
            })
            .ToList();

            return eventData;
        }

        private void SetListViewData(IQueryable<Event> queryableBeerData)
        {
            var listViewDataEvents = GetEventsData(queryableBeerData);

            this.ListViewEvents.DataSource = listViewDataEvents;
            this.ListViewEvents.DataBind();
        }

        protected void FilterButton_Click(object sender, EventArgs e)
        {
            this.FilterContainer.Visible = !this.FilterContainer.Visible;

            if (this.FilterButton.Text.IndexOf(SHOW_MESSAGE) != -1)
            {
                this.FilterButton.Text = HIDE_MESSAGE;
            }
            else
            {
                this.FilterButton.Text = SHOW_MESSAGE;
            }
        }
    }
}