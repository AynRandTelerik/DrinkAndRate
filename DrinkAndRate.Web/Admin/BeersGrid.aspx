﻿<%@ Page Title="BeersGrid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BeersGrid.aspx.cs" Inherits="DrinkAndRate.Web.Admin.BeersGrid" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<asp:UpdatePanel ID="UpdataPanel" runat="server">
		<ContentTemplate>
			<h3 class="text-center alert alert-dismissable alert-success" id="headerInfo" runat="server">Beers Grid</h3>
			<asp:GridView CssClass="table table-striped table-hover table-bordered table-responsive"
				ID="gridView" runat="server" DataSourceID="EntityDataSourceProvider"
				AllowPaging="True" AllowSorting="True"
				AutoGenerateColumns="false"
				AutoGenerateDeleteButton="true"
				AutoGenerateEditButton="true">
				<Columns>
					<asp:BoundField DataField="ID" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
					<asp:BoundField DataField="BrandID" HeaderText="BrandID" SortExpression="BrandID"></asp:BoundField>
					<asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID"></asp:BoundField>
					<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
					<asp:BoundField DataField="AlchoholPercentage" HeaderText="AlchoholPercentage" SortExpression="AlchoholPercentage"></asp:BoundField>
					<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
					<asp:BoundField DataField="CreatorID" HeaderText="CreatorID" ReadOnly="True" SortExpression="CreatorID"></asp:BoundField>
					<asp:BoundField DataField="CreatedOn" HeaderText="CreatedOn" ReadOnly="True" SortExpression="CreatedOn"></asp:BoundField>
				</Columns>
			</asp:GridView>
			<ef:EntityDataSource runat="server" ID="EntityDataSourceProvider"
				OnContextCreating="dataSource_ContextCreating"
				EntitySetName="Beers"
				EnableDelete="true" EnableInsert="true" EnableUpdate="true">
			</ef:EntityDataSource>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
