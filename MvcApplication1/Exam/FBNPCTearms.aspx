<%@ Page Title="" Language="C#" MasterPageFile="~/Exam/Exam.Master" AutoEventWireup="true" CodeBehind="FBNPCTearms.aspx.cs" Inherits="MvcApplication1.Exam.FBNPCTearms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
<link href="Pages/css/inbox.css" rel="stylesheet" type="text/css"/>
<!-- END PAGE LEVEL STYLES -->
<!-- BEGIN THEME STYLES -->
<link href="css/components-rounded.css" id="style_components" rel="stylesheet" type="text/css">
<link href="css/plugins.css" rel="stylesheet" type="text/css">
<link href="css/layout.css" rel="stylesheet" type="text/css">
<link href="css/themes/default.css" rel="stylesheet" type="text/css" id="style_color">
<link href="css/custom.css" rel="stylesheet" type="text/css">
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="favicon.ico"/>
   <style>
       .CategoryPage {
        background-color: rgb(76, 165, 232);
        border-radius: 10px;
    height: 27px;
    text-align: center;
    margin-bottom:10px;        
    padding-top: 5px;
       }
       .CategoryPage :hover {
        background-color: #333333;           
       }
   </style>
       <script type="text/javascript">
           document.addEventListener("contextmenu", function (e) {
               e.preventDefault();
           }, false);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content">
		<div class="container">
            <div class="row">
                <h4>
               <asp:Label ID="lblCondition" runat="server"></asp:Label></h4>
            </div>
            <div class="row">
                <asp:CheckBox ID="chkCondition" runat="server" CssClass="form-control" Text="I ACKNOWLEDGE AND CONFIRM THAT I HAVE READ, UNDERSTAND AND ACCEPT THE ABOVE TERMS AND CONDITIONS." />
                
            </div><br />
            <div class="row">
                 <div class="col-sm-2">
                    <asp:Button ID="btnGo" runat="server" CssClass="btn btn-danger" Text="Start Exam" OnClick="btnStart" />
                </div>
            </div>   
               
		</div>
	</div>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            Demo.init(); // init demo features
            Inbox.init();
        });
</script>
</asp:Content>
