<%@ Page Title="Articles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="DrinkAndRate.Web.User.Articles" %>
<asp:Content ID="AllArticles" ContentPlaceHolderID="MainContent" runat="server">
<%--//Beer
//Title
//Creator
//Content--%>
    <h2><%: Title %>.</h2>
    <asp:ListView ID="ListViewArticles" runat="server" ItemType="DrinkAndRate.Web.Models.ArticleViewModel">
        <ItemTemplate>
            <div class="row">
                <div class="thumbnail">
<%--                    <a href="<%#: Item.ArticleId %>"><%#: Item.Title %></a>
                        <div class="caption">
                        <h4 class="truncate">
                            <a href="#/items/{{item._id}}">
                                <%#: Item.BrandName +" "+ Item.Name %>
                            </a>
                        </h4>
                        <p class="truncate">
                            <%#: Item.CategoryName %>
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
                    </div>--%>
                    <div class="additional-beer-info">
                        <p class="truncate">
                            <%#: "Title: " + Item.ArticleTitle %>
                        </p>
                        <p class="truncate">
                            <%#:  "Created by: " + Item.Creator %>
                        </p>
                    </div>
                    <a href="/User/ArticleInfo.aspx?articleID=<%#:Item.ArticleId %>" class="btn btn-success">View Details...</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <asp:Panel CssClass="row" runat="server" Visible="false" ID="BeersDataPagingPanel">
        <div class="col-md-offset-3 col-md-6 col-md-offset-3">
            <asp:DataPager ID="DataPagerBeers" runat="server" PagedControlID="ListViewArticles" PageSize="9" QueryStringField="page">
                <Fields>
                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-warning" NumericButtonCssClass="btn btn-info" NextPreviousButtonCssClass="btn btn-info" />
                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </div>
    </asp:Panel>
</asp:Content>
