<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DrinkAndRate.Web._Default" %>
<%@ Register TagPrefix="uc" TagName="BeerGrid" Src="~/Controls/BeerGrid.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Drink And Rate</h1>
        <p class="lead">Share your experience</p>
    </div>

    <div class="panel panel-success">
        <div class="panel-heading">
            <h3 class="panel-title text-center">Latest added beers</h3>
        </div>
        <div class="panel-body">
            <uc:BeerGrid runat="server" ID="UserControlBeerGrid" />
        </div>
    </div>
</asp:Content>
