<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="MvcApplication1.Information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
       <title>:: Future Building Nursing Prep Center ::</title>
    <meta name="description" content="">
<meta content="yes" name="apple-mobile-web-app-capable" />
<meta name="viewport" content="minimum-scale=1.0, width=device-width, maximum-scale=1, user-scalable=no" />

<!--=================================
Style Sheets
=================================-->
<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700,800' rel='stylesheet' type='text/css'>  
    <link href="assets/css/style.css" rel="stylesheet" />
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
<body >
<div class="offsetWrap">
    
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
              <%--          <li><a href="batches.aspx">Batches</a></li>
                        <li><a href="StudyMaterial.aspx">Study Materials</a></li>--%>
                        <li><a href="OurAchiever.aspx">Our Achiever</a></li>
                        <li><a href="gal.aspx">Our Gallery</a></li>
                        <li><a href="contact.aspx">Contact</a></li>
                        
                    </ul>
                </div>
            </nav>
        </header>
        

        <section>
        <div class="container">
          
                        <asp:DataList ID="dlOthers" runat="server" RepeatColumns="1" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-sm-11">
                                        <div class="portlet light bg-inverse">
                                            <div class="portlet-title">
                                                <div class="caption font-purple-plum">
                                                    <i class="icon-speech font-purple-plum"></i>
                                                    <span class="caption-subject bold uppercase">
                                                        <asp:Label ID="lblTitleName" runat="server" Text='<%#Eval("TitleName")%>'></asp:Label></span>

                                                </div>
                                                <div class="actions">
                                                    <a class="btn btn-circle btn-icon-only btn-default" href="javascript:;">
                                                        <i class="icon-cloud-upload"></i>
                                                    </a>
                                                    <a class="btn btn-circle btn-icon-only btn-default" href="javascript:;">
                                                        <i class="icon-wrench"></i>
                                                    </a>
                                                    <a class="btn btn-circle btn-icon-only btn-default" href="javascript:;">
                                                        <i class="icon-trash"></i>
                                                    </a>
                                                    <a class="btn btn-circle btn-icon-only btn-default fullscreen" href="javascript:;" data-original-title="" title=""></a>
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <div id="context" data-toggle="context" data-target="#context-menu">
                                                    <p>
                                                        <asp:Label ID="lblTitleDesc" runat="server" Text='<%#Eval("TitleDescription")%>'></asp:Label>
                                                    </p>
                                                </div>
                                                <!-- Your custom menu with dropdown-menu as default styling -->
                                                <div id="context-menu" style="position: absolute; z-index: 9999; top: 125px; left: 474px;" class="">
                                                    <ul class="dropdown-menu" role="menu" style="">
                                                        <li>
                                                            <a href="javascript:;">
                                                                <i class="icon-user"></i>New User </a>
                                                        </li>
                                                        <li>
                                                            <a href="javascript:;">
                                                                <i class="icon-present"></i>New Event <span class="badge badge-success">4</span>
                                                            </a>
                                                        </li>
                                                        <li>
                                                            <a href="javascript:;">
                                                                <i class="icon-basket"></i>New order </a>
                                                        </li>
                                                        <li class="divider"></li>
                                                        <li>
                                                            <a href="javascript:;">
                                                                <i class="icon-flag"></i>Pending Orders <span class="badge badge-danger">4</span>
                                                            </a>
                                                        </li>
                                                        <li>
                                                            <a href="javascript:;">
                                                                <i class="icon-users"></i>Pending Users <span class="badge badge-warning">12</span>
                                                            </a>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                      </div>                        
                            </ItemTemplate>
                        </asp:DataList>
                        
                    
              
            
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
                        <div class="fb-page" data-href="https://www.facebook.com/yourdoorstp/" data-tabs="timeline" data-width="350" data-height="250" data-small-header="true" data-adapt-container-width="false" data-hide-cover="true" data-show-facepile="false"><blockquote cite="https://www.facebook.com/yourdoorstp/" class="fb-xfbml-parse-ignore"><a href="https://www.facebook.com/yourdoorstp/">Future Building Nursing Prep Centre</a></blockquote></div>
                    </div>
                    
                </div>
                <div class="rights mt-60 pt-15 pb-10">
                    Made by <a href="#">KSapCreations</a> &copy;
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

</body>
</html>
