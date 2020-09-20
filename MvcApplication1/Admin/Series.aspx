<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FBNPC.Master" AutoEventWireup="true" CodeBehind="Series.aspx.cs" Inherits="MvcApplication1.Admin.Series" %>
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
    <script type = "text/javascript">

        function RadioCheck(rb) {

            var gv = document.getElementById("<%=GrdCategory.ClientID%>");

         var rbs = gv.getElementsByTagName("input");



         var row = rb.parentNode.parentNode;

         for (var i = 0; i < rbs.length; i++) {

             if (rbs[i].type == "radio") {

                 if (rbs[i].checked && rbs[i] != rb) {

                     rbs[i].checked = false;

                     break;

                 }

             }

         }

     }

</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>

                    <div class="container">    
                                                             
                            <div class="tab-pane" id="Userinfo" runat="server" visible="true">
                                <div class="portlet box blue">
                                     <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Paper Set
                                            </div>
                                        </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                       
                                        <div class="form-body">
                                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div>
                                                        <label class="control-label">Subject</label>
                                                       <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                 <div class="col-md-4">
                                                    <div>
                                                        <label class="control-label">Section</label>
                                                       <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div>
                                                        <label class="control-label">Exam Name</label>
                                                        <asp:DropDownList ID="ddlExamName" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                           <div class="row">
                                               <div class="col-sm-6">
                                                    <label class="control-label">Audio Video Section</label>
                                                   <asp:Panel ID="pnlAV" runat="server" ScrollBars="Auto" Height="300">
                                                   <asp:GridView ID="GrdCategory" runat="server" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-striped table-bordered table-hover">
                                                       <Columns>
                                                           <asp:TemplateField Visible="false">
                                                               <ItemTemplate>
                                                                   <asp:Label ID="lblProgramsID" runat="server" Text='<%# Eval("AVID") %>' Visible="false"></asp:Label>
                                                               </ItemTemplate>
                                                           </asp:TemplateField>
                                                            <asp:TemplateField Visible="true" HeaderText="Select">
                                                                   <ItemTemplate>
                                                                       <asp:RadioButton ID="RbtnSelect" runat="server" onclick = "RadioCheck(this);" />
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Audio/Video Name">
                                                               <ItemTemplate>
                                                                   <asp:Label ID="lblTitleName" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                                               </ItemTemplate>
                                                           </asp:TemplateField>
                                                       </Columns>
                                                   </asp:GridView> 
                                                       </asp:Panel>
                                               </div>
                                               <div class="col-sm-6">
                                                   <label class="control-label">Question Section</label>
                                                   <asp:Panel ID="pnlQuestion" runat="server" ScrollBars="Auto" Height="300">
                                                       <asp:GridView ID="GRdQuestion" runat="server" AutoGenerateColumns="false" AllowPaging="false" CssClass="table table-striped table-bordered table-hover">
                                                           <Columns>
                                                               <asp:TemplateField Visible="false">
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="lblQuestionID" runat="server" Text='<%# Eval("QuestionID") %>' Visible="false"></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                                 <asp:TemplateField Visible="true" HeaderText="Select">
                                                                   <ItemTemplate>
                                                                       <asp:CheckBox ID="chkSelect" runat="server" />
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="Question">
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="lblTitleName" runat="server" Text='<%# Eval("Question") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                               </asp:TemplateField>
                                                           </Columns>
                                                       </asp:GridView>
                                                   </asp:Panel>
                                               </div>
                                           </div>
                                           
                                        </div>
                                        <div class="form-actions right">
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn default" Text="Cancel" OnClick="Cancel" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn blue" OnClick="Save"  />
                                            <asp:Button ID="btnPost" runat="server" Text="Post" CssClass="btn blue"  />

                                        </div>
                                    </div>
                                </div>
                            </div>      
                     
                    </div>
                    <!-- end container -->
                   

              

                <div class="clearfix"></div>

            
        </form>
</asp:Content>
