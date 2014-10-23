<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Title="Account Details" CodeBehind="AccountDetails.aspx.cs" Inherits="DrinkAndRate.Web.Account.AccountDetails" %>

<asp:Content ID="AllArticles" ContentPlaceHolderID="MainContent" runat="server">
	<br />
	<div class="row">
		<div class="col-md-6">
			<div class="row">
				<div class="col-md-12">
					<asp:Panel CssClass="ratio img-rounded" runat="server" ID="ImageContainer"></asp:Panel>
				</div>
			</div>
			<div class="jumbotron">
				<div class="row">
					<div class="col-md-12">
						Username: <big><strong class="text-success text-center" id="userNameText" runat="server"></strong> </big>
					</div>
				</div>
				<asp:Panel ID="panelManagePassword" Visible="false" CssClass="row" runat="server">
					<div class="col-md-12">
						Password:
						<asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" ID="ChangePassword" runat="server" />
					</div>
				</asp:Panel>
				<div class="row">
					<div class="col-md-12">
						Full name: <big><strong class="text-success text-center" runat="server" id="fullNameText"></strong> </big>
					</div>
				</div>
				<div class="row">
					<div class="col-md-12">
						Country: <big><strong class="text-success text-center" id="CountryTxt" runat="server"></strong> </big>
					</div>
				</div>
			</div>
		</div>
		<div class="col-md-6">
			<div class="row">
				<div class="col-md-12">
					<div class="panel panel-success">
						<div class="panel-heading">
							<h3 class="panel-title text-center">Joined events</h3>
						</div>
						<div class="panel-body">
							<asp:ListView ID="ListViewEvents" runat="server" ItemType="DrinkAndRate.Web.Models.EventViewModel">
								<ItemTemplate>
									<div class="col-lg-12">
										<div class="thumbnail">
											<a href="<%#: ResolveUrl("~/User/EventDetails?Id="+Item.ID) %>" title="<%#: Item.Title %>">
												<div class="ratio-events img-rounded" style="background-image: url('<%#: Item.Image!=null? Page.ResolveUrl(Item.Image.Path): "/Images/default.png" %>')"></div>
											</a>
											<div class="caption">
												<h4 class="truncate well well-sm text-center">
													<a href="<%#: ResolveUrl("~/User/EventDetails?Id="+Item.ID) %>">
														<%#: Item.Title %>
													</a>
												</h4>
											</div>
											<div>
												<div class="row">
													<div class="col-md-6">
														<p class="truncate additional-beer-info">
															Where: <big><strong class="text-success"><%#: Item.Location %></strong> </big>
														</p>
													</div>
													<div class="col-md-6 text-right">
														<p class="truncate additional-beer-info">
															Joined: <big><strong class="text-success"><%#: Item.PeopleJoined %> people</strong> </big>
														</p>
													</div>
												</div>
												<div class="row">
													<div class="col-md-6">
														<p class="truncate additional-beer-info">
															When: <big><strong class="text-success"><%#: Item.CreatedOn %></strong> </big>
														</p>
													</div>
													<div class="col-md-6">
														<div class="additional-beer-info">
															<p class="truncate text-right">
																Creator: <big><strong class="text-success"><%#: Item.CreatorName %></strong> </big>
															</p>
														</div>
													</div>
												</div>
											</div>
											<a href="<%#: ResolveUrl("~/User/EventDetails?Id="+Item.ID) %>" class="btn btn-primary btn-block">View and Join</a>
										</div>
									</div>
								</ItemTemplate>
							</asp:ListView>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>