<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FBNPC.Master" AutoEventWireup="true" CodeBehind="RegisterList.aspx.cs" Inherits="MvcApplication1.Admin.RegisterList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <title>:: FBNPC : Register List ::</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row">
            <div class="col-sm-6">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                <asp:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtSearch"
                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                </asp:AutoCompleteExtender>  
                </div>
                <div class="col-sm-6">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="Search" OnClick="Search" />
                    <asp:Button ID="btnReset" runat="server" CssClass="btn btn-circle" Text="Reset" OnClick="Reset" />
            </div>
        </div>
        <br />
        <div class="tab-pane" id="Userinfo" runat="server" visible="true">
                                <div class="portlet box blue">
                                     <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>List Of Register Users
                                            </div>
                                        </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                       
                                        <div class="form-body">
                                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                            <asp:Panel id="pnl" runat="server" ScrollBars="Auto">
        <asp:GridView ID="GRdListRegister" runat="server" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GRdListRegister_PageIndexChanging" PagerSettings-Mode="Numeric" PageSize="10" PagerStyle-HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblProgramsID" runat="server" Text='<%# Eval("RegisterID") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="true" HeaderText="Action">
                                    <ItemTemplate>                                        
                                        <asp:LinkButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" OnClick="Delete"> <img src="FBNPC/images/delete.png" width="20" alt="Delete" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblTitleName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                        <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email ID">
                    <ItemTemplate>
                        <asp:Label ID="lblEmailID" runat="server" Text='<%# Eval("EmailID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone No">
                    <ItemTemplate>
                        <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Eval("PhoneNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Class">
                    <ItemTemplate>
                        <asp:Label ID="lblClassType" runat="server" Text='<%# Eval("ClassType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Exam Date">
                    <ItemTemplate>
                        <asp:Label ID="lblExamDate" runat="server" Text='<%# Eval("ExamDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                        <asp:Label ID="lblModifyBy" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Postal">
                    <ItemTemplate>
                        <asp:Label ID="lblPostal" runat="server" Text='<%# Eval("Postal") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="lblModifyDate" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Other Information" HeaderStyle-Width="300px">
                    <ItemTemplate>
                        <asp:Label ID="lblSpecialRequest" runat="server" Text='<%# Eval("SpecialRequest") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4"  FirstPageText="First" LastPageText="Last"/>
        </asp:GridView>
                                                
                                            </asp:Panel>
                                            </div>
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
                                        Project Completed <strong class="text-custom">53%</strong>.
                                    </div>
                                    <div>
                                        <strong>KSap Creations</strong> - Copyright &copy; 2018
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div> <!-- end footer -->

              

                <div class="clearfix"></div>
    </form>
</asp:Content>
