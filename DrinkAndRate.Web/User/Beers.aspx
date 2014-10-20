<%@ Page Title="Beers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Beers.aspx.cs" Inherits="DrinkAndRate.Web.User.Beers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-12">
            <a id="A1" href="~/User/BeerCreate" runat="server" class="btn btn-success btn-block">Create</a>
        </div>
    </div>
    <div class="row">
        <asp:ListView ID="ListViewBeers" runat="server" ItemType="DrinkAndRate.Web.Models.BeerViewModel">
            <ItemTemplate>
                <div class="col-sm-4 col-lg-4 col-md-4">
                    <div class="thumbnail">
                        <a href="<%#: Item.ID %>" title="<%#: Item.Name %>">
                            <div class="ratio img-rounded" style="background-image: url('<%#: Item.Image!=null? Page.ResolveUrl(Item.Image.Path): "/Images/default.png" %>')"></div>
                        </a>
                        <div class="caption">
                            <h4 class="pull-right">Alco: <%#: Item.AlchoholPercentage!=null? Item.AlchoholPercentage: 0 %>%
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
                        <div class="pull-right additional-beer-info">
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
                        <div class="additional-beer-info">
                            <p class="truncate">
                                <%#: "Creator: "+ Item.CreatorName%>
                            </p>
                            <p class="truncate">
                                <%#: Item.CreatedOn %>
                            </p>
                        </div>
                        <a href="#/items/{{ item._id }}/edit" class="btn btn-success btn-block">View</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div class="row">
        <div class="col-md-offset-3 col-md-6 col-md-offset-3">
            <asp:DataPager ID="DataPagerBeers" runat="server" PagedControlID="ListViewBeers" PageSize="9" QueryStringField="page">
                <Fields>
                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-warning" NumericButtonCssClass="btn btn-info" NextPreviousButtonCssClass="btn btn-info"/>
                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>