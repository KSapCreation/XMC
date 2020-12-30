
<%@ Page Title="" Language="C#" MasterPageFile="~/Exam/Exam.Master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="MvcApplication1.Exam.Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <meta charset="utf-8"/>
<title>:: FBNPC ::</title>
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
          .ColectionPage {
        background-color: rgb(76, 165, 232);
        border-radius: 10px;
    height: 27px;
    text-align: center;
    margin-bottom:10px;        
    padding-top: 5px;
       }
   </style>

    <script type="text/javascript">
        $("[id*=btnSave]").click(function () {
            var checked_checkboxes = $("[id*=blockui_sample_1_portlet_body] input:checked");
            var message = "";
            if (checked_checkboxes.length == 0) {
                alert("Atleast one check box need to select");
            }
            checked_checkboxes.each(function () {
                var value = $(this).val();

            });

            alert(message);
        });
    </script>

      <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        });
</script>

  <script type="text/javascript">
           document.addEventListener("contextmenu", function (e) {
               e.preventDefault();
           }, false);
    </script>
   
<script type='text/javascript'>
    document.onkeydown = function (e) {
        var key = e.charCode || e.keyCode;
        if (key == 13) {
            // enter key do nothing
        } else {
            e.preventDefault();
        }
    }
</script>
    <style>
        .blink{
		width:200px;
		height: 10px;
	   text-align: center;		
	}
	span{
		color: black;
		animation: blink 1s linear infinite;
	}
        .loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url('images/loader.gif') 50% 50% no-repeat rgb(249,249,249);
            opacity: .8;
        }

    </style>
    <link rel="stylesheet" href="TimerCounter/css/styles.css" />
        <link rel="stylesheet" href="TimerCounter/countdown/jquery.countdown.css" />
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-content">
        <div class="container">
           
          
     <% if (blExamDocType)
         { %>

            <div class="row">
               
                <div class="col-sm-3">
                    <div class="CategoryPage">
                        <asp:LinkButton ID="lnkCategory" runat="server" ForeColor="White">Listening Video</asp:LinkButton>
                        <asp:Label ID="lblcount1" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="CategoryPage">
                        <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White">Reading</asp:LinkButton>
                        <asp:Label ID="lblcount2" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="CategoryPage">
                        <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="White">Writing</asp:LinkButton>
                        <asp:Label ID="lblcount3" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="CategoryPage">
                        <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="White">Listening Audio</asp:LinkButton>
                        <asp:Label ID="lblcount4" runat="server" Visible="false"></asp:Label>

                    </div>
                </div>
            </div>

            <div class="row">
               
                <div class="col-sm-3">
                    <div class="ColectionPage">
                        <asp:Label ID="lblSpeakingMsg" runat="server" Visible="false" ForeColor="White" CssClass="blink"></asp:Label>
                        <asp:DataList ID="DlSpeaking" runat="server" RepeatDirection="Vertical" RepeatLayout="Table" RepeatColumns="15" CellPadding="200">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("VideoID")%>' Visible="false"></asp:Label><span style="color: white;">-</span>
                                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="ShowSpeaking" Style="border-width: 1px; border-style: Solid; border-radius: 10px; font-weight: 600; border-color: white;">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("num")%>' ForeColor="White"></asp:Label>
                                </asp:LinkButton>

                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="ColectionPage">
                        
                        <asp:DataList ID="DLReading" runat="server" RepeatDirection="Vertical" RepeatLayout="Table" RepeatColumns="15" CellPadding="200">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ComprehensionID")%>' Visible="false"></asp:Label><span style="color: white;">-</span>
                                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="ShowReading" Style="border-width: 1px; border-style: Solid; border-radius: 10px; font-weight: 600; border-color: white;">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("num")%>' ForeColor="White"></asp:Label>
                                </asp:LinkButton>

                            </ItemTemplate>
                        </asp:DataList>
                            
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="ColectionPage">
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="ColectionPage">
                        <asp:Label ID="lblListeningMsg" runat="server" Visible="false" ForeColor="White" class="blink"></asp:Label>
                        <asp:DataList ID="DlListening" runat="server" RepeatDirection="Vertical" RepeatLayout="Table" RepeatColumns="15" CellPadding="200">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("AVID")%>' Visible="false"></asp:Label><span style="color: white;">-</span>
                                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="ShowListening" Style="border-width: 1px; border-style: Solid; border-radius: 10px; font-weight: 600; border-color: white;">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("num")%>' ForeColor="White"></asp:Label>
                                </asp:LinkButton>

                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>

              <%    } %>
              
            

       <% else
                { %>

          
            <div class="row">
           
                <div class="col-sm-12">
                    <div class="CategoryPage">
                        <asp:LinkButton ID="LinkButton5" runat="server" ForeColor="White">Individual</asp:LinkButton>
                        <asp:Label ID="Label3" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
               
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="ColectionPage" style="height:160px;">
                        <asp:Label ID="Label2" runat="server" Visible="false" ForeColor="White" CssClass="blink"></asp:Label>
                        <asp:Panel ID="pnl" runat="server" ScrollBars="Horizontal" Height="160px" >
                            <asp:DataList ID="DlIndividual" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" RepeatColumns="34" CellPadding="200">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("QuestionID")%>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="ShowIndividualQuestion" Style="border-color: white; margin-left: 5px; margin-right: 5px; margin-bottom: 8px;">
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("num")%>' ForeColor="White"></asp:Label>
                                    </asp:LinkButton>

                                </ItemTemplate>
                            </asp:DataList>
                        </asp:Panel>
                    </div>
                </div>

            </div>

            

            <% } %>

            <div class="row">

                <div class="col-sm-4" id="multiplediv" runat="server">
                    <div class="portlet light">
                        <asp:DataList ID="DlAudioSection" runat="server" RepeatDirection="Horizontal" RepeatColumns="1">
                            <ItemTemplate>
                                <audio controls controlslist="nodownload">
                                    <source src='<%# Eval("AVId", "File.ashx?Id={0}") %>' />                                   
                                </audio>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:DataList ID="DLVideoSection" runat="server" RepeatDirection="Horizontal" RepeatColumns="1">
                            <ItemTemplate>
        <%--                        <video width="300" controls="controls" class="video-playing">
  <source src='<%# "http://www.youtube.com/watch?v=" + Eval("FileName") %>' type="video/mp4">  
</video>--%>
                                <embed width="300" height="200" src='<%# "https://www.youtube.com/embed/" + Eval("FileName") %>' frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></embed>
                            </ItemTemplate>
                        </asp:DataList>

                        <asp:Panel ID="pnlComprehsion" runat="server" ScrollBars="Auto">
                            <asp:DataList ID="DLComprehension" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Height="50px">
                                <ItemTemplate>
                                    <asp:Label ID="lblComprehsion" runat="server" Text='<%#Eval("ComprehensionDesc")%>' Height="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:DataList>
                        </asp:Panel>
                    </div>
                </div>

                <div class="col-md-8" id="DivQuestion_DocType" runat="server">
                    <div class="portlet light">

                        <asp:Label ID="lblAllID" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblPaperID" runat="server" Visible="false"></asp:Label>
                        <asp:Panel ID="pnQuestion" runat="server" ScrollBars="Auto">
                           <h3> Question No: <b><asp:Label ID="lblQusNo" runat="server"></asp:Label></b></h3>
                            <asp:DataList ID="ddlExamQuestion" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%" Height="400">
                                <ItemTemplate>
                                    <div class="portlet-title" style="border: 1px solid #4ca5e8;">
                                        <p style="margin: 10px 15px 10px 20px;">
                                            <asp:Label ID="lblQuestionID" runat="server" Text='<%#Eval("QuestionID")%>' Visible="false"></asp:Label>
                                            <span><b>
                                                <asp:Label ID="lblCount" runat="server" Text='<%#Eval("num")%>' Visible="false"></asp:Label></b></span>
                                            <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question")%>'></asp:Label>
                                        </p>


                                    </div>
                                    <div class="portlet-body" id="blockui_sample_1_portlet_body">
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <p style="padding-left: 1%;">
                                                    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="QusAns" Text='<%#Eval("OptionOne")%>' Style="background-color: snow; color: black;" />
                                                </p>
                                            </div>
                                            <div class="col-sm-6">
                                                <p style="padding-left: 1%;">
                                                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="QusAns" Text='<%#Eval("OptionTwo")%>' Style="background-color: snow; color: black;" />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <p style="padding-left: 1%;">
                                                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="QusAns" Text='<%#Eval("OptionThree")%>' Style="background-color: snow; color: black;" />

                                                </p>
                                            </div>
                                            <div class="col-sm-6">
                                                <p style="padding-left: 1%;">
                                                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="QusAns" Text='<%#Eval("OptionFour")%>' Style="background-color: snow; color: black;" />
                                                </p>
                                            </div>
                                        </div>


                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                            
                        </asp:Panel>
                    </div>


                </div>


            </div>

            <div class="row" id="StartPageDiv" runat="server" visible="true" style="padding-bottom: 180px;">
                <h1>Kindly select any one section to start Exam. FBNPC</h1>
            </div>
                <div class="row" id="ContactDiv" runat="server" visible="false" style="padding-bottom: 180px;">
                <h1>Please, Contact to FBNPC for New Exam.</h1>
            </div>

            <div class="row" id="ThankuSubmit" runat="server" visible="false" style="padding-bottom: 140px;">
                <h1>Thanks for Submit,Kindly select any other section/questions to Continue Exam. FBNPC</h1>
            </div>

            <div class="row" id="SaveDiv" runat="server" visible="false">
                <div class="form-actions" style="margin-left: 35%;">
                    <asp:Button ID="btnPre" runat="server" Text="Previous" CssClass="btn green " OnClick="TempPrevious" />
                    <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn yellow-casablanca" OnClick="TempSaveExam" />
                    <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="btn blue" OnClick="SubmitExam" />
                    <asp:Button ID="btnLogOff" runat="server" Text="Log Off" CssClass="btn btn-danger" OnClick="LogOff" />
                </div>
            </div>
           


        </div>
    </div>
	<div class="loader"></div>
     <asp:Timer runat="server" id="UpdateTimer" interval="5000" ontick="UpdateTimer_Tick" />
        <asp:UpdatePanel runat="server" id="TimedPanel" updatemode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="UpdateTimer" eventname="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label runat="server" id="SessionExpireStop" Visible="false" />
            </ContentTemplate>
        </asp:UpdatePanel>
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
