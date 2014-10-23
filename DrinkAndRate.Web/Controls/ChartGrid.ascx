<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChartGrid.ascx.cs" Inherits="DrinkAndRate.Web.Controls.ChartGrid" %>

<div class="col-sm-6 col-lg-6 col-md-6">
    <asp:LinkButton runat="server" ID="ChartDetailsLink">
        <div class="thumbnail alert alert-dismissable alert-info padding-thumbnail">
            <div class="caption">
                <h1 class="text-center" id="TitleText" runat="server"></h1>
                <h3 class="text-center" id="DescriptionText" runat="server"></h3>
            </div>
        </div>
    </asp:LinkButton>
</div>
