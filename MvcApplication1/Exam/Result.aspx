<%@ Page Title="" Language="C#" MasterPageFile="~/Exam/Student.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="MvcApplication1.Exam.Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>:: FBNPC || Student ::</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1.0" name="viewport"/>
<meta http-equiv="Content-type" content="text/html; charset=utf-8">
<meta content="" name="description"/>
<meta content="" name="author"/>
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css">
<link href="plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
<link href="plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css">
<link href="plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css">
<link href="plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css">
<!-- END GLOBAL MANDATORY STYLES -->
        
<!-- BEGIN PAGE LEVEL STYLES -->
<link href="plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.css" rel="stylesheet" type="text/css"/>
<link href="plugins/fancybox/source/jquery.fancybox.css" rel="stylesheet"/>
<!-- BEGIN:File Upload Plugin CSS files-->
<link href="plugins/jquery-file-upload/blueimp-gallery/blueimp-gallery.min.css" rel="stylesheet"/>
<link href="plugins/jquery-file-upload/css/jquery.fileupload.css" rel="stylesheet"/>
<link href="global/plugins/jquery-file-upload/css/jquery.fileupload-ui.css" rel="stylesheet"/>
<!-- END:File Upload Plugin CSS files-->
<!-- END PAGE LEVEL STYLES -->
<!-- BEGIN PAGE LEVEL STYLES -->
<link href="Pages/css/profile.css" rel="stylesheet" type="text/css"/>
    <link href="Pages/css/tasks.css" rel="stylesheet" type="text/css"/>
<!-- END PAGE LEVEL STYLES -->
<!-- BEGIN THEME STYLES -->
<link href="css/components-rounded.css" id="style_components" rel="stylesheet" type="text/css">
<link href="css/plugins.css" rel="stylesheet" type="text/css">
<link href="css/layout.css" rel="stylesheet" type="text/css">
<link href="css/themes/default.css" rel="stylesheet" type="text/css" id="style_color">
<link href="css/custom.css" rel="stylesheet" type="text/css">
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="../assets/demo-data/Logo_fbnpc_new.png"/>
       <script type='text/javascript'>
           xAddEventListener(window, 'load',
               function () { new xTableHeaderFixed('GrdCategory', 'form-body', 0); }, false);
    </script>
      <style type="text/css">
.highlight {text-decoration: none;color:black;background:yellow;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     	<!-- BEGIN PROFILE CONTENT -->
 
					<div class="profile-content">
                        <div class="row">
                              <div class="col-sm-4">
                                <asp:DropDownList ID="ddlExamName" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Searching...."></asp:TextBox>
                            </div>                          
                            <div class="col-sm-4">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-circle" Text=">>>>>" OnClick="Search" />
                                <asp:Button ID="btnReset" runat="server" CssClass="btn btn-arrow-link" Text="Reset" OnClick="Reset" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <p>Total Questions - <asp:Label ID="lblTotalQus" runat="server"></asp:Label></p>
                            </div>
                            <div class="col-md-4">
                                <p>Total Correct Ans - <asp:Label ID="lblCorrect" runat="server"></asp:Label></p>
                            </div>
                            <div class="col-md-4">
                                <p>Total Wrong Ans - <asp:Label ID="lblWrong" runat="server"></asp:Label></p>
                            </div>
                        </div>
						<div class="row">
							<div class="col-md-12">
								<!-- BEGIN PORTLET -->
								<div class="tab-pane" id="Userinfo" runat="server" visible="true">
                                <div class="portlet box blue">
                                     <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Results
                                            </div>
                                        </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                       
                                        <div class="form-body">
                                            <asp:Panel ID="pnl" runat="server" ScrollBars="Auto" Height="400px">
                                            <asp:GridView ID="GrdCategory" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" >
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Question">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTitleName" runat="server" Text='<%# HighlightText(Eval("Question").ToString()) %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Student Answer">
                                                        <ItemTemplate>
                                                            <asp:Label ID="StudentAns" runat="server" Text='<%# Eval("StudentAns") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderImageUrl="~/Exam/img/tick.png" ControlStyle-Width="20px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCorrect" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="CorrectAns" runat="server" Text='<%# Eval("Correct Ans") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lbl" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                  
                                                </Columns>
                                            </asp:GridView>  
                                                </asp:Panel>
                                        </div>
                                       
                                    </div>
                                </div>
                            </div>
								<!-- END PORTLET -->
							</div>
							
						</div>
						
					</div>
					<!-- END PROFILE CONTENT -->
</asp:Content>
