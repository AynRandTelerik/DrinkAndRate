<%@ Page Language="C#" AutoEventWireup="true" Title="Events" MasterPageFile="~/Site.Master" CodeBehind="Events.aspx.cs" Inherits="DrinkAndRate.Web.User.Events" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdataPanelBeer" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" Visible="false" CssClass="panel panel-warning" ID="FilterContainer">
                <div class="panel-heading">
                    <h3 class="panel-title">Filters</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="OrderType" class="control-label col-md-3">Order type:</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="OrderType" AutoPostBack="true" OnSelectedIndexChanged="GetFilteredEvents" CssClass="form-control" DataTextField="Name" DataValueField="ID" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="OrderType" class="control-label col-md-3">Order by:</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="OrderBy" AutoPostBack="true" OnSelectedIndexChanged="GetFilteredEvents" CssClass="form-control" DataTextField="Name" DataValueField="ID" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="row">
                <div class="col-md-6">
                    <a id="createBeerButton" href="~/User/EventCreate" runat="server" class="btn btn-success btn-block">Add Event</a>
                </div>
                <div class="col-md-6">
                    <asp:Button runat="server" ID="FilterButton" CssClass="btn btn-success btn-block" OnClick="FilterButton_Click" Text="Show filters"></asp:Button>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:ListView ID="ListViewEvents" runat="server" ItemType="DrinkAndRate.Web.Models.EventViewModel">
                        <ItemTemplate>
                            <div class="col-lg-12">
                                <div class="thumbnail">
                                    <a href="<%#: ResolveUrl("~/User/EventDetails?Id="+Item.ID) %>" title="<%#: Item.Title %>">
                                        <div class="ratio-events img-rounded" style="background-image: url('<%#: Item.Image!=null? Page.ResolveUrl(Item.Image.Path): "/Images/default.png" %>')"></div>
                                    </a>
                                    <div class="caption">
                                        <h4 class="truncate well well-sm text-center">
                                            <a href="<%#: ResolveUrl("~/User/EventDetails?Id="+Item.ID) %>">
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
                                    <a href="<%#: ResolveUrl("~/User/EventDetails?Id="+Item.ID) %>" class="btn btn-primary btn-block">View and Join</a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
