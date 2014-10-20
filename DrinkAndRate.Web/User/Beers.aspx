<%@ Page Title="Beers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Beers.aspx.cs" Inherits="DrinkAndRate.Web.User.Beers" %>
<%@ Register TagPrefix="uc" TagName="BeerGrid" Src="~/Controls/BeerGrid.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-12">
            <a id="A1" href="~/User/BeerCreate" runat="server" class="btn btn-success btn-block">Create</a>
        </div>
    </div>
    <uc:BeerGrid runat="server" ID="UserControlBeerGrid" HasPaging="true"/>
</asp:Content>