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
            <div class="row">
                <div class="col-md-6">
                    When: <big><strong class="text-success text-center" id="EventDateTxt" runat="server"></strong> </big>
                </div>
            </div>
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
                            <div class="col-sm-4 col-lg-4 col-md-4">
                                <div class="thumbnail">
                                    <%--<asp:Panel CssClass="ratio img-rounded" runat="server" ID="UserImageContainer"></asp:Panel>--%>
                                    <div class="captions">
                                        <p id="userNameTxt" runat="server"><%#: Item.UserName %></p>
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
