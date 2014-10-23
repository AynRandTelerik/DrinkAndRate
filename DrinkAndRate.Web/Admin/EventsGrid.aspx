﻿<%@ Page Title="EventsGrid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventsGrid.aspx.cs" Inherits="DrinkAndRate.Web.Admin.EventsGrid" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center alert alert-dismissable alert-success" id="headerInfo" runat="server">Events Grid</h3>
	<div class="row">
		<div class="col-md-12">
			<asp:GridView CssClass="table table-striped table-hover table-bordered table-responsive"
				ID="gridView" runat="server" DataSourceID="EntityDataSourceProvider"
				AllowPaging="True" AllowSorting="True"
				AutoGenerateColumns="false"
				AutoGenerateDeleteButton="true"
				AutoGenerateEditButton="true">
				<Columns>
					<asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
					<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
					<asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"></asp:BoundField>
					<asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location"></asp:BoundField>
					<asp:BoundField DataField="ImageID" HeaderText="ImageID" SortExpression="ImageID"></asp:BoundField>
					<asp:BoundField DataField="CreatorID" HeaderText="CreatorID" ReadOnly="True" SortExpression="CreatorID"></asp:BoundField>
				</Columns>
			</asp:GridView>
			<ef:EntityDataSource runat="server" ID="EntityDataSourceProvider"
				OnContextCreating="dataSource_ContextCreating"
				EntitySetName="Events"
				EnableDelete="true" EnableInsert="true" EnableUpdate="true">
			</ef:EntityDataSource>
		</div>
	</div>
</asp:Content>
