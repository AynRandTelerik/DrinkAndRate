﻿<%@ Page Title="Create Article" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleCreate.aspx.cs" Inherits="DrinkAndRate.Web.User.ArticleCreate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center alert alert-dismissable alert-success">Create article</h3>
    <fieldset class="form-horizontal">
        <div class="form-group">
            <label for="Beers" class="col-lg-2 control-label">Beer:</label>
            <div class="col-lg-10">
                <asp:DropDownList ID="Beers" CssClass="form-control" DataTextField="BrandAndName" DataValueField="Id" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="ArticleTitle" class="col-lg-2 control-label">Title:</label>
            <div class="col-lg-10">
                <input type="text" runat="server" class="form-control" id="ArticleTitle" placeholder="Enter title." />
            </div>
            <asp:RequiredFieldValidator ID="Requiredfieldname" ControlToValidate="ArticleTitle" CssClass="label label-danger pull-right" ErrorMessage="Title is required!" Display="dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="Content" class="col-lg-2 control-label">Content:</label>
            <div class="col-lg-10">
                <textarea class="form-control" rows="3" id="Content" runat="server" placeholder="Provide content for the article."></textarea>
            </div>
            <asp:RequiredFieldValidator ID="Requiredfieldcontent" ControlToValidate="Content" CssClass="label label-danger pull-right" ErrorMessage="Content is required!" Display="dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div class="col-lg-10 col-lg-offset-2">
                <a href="~/User/Articles" runat="server" class="btn btn-danger">Cancel</a>
                <asp:Button ID="Submit" CssClass="btn btn-success" runat="server" OnClick="Submit_Click" Text="Submit"></asp:Button>
            </div>
        </div>
    </fieldset>
</asp:Content>
