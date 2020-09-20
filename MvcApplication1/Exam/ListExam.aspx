<%@ Page Title="" Language="C#" MasterPageFile="~/Exam/Student.Master" AutoEventWireup="true" CodeBehind="ListExam.aspx.cs" Inherits="MvcApplication1.Exam.ListExam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <meta charset="utf-8"/>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="profile-content">
          <div class="row">
                            <div class="col-sm-12">
                                <asp:Panel ID="pnl" runat="server" ScrollBars="Both">
                                <asp:DataList ID="dlExamList" runat="server" RepeatColumns="4">
                                    <ItemTemplate>
                                        <div class="top-news">
                                            <asp:LinkButton ID="lnkGet" runat="server" CssClass="btn green" OnClick="GetExam">                                            
                                              <%--  <span> <asp:Label ID="lblCount" runat="server" Text='<%#Eval("num")%>' Visible="false"></asp:Label> </span>--%>
                                                <em>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("First_NAME")%>'></asp:Label>
                                                </em>
                                                <em>
                                                    <i class="fa fa-tags"></i>
                                                     <asp:Label ID="lblExamID" runat="server" Text='<%#Eval("ExamCode")%>' Visible="false"></asp:Label> </em>
                                                    Exam Name <asp:Label ID="lblName" runat="server" Text='<%#Eval("ExamName")%>'></asp:Label> </em>
                                                  <em>
                                                    <i class="fa fa-tags"></i>
                                                    Description <asp:Label ID="Label2" runat="server" Text='<%#Eval("Exam Description")%>'></asp:Label> </em>
                                                <i class="fa fa-graduation-cap top-news-icon"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </ItemTemplate>                              
                                    </asp:DataList>
                                    </asp:Panel>
                            </div>
                        </div>
        </div>
</asp:Content>
