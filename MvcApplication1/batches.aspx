﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="batches.aspx.cs" Inherits="MvcApplication1.batches" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>:: Future Building Nursing Prep Center ::</title>
    <meta name="description" content="">
<meta content="yes" name="apple-mobile-web-app-capable" />
<meta name="viewport" content="minimum-scale=1.0, width=device-width, maximum-scale=1, user-scalable=no" />

<!--=================================
Style Sheets
=================================-->
<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700,800' rel='stylesheet' type='text/css'>  
    
<link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="assets/css/flexslider.css">
<link rel="stylesheet" type="text/css" href="assets/css/animations.css">
<link rel="stylesheet" type="text/css" href="assets/css/font-awesome.min.css">
<link rel="stylesheet" type="text/css" href="assets/css/jquery.flickr.css">
<link rel="stylesheet" type="text/css" href="assets/css/prettyPhoto.css">
<link rel="stylesheet" href="assets/css/main.css">
    <link href="Admin/FBNPC/css/components-rounded.css" rel="stylesheet" />
<script src="assets/js/lib/modernizr-2.6.2-respond-1.1.0.min.js"></script>
    <link rel="shortcut icon" href="assets/demo-data/logoTitle.png">
          <script type="text/javascript">
              document.addEventListener("contextmenu", function (e) {
                  e.preventDefault();
              }, false);
    </script>
</head>
<body style="background-color:white;">
<div class="offsetWrap">
    <form id="form1" runat="server">
    <div class="offsetMaker"> 
        
        <header class="bg-white doc-header">
            <div class="head-contact clearfix">
            <div class="container">
                <ul class="nav-top pull-left">
                    <li><a href="Exam/RegistrationForm.aspx" class="appointment">Register Now</a></li>
                    <li><a href="LoginIn.aspx">My Account</a></li>                 
                </ul>

                <ul class="contact pull-right">
                    <li><a href="#"><i class="fa fa-phone"></i>(306) 316-0411</a></li>
                    <li><a href="mailto:feedback@fbnpc.com"><i class="fa fa-envelope"></i>Feedback@fbnpc.com</a></li>
                </ul>

            </div>
            </div>

            
            <nav id="sticktop">
             <div class="container">
                
                    <a href="default.aspx" class="text-left logo"><img src="assets/demo-data/Logo_fbnpc_new.png" alt=""></a>
                    <ul class="socials">
<li><a href="https://www.facebook.com/yourdoorstp/" class="fb" target="_blank"><i class="fa fa-facebook-f"></i></a></li>
                        <li><a href="#" class="twitter"><i class="fa fa-twitter"></i></a></li>
                    </ul>
                    <a href="#" class="nav-triger"><span class="fa fa-navicon"></span></a>
                    <ul class="main-menu">
                        <li><a href="Default.aspx">Home</a></li>
                        <li><a href="about.aspx">About Us</a></li>
                        <li><a href="#">Blog</a></li>
                       
                       <li class="parent"><a href="#">Our Programs</a>  
                           <ul>
                               <asp:DataList ID="DLMenu" runat="server" RepeatColumns="1" RepeatDirection="Horizontal">
                               <ItemTemplate>                                   
                                           <li>
                                             <asp:LinkButton ID="lnk" runat="server" onclick="EditShow">
                                                   <asp:Label ID="lblMenu" runat="server" Style="padding:5px 15px; display: block;font-weight: 400;" Text='<%#Eval("TitleName")%>'></asp:Label>
                                                  <asp:Label ID="lblID" runat="server" Text='<%#Eval("ProgramsID")%>' Visible="false"></asp:Label>
                                               </asp:LinkButton></li>
                                     
                               </ItemTemplate>
                           </asp:DataList>
                           </ul>                        
                       </li>
                        <li class="active"><a href="batches.aspx">Batches</a></li>
                        <li><a href="StudyMaterial.aspx">Study Materials</a></li>
                        <li><a href="gal.aspx">Our Gallery</a></li>
                        <li><a href="contact.aspx">Contact</a></li>
                        
                    </ul>
                </div>
            </nav>
        </header>
        
        <div class="head pt-30 pb-20">
            <div class="container">
                <ul class="bread-crumb">
                    <li><a href="default.aspx">Home</a></li>
                    <li><a href="#">Batches</a></li>
                </ul>
                
            </div>
        </div>

        <section>
        <div class="container">
            <div class="row">
                <div class="col-sm-4 col-md-4" >
                    <div style="background-color:#0066ff;color:white;height: 35px;text-align:center;padding-top: 8px;">
                        <b> Select Option</b>
                    </div><br />
                    <div>                        
                        <asp:DropDownList ID="ddlBatch" runat="server" CssClass="form-control" Width="300px"></asp:DropDownList>
                    </div>
                    <div style="padding-top:10px; padding-bottom:20px;">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="Search" OnClick="Search" />&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Reset" OnClick="Reset" />
                    </div>
                </div>
                
                <div class="col-sm-8 col-md-8">
                    <asp:GridView ID="GrdBatch" runat="server" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" PagerSettings-Mode="Numeric" PageSize="10">
                        <Columns>
                            <asp:TemplateField HeaderText="Batch Name" HeaderStyle-BackColor="#0066ff" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblBatchName" runat="server" Text='<%# Eval("BatchName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch" HeaderStyle-BackColor="#0066ff" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BranchName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Caurse" HeaderStyle-BackColor="#0066ff" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblCaurse" runat="server" Text='<%# Eval("Course") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date" HeaderStyle-BackColor="#0066ff" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblbatchDate" runat="server" Text='<%# Eval("batchDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time" HeaderStyle-BackColor="#0066ff" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartTime" runat="server" Text='<%# Eval("StartTime") %>'></asp:Label>--
                                        <asp:Label ID="lblEndTime" runat="server" Text='<%# Eval("EndTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
                                     
                    
        </div>
    </section>

         

        <footer class="bg-white pt-35">
            <div class="container">
                <div class="row">
                    <div class="col-sm-6 mt-40">
                        <h6 class="text-bold text-uppercase after-left-s pb-20 mb-20">Words from our Acheivers</h6>
         <object data="https://www.youtube.com/embed/LCt3Hypz9aE"
   width="450" height="250"></object>
                        </div>
                    <div class="col-sm-4 mt-40 recent-posts">
                        <h6 class="text-bold text-uppercase after-left-s pb-20 mb-20">Recent posts</h6>
                        <div class="fb-page" data-href="https://www.facebook.com/yourdoorstp/" data-tabs="timeline" data-width="450" data-height="250" data-small-header="true" data-adapt-container-width="false" data-hide-cover="true" data-show-facepile="false"><blockquote cite="https://www.facebook.com/yourdoorstp/" class="fb-xfbml-parse-ignore"><a href="https://www.facebook.com/yourdoorstp/">Future Building Nursing Prep Centre</a></blockquote></div>
                    </div>
                    
                </div>
                <div class="rights mt-60 pt-15 pb-10">
                   Made by <a href="http://www.ksapcn.com" target="_blank">KSap Creation</a> &copy;
                </div>
            </div>
        </footer>
        
    </div>
    
</div>

<!--=================================
Script Source
=================================-->

<script src="assets/js/lib/jquery.js"></script>
<script src="assets/js/lib/css3-animate-it.js"></script>
<script src="assets/js/lib/jquery.flexslider-min.js"></script>
<script src="assets/js/lib/jquery.sticky.js"></script>
<script src="assets/js/lib/jquery.waitforimages.js"></script>
<script src="assets/js/lib/jflickrfeed.min.js"></script>
<script src="assets/js/lib/jquery.prettyPhoto.js"></script>
<script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
<script src="assets/js/app/main.js"></script>
    <div id="fb-root"></div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = 'https://connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.11';
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
    </form>
</body>
</html>
