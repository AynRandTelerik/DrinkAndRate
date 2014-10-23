<%@ Page Language="C#" AutoEventWireup="true" Title="Charts" MasterPageFile="~/Site.Master" CodeBehind="Charts.aspx.cs" Inherits="DrinkAndRate.Web.User.Charts" %>

<%@ Register TagPrefix="uc" TagName="ChartGrid" Src="~/Controls/ChartGrid.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center alert alert-dismissable alert-success">Explore our charts</h3>
    <div class="row">
        <asp:ListView ID="ChartsListView" runat="server" ItemType="DrinkAndRate.Web.Models.ChartViewModel">
            <ItemTemplate>
                <uc:ChartGrid runat="server" Type="<%#: Item.Type %>" Title="<%#: Item.Title %>" Description="<%#: Item.Description %>" />
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
