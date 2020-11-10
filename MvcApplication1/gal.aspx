<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gal.aspx.cs" Inherits="MvcApplication1.gal" %>

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
    <link href="assets/css/Gallery.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="assets/css/flexslider.css">
<link rel="stylesheet" type="text/css" href="assets/css/animations.css">
<link rel="stylesheet" type="text/css" href="assets/css/font-awesome.min.css">
<link rel="stylesheet" type="text/css" href="assets/css/jquery.flickr.css">
<link rel="stylesheet" type="text/css" href="assets/css/prettyPhoto.css">
<link rel="stylesheet" href="assets/css/main.css">
    
    <link rel="shortcut icon" href="assets/demo-data/logoTitle.png">
<%--      <script type="text/javascript">
           document.addEventListener("contextmenu", function (e) {
               e.preventDefault();
           }, false);
    </script>--%>
</head>
<body>
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
                        <li><a href="OurAchiever.aspx">Our Achiever</a></li>
                        <%--<li><a href="StudyMaterial.aspx">Study Materials</a></li>--%>
                       <%--<li class="parent"><a href="#">Our Programs</a>
                            <ul>
                                <li><a href="CELBAN.aspx">CELBAN</a></li>
                                <li><a href="IELTS.aspx">IELTS</a></li>
                                <li><a href="OurPrograms.aspx">NCLEX & CPNRE</a></li>                                
                            </ul>
                        </li>--%>
                        <li class="active"><a href="gal.aspx">Our Gallery</a></li>
                        <li><a href="contact.aspx">Contact</a></li>
                        
                    </ul>
                </div>
            </nav>
        </header>
         
        <div class="head pt-30 pb-20">
            <div class="container">
                <ul class="bread-crumb">
                    <li><a href="default.aspx">Home</a></li>
                    <li><a href="#">Our Gallery</a></li>
                </ul>
                
            </div>
        </div>
     <section class="our-team">
        <div class="container">
             <div class="row">
                <div class="latest-Video">
                    <span>Latest Picture</span>
                </div>
            </div>  
            <asp:Label ID="lblPicture" runat="server"></asp:Label>
            <asp:DataList ID="dlPicture" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <ItemTemplate>
                    
                        <%-- <div class="col-sm-12 mt-20">
                            <div  class="parent">
                                <div class="child bg-one">
                                <figure>
                                      <asp:Image ID="imgEditFile" runat="server" ImageUrl='<%# "Handler1.ashx?ImgID="+ Eval("GalleryID") %>' style="width: 300px;"/></figure>
                                     <a href="#">Los Angeles</a>
                            </div>
                            </div>
                     
                            </div>
                        </div>--%>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="hovereffect">
                                <img class="img-responsive" src='<%# "Handler1.ashx?ImgID="+ Eval("GalleryID") %>' alt="" width="300" style="height:200px"; />
                                <div class="overlay">
                                    <h2><asp:Label ID="lblDesc" runat="server" Text ='<%# Eval("Description") %>'></asp:Label></h2>                                    
                                </div>
                            </div>
                        </div>
                    <div>&nbsp;&nbsp;</div>
                </ItemTemplate>
            </asp:DataList>
            <!-- Latest Video -->
            <div class="row">
                <div class="latest-Video">
                    <span>Latest Video</span>
                </div>
            </div>  
            <div class="row">
                <div class="col-sm-12">
                     <asp:Label ID="lblVideo" runat="server"></asp:Label>
            <asp:DataList ID="dlGallery" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div class="row ">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="member bg-white">
                                <figure>
                                    <iframe width="300" height="200" src='<%# "https://www.youtube.com/embed/" + Eval("YouTubeLink") %>' frameborder="0" allowfullscreen></iframe></figure>
                            </div>
                        </div>                        

                    </div>
                </ItemTemplate>
            </asp:DataList>
                </div>
            </div>
           
        

      
        </div>
    </section>
    <footer class="bg-white pt-35">
            <div class="container">
       
                <div class="rights mt-60 pt-15 pb-10">
                    Made by <a href="http://www.ksapcn.com" target="_blank">KSap Creation</a> &copy;
                </div>
            </div>
        </footer>
     </div>
        <script type="text/javascript">

            Modernizr.load({
                test: Modernizr.csstransforms3d && Modernizr.csstransitions,
                yep: ['https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js', 'js/jquery.hoverfold.js'],
                nope: 'css/fallback.css',
                callback: function (url, result, key) {

                    if (url === 'js/jquery.hoverfold.js') {
                        $('#grid').hoverfold();
                    }

                }
            });

		</script>
    </form>
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
