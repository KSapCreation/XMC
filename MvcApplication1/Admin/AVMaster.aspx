﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FBNPC.Master" AutoEventWireup="true" CodeBehind="AVMaster.aspx.cs" Inherits="MvcApplication1.Admin.AVMaster" %>
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
    <title>:: FBNPC Our Programs ::</title>
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
                                                <i class="fa fa-gift"></i>Audio Video Master
                                            </div>
                                        </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                       
                                        <div class="form-body">
                                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div>
                                                        <label class="control-label">Subject Name</label>
                                                        <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" placeholder="Subject Name"> </asp:TextBox>

                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div>
                                                        <label class="control-label">Doc type</label>
                                                        <asp:DropDownList ID="ddlTrans" runat="server" CssClass="form-control">
                                                            <asp:ListItem  Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem  Value="1" Text="Audio"></asp:ListItem>
                                                            <asp:ListItem  Value="2" Text="Video"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-4">
                                                     <label class="control-label">Upload File</label>
                                                    <asp:FileUpload ID="fileuploadname" runat="server" CssClass="form-control" />
                                                </div>
                                            </div>
                                            
                                        </div>
                                        <div class="form-actions right">
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn default" Text="Cancel" OnClick="Cancel" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn blue" OnClick="Save" />

                                        </div>
                                    </div>
                                </div>
                            </div>      
                      <!-- Grid Values -->                                      
                          <asp:GridView ID="GRDAudioVideo" runat="server" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GRDAudioVideo_PageIndexChanging" PagerSettings-Mode="Numeric" PageSize="10">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProgramsID" runat="server" Text='<%# Eval("AVID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField Visible="true" HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" OnClick="Update" ><img src="FBNPC/images/edit.png" width="20px" alt="" /></asp:LinkButton>&nbsp;&nbsp;
                                        <asp:LinkButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" OnClick="Delete" > <img src="FBNPC/images/delete.png" width="20px" alt="" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Audio Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitleName" runat="server" Text='<%# Eval("SubjectName") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Doc Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDoctype" runat="server" Text='<%# Eval("TransType") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                                                     
                                <asp:TemplateField HeaderText="Update By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblModifyBy" runat="server" Text='<%# Eval("ModifyBy") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Update Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblModifyDate" runat="server" Text='<%# Eval("ModifyDate") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
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
