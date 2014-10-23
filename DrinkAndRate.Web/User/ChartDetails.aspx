<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Title="Chart Details" CodeBehind="ChartDetails.aspx.cs" Inherits="DrinkAndRate.Web.User.ChartDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center alert alert-dismissable alert-success" id="ChartHeaderInfo" runat="server"></h3>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView CssClass="table table-striped table-hover table-bordered table-responsive"
                ID="ChartGridView" runat="server" AutoGenerateColumns="false"
                OnRowDataBound="ChartGridView_RowDataBound" ItemType="DrinkAndRate.Web.Models.BeerChartViewModel"
                OnSelectedIndexChanged="ChartGridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"
                        HeaderText="ID" />
                    <asp:TemplateField HeaderText="#" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FullBeerName" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"
                        HeaderText="Beer" />
                    <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                        <HeaderTemplate>
                            <asp:Label runat="server" Text="Rating"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#: Item.Rating!=null?Item.Rating.Value.ToString("0.0") : "0" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                        <HeaderTemplate>
                            <asp:Label runat="server" Text="Reviews count"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#: Item.CountRatings!=null?Item.CountRatings:0 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
