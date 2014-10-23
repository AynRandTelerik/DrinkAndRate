﻿<%@ Page Title="ArticlesGrid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticlesGrid.aspx.cs" Inherits="DrinkAndRate.Web.Admin.ArticlesGrid" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<asp:UpdatePanel ID="UpdataPanel" runat="server">
		<ContentTemplate>
			<h3 class="text-center alert alert-dismissable alert-success" id="headerInfo" runat="server">Articles Grid</h3>
			<div class="row">
				<div class="col-md-12">
					<asp:GridView CssClass="table table-striped table-hover table-bordered table-responsive"
						ID="gridView" runat="server" DataSourceID="EntityDataSourceProvider"
						AllowPaging="True" AllowSorting="True"
						AutoGenerateColumns="false"
						AutoGenerateDeleteButton="true"
						AutoGenerateEditButton="true">
						<Columns>
							<asp:BoundField DataField="ID" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
							<asp:BoundField DataField="BeerID" HeaderText="BeerID" SortExpression="BeerID"></asp:BoundField>
							<asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content"></asp:BoundField>
							<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
							<asp:BoundField DataField="CreatorID" HeaderText="CreatorID" ReadOnly="True" SortExpression="CreatorID"></asp:BoundField>
						</Columns>
					</asp:GridView>
					<ef:EntityDataSource runat="server" ID="EntityDataSourceProvider"
						OnContextCreating="dataSource_ContextCreating"
						EntitySetName="Articles"
						EnableDelete="true" EnableInsert="true" EnableUpdate="true">
					</ef:EntityDataSource>
				</div>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
