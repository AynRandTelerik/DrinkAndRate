<%@ Page Language="C#" AutoEventWireup="true" Title="Events" MasterPageFile="~/Site.Master" CodeBehind="Events.aspx.cs" Inherits="DrinkAndRate.Web.User.Events" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="row">
        <div class="col-md-6">
            <a id="createBeerButton" href="~/User/EventCreate" runat="server" class="btn btn-success btn-block">Add Event</a>
        </div>
        <div class="col-md-6">
            <asp:Button runat="server" ID="FilterButton" CssClass="btn btn-success btn-block" Text="Show filters"></asp:Button>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:ListView ID="ListViewEvents" runat="server" ItemType="DrinkAndRate.Web.Models.EventViewModel">
                <ItemTemplate>
                    <div class="col-lg-12">
                        <div class="thumbnail">
                            <a href="<%#: Item.ID %>" title="<%#: Item.Title %>">
                                <div class="ratio-events img-rounded" style="background-image: url('<%#: Item.Image!=null? Page.ResolveUrl(Item.Image.Path): "/Images/default.png" %>')"></div>
                            </a>
                            <div class="caption">
                                <h4 class="truncate well well-sm text-center">
                                    <a href="#/items/{{item._id}}">
                                        <%#: Item.Title %>
                                    </a>
                                </h4>
                            </div>
                            <div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <p class="truncate additional-beer-info">
                                            Where: <big><strong class="text-success"><%#: Item.Location %></strong> </big>
                                        </p>
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <p class="truncate additional-beer-info">
                                            Joined: <big><strong class="text-success"><%#: Item.PeopleJoined %> people</strong> </big>
                                        </p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <p class="truncate additional-beer-info">
                                            When: <big><strong class="text-success"><%#: Item.CreatedOn %></strong> </big>
                                        </p>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="additional-beer-info">
                                            <p class="truncate text-right">
                                                Creator: <big><strong class="text-success"><%#: Item.CreatorName %></strong> </big>
                                            </p>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <a href="#/items/{{ item._id }}/edit" class="btn btn-primary btn-block">View and Join</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>
