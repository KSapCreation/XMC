﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OurAchiever.aspx.cs" Inherits="MvcApplication1.OurAchiever" %>

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
    <link href="assets/css/Gallery.css" rel="stylesheet" />
<script src="assets/js/lib/modernizr-2.6.2-respond-1.1.0.min.js"></script>
    <link rel="shortcut icon" href="assets/demo-data/Logo_fbnpc_new.png">
     <script type="text/javascript" language="javascript">
         tinyMCE.init({
             // General options
             mode: "textareas",
             theme: "simple",
             plugins: "pagebreak,style,layer,table,save,advhr,advlink,emotions,iespell",

         });
    </script>
      <%-- <script type="text/javascript">
           document.addEventListener("contextmenu", function (e) {
               e.preventDefault();
           }, false);
       </script>--%>
</head>
<body>
    <form id="form1" runat="server">
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
                    <li><a href="#"><i class="fa fa-envelope"></i>Feedback@fbnpc.com</a></li>
                </ul>

            </div>
            </div>

            
            <nav id="sticktop">
             <div class="container">
                
                    <a href="default.aspx" class="text-left logo"><img src="assets/demo-data/logo_fbnpc_new.png" alt=""></a>
                    <ul class="socials">
                        <li><a href="https://www.facebook.com/yourdoorstp/" class="fb" target="_blank"><i class="fa fa-facebook-f"></i></a></li>
                        <li><a href="#" class="twitter"><i class="fa fa-twitter"></i></a></li>
                           <li><a href="https://ca.linkedin.com/in/taran-kaur-15196120" class="instagram" target="_blank"><i class="fa fa-instagram"></i></a></li>
                        <li><a href="https://www.youtube.com/channel/UCClaIbGsF13R8qvPOcFmEAA" class="YouTube" target="_blank"><i class="fa fa-youtube"></i></a></li>
                    </ul>
                    <a href="#" class="nav-triger"><span class="fa fa-navicon"></span></a>
                    <ul class="main-menu">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="active"><a href="about.aspx">About Us</a></li>
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
    <%--                    <li><a href="batches.aspx">Batches</a></li>
                        <li><a href="StudyMaterial.aspx">Study Materials</a></li>--%>
                        <li><a href="OurAchiever.aspx">Our Achiever</a></li>
                       <%--<li class="parent"><a href="#">Our Programs</a>
                            <ul>
                <li><a href="CELBAN.aspx">CELBAN</a></li>
                                <li><a href="IELTS.aspx">IELTS</a></li>
                                <li><a href="OurPrograms.aspx">NCLEX & CPNRE</a></li>                                
                            </ul>--%>
                        </li>
                        <li><a href="gal.aspx">Our Gallery</a></li>
                        <li><a href="contact.aspx">Contact</a></li>
                        
                    </ul>
                </div>
            </nav>
        </header>
        
       <%-- <div class="head pt-50 pb-80">
            <div class="container">
                <ul class="bread-crumb">
                    <li><a href="default.aspx">Home</a></li>
                    <li><a href="#">Our Achiever</a></li>
                </ul>
                
            </div>
        </div>--%>

        <section class="clearfix bg-white our-doctors animatedParent">
            <div class="container">
                <h3 class="text-bold text-center text-uppercase after-mid-l pb-25">OUR ACHEIVERS</h3>   
               
                <asp:DataList ID="dlAchieverPicture" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <ItemTemplate>                  
                    <div class="col-sm-12">
                    <div class="col-sm-4 mt-50 no-pad doctor animated fadeInLeft go">
                        <figure>   <img class="img-responsive" src='<%# "Handler1.ashx?AchieverID="+ Eval("AchieverID") %>' alt="" /></figure>
                    </div>
                    <div class="col-sm-8 mt-50 no-pad doctor style1 bg-blue1 animated fadeInLeft go" style="min-height:300px;">
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20"><asp:Label ID="Label1" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("LastName") %>'></asp:Label></h2></h6>
                       <p style="color:white;"><asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Description") %>'></asp:Label></h2></p>
                            <p style="color:white;"><asp:Label ID="lblCity" runat="server" Text='<%# Eval("CityName") %>'></asp:Label></h2></p>
                            <p style="color:white;"><asp:Label ID="lblCountry" runat="server" Text='<%# Eval("CountryName") %>'></asp:Label></h2></p>
                        </div>
                    </div>                    
                    </div>

                </ItemTemplate>
            </asp:DataList>
                
                <%--<div class="row color-white">
                    
                    <div class="col-sm-3 mt-50 no-pad doctor style1 bg-blue1 animated fadeInLeft go">
                        <figure><img src="assets/demo-data/demo/1.png" alt="" /></figure>
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">abc def</h6>
                        <p>Regina, UK</p>
                            <p>In publishing, art, and communication, content is the information and experiences that are directed toward an end-user or audience.</p>
                        </div>
                    </div>
                    <div class="col-sm-3 mt-50 no-pad doctor style2 bg-blue2 animated fadeInLeft go">
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">John Doe</h6>
                       <p>Regina, UK</p>
                            <p>In publishing, art, and communication, content is the information and experiences that are directed toward an end-user or audience.</p>
                        </div>
                        <figure><img src="assets/demo-data/demo/1.png" alt="/"></figure>
                    </div>
                    <div class="col-sm-3 mt-50 no-pad doctor style1 bg-blue3 animated fadeInLeft go">
                        <figure><img src="assets/demo-data/demo/1.png" alt="/"></figure>
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">Umar Doe</h6>
                       <p>Regina, UK</p>
                            <p>In publishing, art, and communication, content is the information and experiences that are directed toward an end-user or audience.</p>
                        </div>
                    </div>
                    <div class="col-sm-3 mt-50 no-pad doctor style2 bg-blue4 animated fadeInLeft go">
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">Emma Doe</h6>
                       <p>Regina, UK</p>
                            <p>In publishing, art, and communication, content is the information and experiences that are directed toward an end-user or audience.</p>
                        </div>
                        <figure><img src="assets/demo-data/demo/1.png" alt="" /></figure>
                    </div>
                                 <div class="col-sm-3 mt-50 no-pad doctor style1 bg-blue1 animated fadeInLeft go">
                        <figure><img src="assets/demo-data/demo/1.png" alt="" /></figure>
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">abc def</h6>
                        <p>Regina, UK</p>
                            <p>In publishing, art, and communication, content is the information and experiences that are directed toward an end-user or audience.</p>
                        </div>
                    </div>
                    <div class="col-sm-3 mt-50 no-pad doctor style2 bg-blue2 animated fadeInLeft go">
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">John Doe</h6>
                        <p>Heart Specialist</p>
                        </div>
                        <figure><img src="assets/demo-data/demo/1.png" alt="/"></figure>
                    </div>
                    <div class="col-sm-3 mt-50 no-pad doctor style1 bg-blue3 animated fadeInLeft go">
                        <figure><img src="assets/demo-data/demo/1.png" alt="/"></figure>
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">Umar Doe</h6>
                        <p>Eye Specialist</p>
                        </div>
                    </div>
                    <div class="col-sm-3 mt-50 no-pad doctor style2 bg-blue4 animated fadeInLeft go">
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">Emma Doe</h6>
                        <p>Child Specialist</p>
                        </div>
                        <figure><img src="assets/demo-data/demo/1.png" alt="/"></figure>
                    </div>
                </div>--%>
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

