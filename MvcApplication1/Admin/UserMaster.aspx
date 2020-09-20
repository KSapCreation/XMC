
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FBNPC.Master" AutoEventWireup="true" CodeBehind="UserMaster.aspx.cs" Inherits="MvcApplication1.Admin.UserMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
        <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
        <meta content="Coderthemes" name="author" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />

        <link rel="shortcut icon" href="../assets/demo-data/logoTitle.png">
    <link href="FBNPC/css/components-md.css" rel="stylesheet" />
    <link href="FBNPC/css/components-rounded.css" rel="stylesheet" />
        <!-- Bootstrap core CSS -->
    <link href="FBNPC/css/components.css" rel="stylesheet" />
        <link href="FBNPC/css/bootstrap.min.css" rel="stylesheet">
        <!-- Icons CSS -->
        <link href="FBNPC/css/icons.css" rel="stylesheet">
        <!-- Custom styles for this template -->
        <link href="FBNPC/css/style.css" rel="stylesheet">
    <title>:: FBNPC User Master ::</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id ="form1" runat="server">
        <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>
        


                    <div class="container">
                      
                        <div class="tab-pane" id="Userinfo" runat="server" visible="true">
                            <div class="portlet box blue">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-gift"></i>User Detail
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->

                                    <div class="form-body">
                                       
                                        <div class="row">
                                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                            <div class="col-md-6">
                                                <div class="form-group has-error">
                                                    <label class="control-label">First Name</label>
                                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>

                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Last Name</label>
                                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>

                                                </div>
                                            </div>

                                        </div>
                                        <!--/row-->
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Gender</label>
                                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Date of Birth</label>
                                                    <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" TextMode="Date" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <!--/row-->
                                        <div class="row" id="UserPwd" runat="server" visible="true">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Password</label>
                                                    <asp:TextBox ID="txtPwd" runat="server" placeholder="Password" class="form-control" TextMode="Password"></asp:TextBox>
                                                </div>
                                                <span>
                                                    <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txtPwd" ControlToValidate="txtCPwd" ErrorMessage="Your passwords do not match!" Display="Dynamic" ForeColor="#cc3300" />
                                                </span>
                                            </div>
                                            <!--/span-->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Confirm Password</label>
                                                    <asp:TextBox ID="txtCPwd" runat="server" placeholder="Confirm Password" class="form-control" TextMode="Password"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!--/span-->
                                        </div>
                                        <!--/row-->

                                        <div class="row">
                                            <div class="col-md-6 ">
                                                <div class="form-group">
                                                    <label>Email ID</label>
                                                    <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-6 ">
                                                <div class="form-group">
                                                    <label>Mobile No</label>
                                                    <asp:TextBox ID="txtPhoneNo" runat="server" Class="form-control" placeholder="Mobile No" TextMode="Phone" MaxLength="10"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                             <div class="col-md-6 ">
                                                <div class="form-group">
                                                    <label>Exam Name</label>
<asp:DropDownList ID="ddlExamList" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                              <div class="col-md-3 ">
                                                <div class="form-group">
                                                    <label>Pratice</label>
<asp:CheckBox ID="chkPratice" runat="server" CssClass="form-control" OnCheckedChanged="PraticeMethod" AutoPostBack="true" />
                                                </div>
                                            </div>
                                               <div class="col-md-3 ">
                                                <div class="form-group">
                                                    <label>Admin Group</label>
<asp:CheckBox ID="chhkAdminGroup" runat="server" CssClass="form-control" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="form-actions right">
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn default" Text="Cancel" OnClick="Cancel" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn blue" OnClick="Save" />

                                    </div>


                                    <!-- END FORM-->




                                </div>
                            </div>
                        </div>
                         <!-- Grid Values -->      
                        <asp:Panel ID="pnlUser" runat="server" ScrollBars="Auto">
                          <asp:GridView ID="GrdUserMaster" runat="server" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GrdUserMaster_PageIndexChanging" PagerSettings-Mode="Numeric" PageSize="10">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProgramsID" runat="server" Text='<%# Eval("User_Code") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField Visible="true" HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" OnClick="Update"><img src="FBNPC/images/edit.png" width="20px" alt="" /></asp:LinkButton>&nbsp;
                                        <asp:LinkButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" OnClick="Delete" > <img src="FBNPC/images/delete.png" width="20px" alt="" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitleName" runat="server" Text='<%# Eval("First_Name") %>' ></asp:Label>
                                        <asp:Label ID="lbllasteName" runat="server" Text='<%# Eval("Last_Name") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Email ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("E_mail") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Phone No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("Phone") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Exam Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExamName" runat="server" Text='<%# Eval("Exam") %>' ></asp:Label>
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
                            </asp:Panel>                                
                        <!-- Grid Values -->  
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
                                        <strong>KSap Creations</strong> - Copyright &copy; 2018
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div> <!-- end footer -->

                
                <!-- End #page-right-content -->

                <div class="clearfix"></div>

            
        </form>
</asp:Content>
