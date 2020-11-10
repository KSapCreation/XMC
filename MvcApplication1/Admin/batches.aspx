<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FBNPC.Master" AutoEventWireup="true" CodeBehind="batches.aspx.cs" Inherits="MvcApplication1.Admin.batches" ValidateRequest="false" %>
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
        <!-- Bootstrap core CSS -->
        <link href="FBNPC/css/bootstrap.min.css" rel="stylesheet">
        <!-- Icons CSS -->
        <link href="FBNPC/css/icons.css" rel="stylesheet">
        <!-- Custom styles for this template -->
        <link href="FBNPC/css/style.css" rel="stylesheet">
    <title>:: FBNPC BATCHES ::</title>
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
                                                <i class="fa fa-gift"></i>Batches
                                            </div>
                                        </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                       
                                        <div class="form-body">
                                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div>
                                                        <label class="control-label">Branch Name</label>
                                                        <asp:TextBox ID="txtbranch" runat="server" CssClass="form-control" placeholder="Branch Name" Text="Regina" Enabled="false"> </asp:TextBox>

                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div>
                                                        <label class="control-label">Batch Name</label>
                                                        <asp:TextBox ID="txtbatch" runat="server" CssClass="form-control" placeholder="Batch Name"> </asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div>
                                                        <label class="control-label">Course</label>
                                                        <asp:TextBox ID="txtCourse" runat="server" CssClass="form-control"></asp:TextBox>

                                                    </div>
                                                </div>
                                                    <div class="col-md-6">
                                                    <div>
                                                        <label class="control-label">Date</label>
                                                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div>
                                                        <label class="control-label">Start Time</label>
                                                        <asp:TextBox ID="txtStart" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>

                                                    </div>
                                                </div>
                                                    <div class="col-md-6">
                                                    <div>
                                                        <label class="control-label">End Time</label>
                                                        <asp:TextBox ID="txtEnd" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div>
                                                        <label class="control-label">Is Active</label>
                                                        <asp:CheckBox ID="chkVisible" runat="server" CssClass="form-control" />
                                                    </div>
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
                          <asp:GridView ID="GrdBatch" runat="server" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GrdBatch_PageIndexChanging" PagerSettings-Mode="Numeric" PageSize="10">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProgramsID" runat="server" Text='<%# Eval("BatchID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField Visible="true" HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" OnClick="Update" ><img src="FBNPC/images/edit.png" width="20px" alt="" /></asp:LinkButton>&nbsp;&nbsp;
                                        <asp:LinkButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" OnClick="Delete" > <img src="FBNPC/images/delete.png" width="20px" alt="" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Batch Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBatchName" runat="server" Text='<%# Eval("BatchName") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Branch">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BranchName") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Caurse">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCaurse" runat="server" Text='<%# Eval("Course") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblbatchDate" runat="server" Text='<%# Eval("BDate") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Start Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartTime" runat="server" Text='<%# Eval("StartTime") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="End Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndTime" runat="server" Text='<%# Eval("EndTime") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Active">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("Active") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                            
                              
                            </Columns>
                        </asp:GridView>  
                    </div>
                    <!-- end container -->
                

              

                <div class="clearfix"></div>

            
        </form>
</asp:Content>
