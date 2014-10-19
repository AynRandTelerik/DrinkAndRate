<%@ Page Title="Beers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Beers.aspx.cs" Inherits="DrinkAndRate.Web.User.Beers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <a href="~/User/BeerCreate" runat="server" class="btn btn-success btn-block">Create</a>
    <div class="row">
        <asp:Repeater ID="RepeaterBeers" runat="server" ItemType="DrinkAndRate.Web.Models.BeerViewModel">
            <ItemTemplate>
                <div class="col-sm-4 col-lg-4 col-md-4">
                    <div class="thumbnail">
                        <a href="#/items/{{item._id}}" title="{{ item.title }}">
                            <div style="background-image: url('images/{{ item.imageUrl }}')" class="ratio"></div>
                            <div style="background-image: url('images/default.jpg')" class="ratio"></div>
                        </a>
                        <div class="caption">
                            <h4 class="pull-right">Alco: <%#: Item.AlchoholPercentage %>%
                            </h4>
                            <h4 class="truncate">
                                <a href="#/items/{{item._id}}">
                                    <%#: Item.BrandName +" "+ Item.Name %>
                                </a>
                            </h4>
                            <p class="truncate">
                                <%#: Item.CategoryName %>
                            </p>
                            <p class="truncate text-center">
                                <%#: Item.Description %>
                            </p>
                        </div>
                        <div class="pull-right">
                            <p>
                                <span class="glyphicon glyphicon-star"></span>
                                <span class="glyphicon glyphicon-star"></span>
                                <span class="glyphicon glyphicon-star"></span>
                                <span class="glyphicon glyphicon-star"></span>
                                <span class="glyphicon glyphicon-star"></span>
                            </p>
                            <p>
                                <%#: Item.BeerRatings %> reviews
                            </p>
                        </div>
                        <div>
                            <p class="truncate">
                                <%#: "Creator: "+ Item.CreatorName%>
                            </p>
                            <p class="truncate">
                                <%#: Item.CreatedOn %>
                            </p>
                            <a href="#/items/{{ item._id }}/edit" class="btn btn-success btn-block">View</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>