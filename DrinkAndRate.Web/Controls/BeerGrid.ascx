<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BeerGrid.ascx.cs" Inherits="DrinkAndRate.Web.Controls.BeerGrid" %>

<div class="row">
    <asp:ListView ID="ListViewBeers" runat="server" ItemType="DrinkAndRate.Web.Models.BeerViewModel">
        <ItemTemplate>
            <div class="col-sm-4 col-lg-4 col-md-4">
                <div class="thumbnail">
                    <a href='<%#: "~/User/BeerDetails.aspx?id=" + Item.ID %>' runat="server" title="<%#: Item.Name %>">
                        <div class="ratio img-rounded" style="background-image: url('<%#: Item.Image!=null? Page.ResolveUrl(Item.Image.Path): "/Images/default.png" %>')"></div>
                    </a>
                    <div class="caption">
                        <h4 class="pull-right">Alco: <%#: Item.AlchoholPercentage!=null ? Item.AlchoholPercentage.Value.ToString("0.0") : "N/A" %>%
                        </h4>
                        <h4 class="truncate" style="height: 40px">
                            <a href='<%#: "~/User/BeerDetails.aspx?id=" + Item.ID %>' runat="server">
                                <%#: Item.BrandName +" "+ Item.Name %>
                            </a>
                        </h4>
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
                     <a href='<%#: "~/User/BeerDetails.aspx?id=" + Item.ID %>' runat="server" class="btn btn-success btn-block">View</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>
<asp:Panel CssClass="row" runat="server" Visible="false" ID="BeersDataPagingPanel">
    <div class="col-md-offset-3 col-md-6 col-md-offset-3">
        <asp:DataPager ID="DataPagerBeers" runat="server" PagedControlID="ListViewBeers" PageSize="9" QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-warning" NumericButtonCssClass="btn btn-info" NextPreviousButtonCssClass="btn btn-info" />
                <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
    </div>
</asp:Panel>

