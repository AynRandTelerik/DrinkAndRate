<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="ErrorPage.aspx.cs" Inherits="DrinkAndRate.Web.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="head-margin">
        <h2>Error:</h2>
        <asp:Label ID="FriendlyErrorMsg" runat="server" Text="Label" Font-Size="Large" style="color: red"></asp:Label>
    </div>

    <asp:Panel ID="DetailedErrorPanel" runat="server" Visible="false">
        <div class="panel panel-primary error-margin">
            <h4>Detailed Error:</h4>
            <p>
                <asp:Label ID="ErrorDetailedMsg" runat="server" Font-Size="Small" /><br />
            </p>
        </div>

        <div class="panel panel-primary error-margin">
            <h4>Error Handler:</h4>
            <p>
                <asp:Label ID="ErrorHandler" runat="server" Font-Size="Small" /><br />
            </p>
        </div>

        <div class="panel panel-primary error-margin">
            <h4>Detailed Error Message:</h4>
            <p>
                <asp:Label ID="InnerMessage" runat="server" Font-Size="Small" /><br />
            </p>
            <p>
                <asp:Label ID="InnerTrace" runat="server"  />
            </p>
        </div>
    </asp:Panel>
</asp:Content>