<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FBNPC.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="MvcApplication1.Admin.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
        <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
        <meta content="Coderthemes" name="author" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />

        <link rel="shortcut icon" href="../assets/demo-data/Logo_fbnpc_new.png">
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
    
    <script type="text/javascript" src="tiny_mce/tiny_mce.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>

                    <div class="container">    
                                                             
                            <div class="tab-pane" id="Userinfo" runat="server" visible="true">
                                <div class="portlet box blue">
                                     <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Change Password
                                            </div>
                                        </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                       
                                        <div class="form-body">  
                                            <div class="row">
                                             <div class="col-md-12">
                                                    <div>
                                                        <label class="control-label">User Name</label> : &nbsp;
                                                       <asp:Label ID="lblUserName" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>

                                                    </div>
                                                </div>    
                                            </div>                                                       
                                        <div class="row">
                                             <div class="col-md-12">
                                                    <div>
                                                        <label class="control-label">Old Password</label>
                                                       <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" TextMode="Password"> </asp:TextBox>

                                                    </div>
                                                </div>    
                                            </div>
                                            <div class="row">
                                             <div class="col-md-12">
                                                    <div>
                                                        <label class="control-label">New Password</label>
                                                       <asp:TextBox ID="txtNew" runat="server" CssClass="form-control"  TextMode="Password"> </asp:TextBox>
                                                         <span>
                                                    <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txtNew" ControlToValidate="txtConform" ErrorMessage="Your passwords do not match!" Display="Dynamic" ForeColor="#cc3300" />
                                                </span>
                                                    </div>
                                                </div>    
                                            </div>
                                            
                                              <div class="row">
                                             <div class="col-md-12">
                                                    <div>
                                                        <label class="control-label">Conform Password</label>
                                                       <asp:TextBox ID="txtConform" runat="server" CssClass="form-control" TextMode="Password"> </asp:TextBox>

                                                    </div>
                                                </div>    
                                            </div>
                                            </div>
                                        
                                        <div class="form-actions right">
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn default" Text="Cancel" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn blue" OnClick="Save" />

                                        </div>
                                    </div>
                                </div>                           
                    </div>
                    <!-- end container -->
                     <div class="footer">
                        <div class="container">
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="pull-right hidden-xs">
                                        Project Completed <strong class="text-custom">43%</strong>.
                                    </div>
                                    <div>
                                        <strong>K Sap Creations</strong> - Copyright &copy; 2018
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div> <!-- end footer -->

              

                <div class="clearfix"></div>

            
        </form>
</asp:Content>
