<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BeerDetails.aspx.cs" Inherits="DrinkAndRate.Web.User.BeerDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <h2><%: Title %></h2>--%>
    <h2 id="BeerName" runat="server"></h2>
    <asp:Panel ID="DivLabelErrorMessage" runat="server" Visible="false">
        <asp:Label ID="LabelErrorMessage" runat="server" ClientIDMode="static" CssClass="label label-danger"></asp:Label>
    </asp:Panel>
    <div class="row">
        <div class="panel panel-default beer-details">
            <div class="panel-body">
                <asp:Panel CssClass="ratio img-rounded" runat="server" ID="ImageContainer"></asp:Panel>
                <div class="panel panel-default beer-details-info">
                    <div class="panel-body">
                        <div class="pull-right beer-category additional-beer-info">
                            <h4 id="CategoryName" runat="server"></h4>
                            <h4 id="Alco" runat="server"></h4>
                            <hr />
                            <p>
                                <span class="glyphicon glyphicon-star"></span>
                                <span class="glyphicon glyphicon-star"></span>
                                <span class="glyphicon glyphicon-star"></span>
                                <span class="glyphicon glyphicon-star"></span>
                                <span class="glyphicon glyphicon-star"></span>
                            </p>
                            <p id="BeerRatings" runat="server">
                            </p>
                        </div>
                        <div class="text-left panel panel-default">
                            <div class="panel-body">
                                <p class="text-justify italic beer-description" id="Description" runat="server">
                                </p>
                            </div>
                        </div>
                        <div class="text-left panel panel-default">
                            <div class="panel-body">
                                <p>By </p>
                                <h4>
                                    <strong id="BrandName" runat="server"></strong>
                                </h4>
                                <hr />
                                <p id="BrandCountry" runat="server">
                                </p>
                                <p id="BrandEstablished" runat="server">
                                </p>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div class="additional-beer-info">
                                    <p id="Creator" runat="server">
                                    </p>
                                    <p id="CreatedOn" runat="server">
                                    </p>
                                </div>
                                <asp:Panel CssClass="row" Visible="false" ID="EditBeerContainer" runat="server">
                                    <div class="col-md-12">
                                        <asp:Button ID="EditBeerButton" CssClass="btn btn-primary col-md-12" Text="Edit" runat="server" OnClick="EditBeerButton_Click"></asp:Button>
                                    </div>
                                </asp:Panel>
                                <br />
                                <asp:Panel runat="server" Visible="false" ID="EditDataContainer">
                                    <div class="col-md-12">
                                        <div class="panel panel-success">
                                            <div class="panel-heading">
                                                <h3 class="panel-title text-center">Edit beer</h3>
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label for="BeerNameEditText" class="col-lg-2 control-label">Name:</label>
                                                            <div class="col-lg-10">
                                                                <asp:TextBox runat="server" ID="BeerNameEditText" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label for="BrandNameEditDropDown" class="col-lg-2 control-label">Brand:</label>
                                                            <div class="col-lg-10">
                                                                <asp:DropDownList ID="BrandNameEditDropDown" CssClass="form-control" DataTextField="Name" DataValueField="Id" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label for="AlcoEditText" class="col-lg-2 control-label">Alco:</label>
                                                            <div class="col-lg-10">
                                                                <asp:TextBox runat="server" ID="AlcoEditText" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label for="CategoriesEditDropDown" class="col-lg-2 control-label">Category:</label>
                                                            <div class="col-lg-10">
                                                                <asp:DropDownList ID="CategoriesEditDropDown" CssClass="form-control" DataTextField="Name" DataValueField="Id" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label for="DescriptionEditText" class="col-lg-2 control-label">Description:</label>
                                                            <div class="col-lg-10">
                                                                <asp:TextBox runat="server" ID="DescriptionEditText" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="col-lg-10 col-lg-offset-2">
                                                                <asp:Button ID="backButton" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="backButton_Click"></asp:Button>
                                                                <asp:Button ID="Submit" CssClass="btn btn-primary" runat="server" OnClick="Submit_Click" Text="Submit"></asp:Button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel CssClass="row" Visible="false" ID="RemoveBeerContainer" runat="server">
                                    <div class="col-md-12">
                                        <asp:Button ID="RemoveBeerButton" CssClass="btn btn-danger col-md-12" Text="Remove" runat="server" OnClick="RemoveBeerButton_Click"></asp:Button>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 comments">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <h4>Comments</h4>
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <asp:Panel CssClass="row" ID="PanelAddNewComment" runat="server">
                                        <div class="col-md-12">
                                            <asp:Button ID="ButtonAddNewComment" CssClass="btn btn-primary col-md-12" Text="Add New Comment" runat="server" OnClick="ButtonAddNewComment_Click"></asp:Button>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                    <asp:Panel CssClass="text-center" runat="server" Visible="false" ID="PanelAddNewCommentData">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <div class="col-lg-12">
                                                            <asp:TextBox runat="server" ID="TextBoxAddComment" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="col-lg-12">
                                                        <br />
                                                        <asp:Button ID="backButtonComments" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="backButtonComments_Click"></asp:Button>
                                                        <asp:Button ID="ButtonAddCommentData" CssClass="btn btn-primary" runat="server" Text="Add Comment" OnClick="ButtonAddCommentData_Click"></asp:Button>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                </div>
                            </div>
                            <asp:ListView ID="ListViewComments" runat="server"
                                ItemType="DrinkAndRate.Web.Models.CommentsViewModel"
                                SelectMethod="ListViewComments_GetData">
                                <ItemTemplate>
                                    <div class="panel panel-default">
                                        <div class="panel-body">
                                            <div class="pull-right comment-info">
                                                <p>
                                                    <%#:  "By: " + Item.CreatorName%>
                                                </p>
                                                <p>
                                                    <%#: Item.CreatedOn%>
                                                </p>
                                            </div>
                                            <div class="comment-content">
                                                <p>
                                                    <%#: Item.Content%>
                                                </p>
                                            </div>
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
