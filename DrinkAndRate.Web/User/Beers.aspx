<%@ Page Title="Beers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Beers.aspx.cs" Inherits="DrinkAndRate.Web.User.Beers" %>

<%@ Register TagPrefix="uc" TagName="BeerGrid" Src="~/Controls/BeerGrid.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <asp:UpdatePanel ID="UpdataPanelBeer" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" Visible="false" CssClass="panel panel-warning" ID="FilterContainer">
                <div class="panel-heading">
                    <h3 class="panel-title">Filters</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group navbar-form">
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="SearchTextbox" AutoPostBack="true" TextMode="Search" OnTextChanged="SearchTextbox_TextChanged" placeholder="Search beer with name" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-btn">
                                    <button class="btn btn-default" type="button"><span class="glyphicon glyphicon-search"></span></button>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="OrderType" class="control-label col-md-3">Order type:</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="OrderType" AutoPostBack="true" OnSelectedIndexChanged="GetFilteredBeers" CssClass="form-control" DataTextField="Name" DataValueField="ID" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="OrderType" class="control-label col-md-3">Order by:</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="OrderBy" AutoPostBack="true" OnSelectedIndexChanged="GetFilteredBeers" CssClass="form-control" DataTextField="Name" DataValueField="ID" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <div class="row">
                <div class="col-md-6">
                    <a id="createBeerButton" href="~/User/BeerCreate" runat="server" class="btn btn-success btn-block">Add new beer</a>
                </div>
                <div class="col-md-6">
                    <asp:Button runat="server" ID="FilterButton" CssClass="btn btn-success btn-block" Text="Show filters" OnClick="FilterButton_Click"></asp:Button>
                </div>
            </div>
            <uc:BeerGrid runat="server" ID="UserControlBeerGrid" HasPaging="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
