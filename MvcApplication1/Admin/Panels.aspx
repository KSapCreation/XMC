<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FBNPC.Master" AutoEventWireup="true" CodeBehind="Panels.aspx.cs" Inherits="MvcApplication1.Admin.Panels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
        <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
        <meta content="Coderthemes" name="author" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />

        <link rel="shortcut icon" href="assets/images/logoTitle.png">
     <link href="FBNPC/css/components-md.css" rel="stylesheet" />
    <link href="FBNPC/css/components-rounded.css" rel="stylesheet" />
        <!-- Bootstrap core CSS -->
    <link href="FBNPC/css/components.css" rel="stylesheet" />
        <!-- Bootstrap core CSS -->
        <link href="FBNPC/css/bootstrap.min.css" rel="stylesheet">
        <!-- Icons CSS -->
        <link href="FBNPC/css/icons.css" rel="stylesheet">
        <!-- Custom styles for this template -->
        <link href="FBNPC/css/style.css" rel="stylesheet">
    <title>:: FBNPC Panels ::</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>

                    <div class="container">                                         
                            <div class="tab-pane" id="Userinfo" runat="server" visible="true">
                                <div class="portlet box blue">
                                     <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Sliders Content
                                            </div>
                                        </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->                                       
                                        <div class="form-body">
                                            <h3 class="form-section"></h3>

                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group has-error">
                                                        <label class="control-label">Type of Panels</label>
                                                        <asp:DropDownList ID="ddlPanels" runat="server" CssClass="form-control" OnSelectedIndexChanged="OnSelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Slider Content 1"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Slider Content 2"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Slider Content 3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>                                              

                                            </div>
                                         <div class="row">
                                                <div class="col-md-6">
                                                    <div>
                                                        <label class="control-label">Title</label>
                                                       <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </div>
                                                </div>                                              
                                             <div class="col-md-6">
                                                    <div>
                                                        <label class="control-label">Description</label>
                                                       <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>    
                                            </div>

                                        </div>
                                        <div class="form-actions right">
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn default" Text="Cancel" OnClick="Cancel" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn blue" OnClick="SaveSlider"  />

                                        </div>
                                    </div>
                                </div>
                            </div>                                            
                    </div>
                    <!-- end container -->
                  

              

                <div class="clearfix"></div>

            
        </form>
</asp:Content>
