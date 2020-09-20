<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FBNPC.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MvcApplication1.Admin.About" ValidateRequest="false" %>
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
    <title>:: FBNPC About ::</title>
    <script type="text/javascript" src="tiny_mce/tiny_mce.js"></script>
     <script type="text/javascript" language="javascript">
         tinyMCE.init({
             // General options
             mode: "textareas",
             theme: "simple",
             plugins: "pagebreak,style,layer,table,save,advhr,advlink,emotions,iespell",

         });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id ="form1" runat="server">
        <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>
        


                    <div class="container">
                      
                        <div class="tab-pane" id="Userinfo" runat="server" visible="true">
                            <div class="portlet box blue">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-gift"></i>About
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->

                                    <div class="form-body">
                                       <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group has-error">
                                                    <label class="control-label">Company Name</label>
                                                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" text="FBNPC" ReadOnly="true"></asp:TextBox>

                                                </div>
                                            </div>     
                                             <div class="col-md-6">
                                                <div class="form-group has-error">
                                                    <label class="control-label">Category</label>
                                                    <asp:TextBox ID="txtCtaegory" runat="server" CssClass="form-control" ></asp:TextBox>

                                                </div>
                                            </div>                                         

                                        </div>
                                        <div class="row">
                                             <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label">Description</label>
                                                    <asp:TextBox ID="txtCompanyDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200px"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <!--/row-->
                                       
                                    <div class="form-actions right">
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn default" Text="Cancel" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn blue" OnClick="Save" />

                                    </div>

                                        </div>
                                    <!-- END FORM-->
                                     <asp:GridView ID="GrdAbout" runat="server" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GrdAbout_PageIndexChanging" PageSize="10">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProgramsID" runat="server" Text='<%# Eval("CompanyID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField Visible="true" HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" OnClick="Update"><img src="FBNPC/images/edit.png" width="20px" alt="" /></asp:LinkButton>&nbsp;&nbsp;
                                        <asp:LinkButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" OnClick="Delete"> <img src="FBNPC/images/delete.png" width="20px" alt="" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Company Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitleName" runat="server" Text='<%# Eval("CompanyName") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("Category") %>' ></asp:Label>
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
                                        <strong>Sap Creations</strong> - Copyright &copy; 2018
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div> <!-- end footer -->

                
                <!-- End #page-right-content -->

                <div class="clearfix"></div>

            
        </form>
</asp:Content>
