<%@ Page Language="C#" AutoEventWireup="true" Title="Event Details" MasterPageFile="~/Site.Master" CodeBehind="EventDetails.aspx.cs" Inherits="DrinkAndRate.Web.User.EventDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="row">
        <div class="col-md-6">
            <h1 id="EventName" class="text-center" runat="server"></h1>
            <div class="row">
                <div class="col-md-6">
                    Where: <big><strong class="text-success text-center" id="LocationTxt" runat="server"></strong> </big>
                </div>
                <div class="col-md-6">
                    Created by: <big><strong class="text-success text-center" runat="server" id="CreatorTxt"></strong> </big>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-6">
                    When: <big><strong class="text-success text-center" id="EventDateTxt" runat="server"></strong> </big>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Button ID="JoinEventButton" CssClass="btn btn-primary col-md-12" runat="server" OnClick="JoinEventButton_Click"></asp:Button>
                </div>
            </div>
            <br />
            <asp:Panel CssClass="row" Visible="false" ID="EditEventContainer" runat="server">
                <div class="col-md-12">
                    <asp:Button ID="EditEventButton" CssClass="btn btn-primary col-md-12" Text="Edit" runat="server" OnClick="EditEventButton_Click"></asp:Button>
                </div>
            </asp:Panel>
            <br />
            <asp:Panel runat="server" Visible="false" ID="EditDataContainer">
                <div class="col-md-12">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">Edit data</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="title" class="col-lg-2 control-label">Title:</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox runat="server" ID="EventTitleEditText" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="title" class="col-lg-2 control-label">Location:</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox runat="server" ID="LocationEditText" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="title" class="col-lg-2 control-label">Date:</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox runat="server" TextMode="DateTimeLocal" ID="DateTimeEditText" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <div class="col-lg-10 col-lg-offset-2">
                                            <asp:Button id="backButton" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="backButton_Click"></asp:Button>
                                            <asp:Button ID="Submit" CssClass="btn btn-primary" runat="server" OnClick="Submit_Click" Text="Submit"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
        <div class="col-md-6">
            <div class="row">
                <asp:Panel CssClass="ratio-details img-rounded" runat="server" ID="ImageContainer"></asp:Panel>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <h3 class="panel-title text-center">Joined users</h3>
                </div>
                <div class="panel-body">
                    <asp:ListView ID="ListViewUsers" runat="server" ItemType="DrinkAndRate.Web.Models.JoinedUsersViewModel">
                        <ItemTemplate>
                            <div class="col-sm-3 col-lg-3 col-md-3">
                                <div class="thumbnail">
                                    <a href="<%#: ResolveUrl("~/Account/AccountDetails?Id="+Item.ID) %>" title="<%#: Item.UserName %>" id="DetailsUserViewButton">
                                        <asp:Panel CssClass="ratio" BackImageUrl="<%#: Item.Image.Path %>" runat="server" ID="UserImageContainer"></asp:Panel>
                                    </a>
                                    <div class="text-center">
                                        <p id="userNameTxt" class="label label-info label-thumbnail" runat="server"><%#: Item.UserName %></p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
