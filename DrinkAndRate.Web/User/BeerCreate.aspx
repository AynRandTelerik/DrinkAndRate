<%@ Page Title="Beer Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BeerCreate.aspx.cs" Inherits="DrinkAndRate.Web.User.BeerCreate" %>

<%@ Register TagPrefix="uc" TagName="FileUpload" Src="~/Controls/FileUpload.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <fieldset class="form-horizontal">
        <legend class="text-center alert alert-dismissable alert-success">Please provide information about the beer:</legend>
        <asp:Panel ID="DivLabelErrorMessage" runat="server" Visible="false">
            <asp:Label ID="LabelErrorMessage" runat="server" ClientIDMode="static" CssClass="label label-danger"></asp:Label>
        </asp:Panel>
        <div class="form-group">
            <label for="ImageUpload" class="col-lg-2 control-label">Image:</label>
            <div class="col-lg-10">
                <uc:FileUpload ID="FileUploadControl" runat="server" />
            </div>
        </div>
        <asp:Panel runat="server" ID="SelectBrand" Visible="true" CssClass="form-group">
            <label for="Brands" class="col-lg-2 control-label">Brand:</label>
            <div class="input-group col-lg-10">
                <asp:DropDownList ID="Brands" CssClass="form-control" DataTextField="Name" DataValueField="ID" runat="server">
                </asp:DropDownList>
                <span class="input-group-btn">
                    <asp:Button CssClass="btn btn-default" Text="Add" runat="server" ID="AddBrandButton" OnClick="AddBrandButton_Click" />
                </span>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="BrandCreation" Visible="false" CssClass="panel panel-warning">
            <div class="panel-heading">
                <h3 class="panel-title">Brand Info</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label for="Countries" class="col-lg-2 control-label">Country:</label>
                    <div class="input-group col-lg-10">
                        <asp:DropDownList ID="Countries" CssClass="form-control" DataTextField="Name" DataValueField="ID" runat="server">
                        </asp:DropDownList>
                        <span class="input-group-btn">
                            <asp:Button CssClass="btn btn-default" Text="Undo" runat="server" ID="Undo" OnClick="AddBrandButton_Click" />
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="BrandName" class="col-lg-2 control-label">Brand name:</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="BrandName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldBrandName" ControlToValidate="BrandName" CssClass="label label-danger pull-right" ErrorMessage="Brand Name is required!" Display="Dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="Established" class="col-lg-2 control-label">Established:</label>
                    <div class="col-lg-10">
                        <input type="date" class="form-control" runat="server" id="Established" />
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldDate" ControlToValidate="Established" CssClass="label label-danger pull-right" ErrorMessage="Established date is required!" Display="Dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
                </div>
            </div>
        </asp:Panel>
        <div class="form-group">
            <label for="Categories" class="col-lg-2 control-label">Category:</label>
            <div class="col-lg-10">
                <asp:DropDownList ID="Categories" CssClass="form-control" DataTextField="Name" DataValueField="Id" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="name" class="col-lg-2 control-label">Name:</label>
            <div class="col-lg-10">
                <input type="text" runat="server" class="form-control" id="name" placeholder="Name">
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldName" ControlToValidate="name" CssClass="label label-danger pull-right" ErrorMessage="Name is required!" Display="Dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="alcoholPercentage" class="col-lg-2 control-label">Alcohol Percentage:</label>
            <div class="input-group col-lg-10">
                <input type="number" id="alcoholPercentage" min="1" max="100" step="1" runat="server" class="form-control" />
                <span class="input-group-addon">%</span>
            </div>
        </div>
        <div class="form-group">
            <label for="description" class="col-lg-2 control-label">Description:</label>
            <div class="col-lg-10">
                <textarea class="form-control" rows="3" id="description" runat="server" placeholder="Please provide some description for this beer."></textarea>
            </div>
        </div>
        <div class="form-group">
            <div class="col-lg-10 col-lg-offset-2">
                <a href="~/User/Beers" runat="server" class="btn btn-danger">Cancel</a>
                <asp:Button ID="Submit" CssClass="btn btn-primary" runat="server" OnClick="Submit_Click" Text="Submit"></asp:Button>
            </div>
        </div>
    </fieldset>
</asp:Content>
