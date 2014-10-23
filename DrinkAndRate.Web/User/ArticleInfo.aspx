<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleInfo.aspx.cs" Inherits="DrinkAndRate.Web.User.ArticleInfo" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelView" runat="server" Visible="true">
        <div class="col-md-offset-1 head-margin">
            <h2><%#: "Title: " + this.articleModel.ArticleTitle %></h2>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading"><%#: "Beer: " + this.articleModel.Beer  %></div>
            <div class="panel-body">
                <p><%#: this.articleModel.Content %></p>
            </div>
        </div>
        <asp:LinkButton ID="EditButton" Visible="false" CssClass="btn btn-success" runat="server" CommandArgument="ID" OnCommand="EditButton_Command" Text="Edit"></asp:LinkButton>
        <asp:LinkButton ID="DeleteButton" Visible="false" CssClass="btn btn-danger" runat="server" CommandArgument="ID" OnCommand="DeleteButton_Command" Text="Delete"></asp:LinkButton>
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
