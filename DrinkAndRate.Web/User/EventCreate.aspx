<%@ Page Language="C#" AutoEventWireup="true" Title="Create Event" MasterPageFile="~/Site.Master" CodeBehind="EventCreate.aspx.cs" Inherits="DrinkAndRate.Web.User.EventCreate" %>

<%@ Register TagPrefix="uc" TagName="FileUpload" Src="~/Controls/FileUpload.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <fieldset class="form-horizontal">
        <legend class="text-center alert alert-dismissable alert-success">Please provide information about the event:</legend>
        <asp:Panel ID="DivLabelErrorMessage" runat="server" Visible="false">
            <asp:Label ID="LabelErrorMessage" runat="server" ClientIDMode="static" CssClass="label label-danger"></asp:Label>
        </asp:Panel>
        <div class="form-group">
            <label for="ImageUpload" class="col-lg-2 control-label">Image:</label>
            <div class="col-lg-10">
                <uc:FileUpload ID="FileUploadControl" IsRequired="true" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label for="title" class="col-lg-2 control-label">Title:</label>
            <div class="col-lg-10">
                <input type="text" runat="server" class="form-control" id="title" placeholder="Title">
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldTitle" ControlToValidate="title" CssClass="label label-danger pull-right" ErrorMessage="Title is required!" Display="Dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="location" class="col-lg-2 control-label">Location:</label>
            <div class="col-lg-10">
                <input type="text" runat="server" class="form-control" id="location" placeholder="Location">
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldLocation" ControlToValidate="location" CssClass="label label-danger pull-right" ErrorMessage="Location is required!" Display="Dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="date" class="col-lg-2 control-label">Date and time:</label>
            <div class="col-lg-10">
                <input type="datetime-local" class="form-control" runat="server" id="date" />
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldDate" ControlToValidate="date" CssClass="label label-danger pull-right" ErrorMessage="Date of the event is required!" Display="Dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div class="col-lg-10 col-lg-offset-2">
                <a id="backButton" href="~/User/Events" runat="server" class="btn btn-danger">Cancel</a>
                <asp:Button ID="Submit" CssClass="btn btn-primary" runat="server" OnClick="Submit_Click" Text="Submit"></asp:Button>
            </div>
        </div>
    </fieldset>
</asp:Content>
