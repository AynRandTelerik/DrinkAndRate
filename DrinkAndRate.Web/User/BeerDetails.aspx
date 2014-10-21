<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BeerDetails.aspx.cs" Inherits="DrinkAndRate.Web.User.BeerDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:Panel ID="DivLabelErrorMessage" runat="server" Visible="false">
        <asp:Label ID="LabelErrorMessage" runat="server" ClientIDMode="static" CssClass="label label-danger"></asp:Label>
    </asp:Panel>
    <div class="row">
        <div class="panel panel-default beer-details">
            <div class="panel-body">
                <asp:FormView ID="FormViewBeer" runat="server"
                    SelectMethod="DetailsViewBeer_GetItem"
                    ItemType="DrinkAndRate.Web.Models.BeerDetailsViewModel">
                    <ItemTemplate>
                        <div class="ratio img-rounded" style="background-image: url('<%#: Item.Image!=null? Page.ResolveUrl(Item.Image.Path): "/Images/default.png" %>')"></div>
                        <div class="panel panel-default beer-details-info">
                            <div class="panel-body">
                                <div class="pull-right beer-category additional-beer-info">
                                    <h4><%#: Item.CategoryName %></h4>
                                    <h4>Alco: <%#: Item.AlchoholPercentage!=null? Item.AlchoholPercentage: 0 %>%</h4>
                                    <hr />
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
                                <div class="text-left panel panel-default">
                                    <div class="panel-body">
                                        <p class="text-justify italic beer-description">
                                            <%#: Item.Description %>
                                        </p>
                                    </div>
                                </div>
                                <div class="text-left panel panel-default">
                                    <div class="panel-body">
                                        <p>By </p>

                                        <h4>
                                            <strong><%#: Item.BrandName %></strong>
                                        </h4>
                                        <hr />
                                        <p>
                                            <%#: Item.BrandCountry %>
                                        </p>
                                        <p>
                                            Established: <%#: Item.BrandEstablished %>
                                        </p>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <div class="additional-beer-info">
                                            <p>
                                                <%#: "Creator: "+ Item.CreatorName%>
                                            </p>
                                            <p>
                                                <%#: Item.CreatedOn %>
                                            </p>
                                        </div>
                                        <%--<a href="#/items/{{ item._id }}/edit" class="btn btn-success btn-block">Edit</a>--%>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--                    <asp:ListView ID="ListViewComments" runat="server"
                    ItemType="DrinkAndRate.Web.Models.CommentsViewModel"
                            SelectMethod="FormViewComments_GetAll">
                    <ItemTemplate>
                        <div class="col-lg-12 comments">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h4>Comments</h4>
                                             <p>
                                                    <%#: Item.Content%>
                                                </p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>--%>
                    </ItemTemplate>
                </asp:FormView>
            </div>
        </div>
    </div>
</asp:Content>

