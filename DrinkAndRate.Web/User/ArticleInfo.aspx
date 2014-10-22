<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleInfo.aspx.cs" Inherits="DrinkAndRate.Web.User.ArticleInfo" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelView" runat="server" Visible="true">
        <h3>Full article</h3>
        <h4><%#: this.articleModel.ArticleTitle %></h4>
        <p><%#: this.articleModel.Content %></p>
        <asp:LinkButton ID="EditButton" runat="server" CommandArgument="ID" OnCommand="EditButton_Command" Text="Edit"></asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="PanelEdit" runat="server" Visible="false">
        <h3>Edit article</h3>
        <asp:TextBox ID="TextBoxArticleTitle" runat="server"  
            Text='<%# this.articleModel.ArticleTitle %>' />
        <br />
        <br />
        <asp:TextBox ID="TextBoxArticleContent" runat="server" TextMode="MultiLine" 
            Text='<%# this.articleModel.Content %>' />
        <br />
        <asp:LinkButton ID="SaveButton" runat="server" CommandArgument="ID" OnCommand="SaveButton_Command" Text="Save Changes"></asp:LinkButton>
    </asp:Panel>
</asp:Content>
