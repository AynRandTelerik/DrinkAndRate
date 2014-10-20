<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DrinkAndRate.Web._Default" %>
<%@ Register TagPrefix="uc" TagName="BeerGrid" Src="~/Controls/BeerGrid.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Drink And Rate</h1>
        <p class="lead">Share your experience</p>
        <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <uc:BeerGrid runat="server" ID="UserControlBeerGrid"/>
</asp:Content>