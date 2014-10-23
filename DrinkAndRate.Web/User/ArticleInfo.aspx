<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleInfo.aspx.cs" Inherits="DrinkAndRate.Web.User.ArticleInfo" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelView" runat="server" Visible="true">
        <h3>Full article</h3>
        <h4><%#: this.articleModel.ArticleTitle %></h4>
        <p>
            <%#: "Beer:" + this.articleModel.Beer  %>
        </p>
        <p><%#: this.articleModel.Content %></p>
        <asp:LinkButton ID="EditButton" Visible="false" CssClass="btn btn-success" runat="server" CommandArgument="ID" OnCommand="EditButton_Command" Text="Edit"></asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="PanelEdit" runat="server" Visible="false">
        <h3>Edit article</h3>
        <asp:TextBox ID="TextBoxArticleTitle" Width="15em" runat="server"  
            Text='<%# this.articleModel.ArticleTitle %>' />
        <br />
        <br />
        <asp:TextBox ID="TextBoxArticleContent" Width="30em" Height="15em" runat="server" TextMode="MultiLine" 
            Text='<%# this.articleModel.Content %>' />
        <br />
        <asp:Requiredfieldvalidator id="RequiredTitle" controltovalidate="TextBoxArticleTitle" cssclass="label label-danger pull-right" errormessage="Title is required!" display="dynamic" setfocusonerror="true" runat="server"></asp:Requiredfieldvalidator>
        <asp:Requiredfieldvalidator id="RequiredContent" controltovalidate="TextBoxArticleContent" cssclass="label label-danger pull-right" errormessage="Content is required!" display="dynamic" setfocusonerror="true" runat="server"></asp:Requiredfieldvalidator>
        <asp:LinkButton ID="SaveButton" CssClass="btn btn-success" runat="server" CommandArgument="ID" OnCommand="SaveButton_Command" Text="Save Changes"></asp:LinkButton>
    </asp:Panel>
</asp:Content>
