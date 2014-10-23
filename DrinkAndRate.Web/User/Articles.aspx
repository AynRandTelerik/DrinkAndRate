<%@ Page Title="Articles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="DrinkAndRate.Web.User.Articles" %>
<asp:Content ID="AllArticles" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-8">
            <asp:ListView ID="ListViewArticles" runat="server" ItemType="DrinkAndRate.Web.Models.ArticleViewModel">
                <ItemTemplate>
                        <div class="thumbnail col-md-6">
                            <div class="additional-beer-info article-style">
                                <h4 class="truncate">
                                    <%#: "Title: " + Item.ArticleTitle %>
                                </h4>
                                <p class="truncate">
                                    <%#:  "Created by: " + Item.Creator %>
                                </p>
                            </div>
                            <a href="/User/ArticleInfo.aspx?articleID=<%#:Item.ArticleId %>" class="btn btn-primary pull-right">View Details...</a>
                        </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <p class="truncate">
                        No articles yet.
                    </p>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
        <div class="col-md-4">
            <a href="/User/ArticleCreate.aspx" ID="ButtonCreateArticleRedirect" class="btn btn-success btn-block">Create article</a>
            <asp:Button ID="ButtonMyArticleRedirect" class="btn btn-danger btn-block"
                 runat="server" OnClick="ButtonMyArticleRedirect_Click" Text="View my articles"></asp:Button>
            <asp:Button ID="ButtonAllArticlesRedirect" class="btn btn-warning btn-block" Visible="false"
                 runat="server" OnClick="ButtonAllArticlesRedirect_Click" Text="View all articles"></asp:Button>
        </div>
    </div>
    <asp:Panel CssClass="row" runat="server" Visible="true" ID="ArticlesDataPagingPanel">
        <div class="col-md-offset-3 col-md-6 col-md-offset-3">
            <asp:DataPager ID="DataPagerBeers" runat="server" PagedControlID="ListViewArticles" PageSize="6" QueryStringField="page">
                <Fields>
                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-warning" NumericButtonCssClass="btn btn-info" NextPreviousButtonCssClass="btn btn-info" />
                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </div>
    </asp:Panel>
</asp:Content>
