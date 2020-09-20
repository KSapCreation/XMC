<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CELBAN.aspx.cs" Inherits="MvcApplication1.CELBAN" %>

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

<script src="assets/js/lib/modernizr-2.6.2-respond-1.1.0.min.js"></script>
    <link rel="shortcut icon" href="assets/demo-data/logoTitle.png">
</head>
<body>
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
                    <li><a href="#"><i class="fa fa-envelope"></i>info@SapCreations.com</a></li>
                </ul>

            </div>
            </div>

            
            <nav id="sticktop">
             <div class="container">
                
                    <a href="default.aspx" class="text-left logo"><img src="assets/demo-data/logo_fbnpc.png" alt=""></a>
                    <ul class="socials">
                        <li><a href="https://www.facebook.com/yourdoorstp/" class="fb" target="_blank"><i class="fa fa-facebook-f"></i></a></li>
                        <li><a href="#" class="twitter"><i class="fa fa-twitter"></i></a></li>
                    </ul>
                    <a href="#" class="nav-triger"><span class="fa fa-navicon"></span></a>
                    <ul class="main-menu">
                        <li class="active"><a href="Default.aspx">Home</a></li>
                        <li><a href="about.aspx">About Us</a></li>
                        <li><a href="#">Blog</a></li>
                       
                       <li class="parent"><a href="#">Our Programs</a>
                            <ul>
                                <li><a href="CELBAN.aspx">CELBAN</a></li>
                                <li><a href="IELTS.aspx">IELTS</a></li>
                                <li><a href="OurPrograms.aspx">NCLEX & CPNRE</a></li>                                                                
                            </ul>
                        </li>
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
                    <li><a href="#">CELBAN</a></li>
                </ul>
                
            </div>
        </div>

        <section class="style-res">
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                       <h3 class="text-uppercase">CELBAN</h3>
                        <p> CELBAN is an occupation-specific language test that assesses proficiency within real-world health care scenarios. 
                            <p>It evaluates proficiency in listening, writing, reading and speaking and is recognized as proof of language proficiency by all Canadian nursing regulators</p>
                        
                    </div>
                    
                </div>
            </div>
        </section>

        <%--<section>
            <div class="container">
                <div class="row">
                    <div class="col-sm-6">
                        <figure class="bg-white style"><img src="assets/demo-data/962892_orig-480x340.jpg" alt="/"></figure>
                    </div>
                    <div class="col-sm-6">
                        <h4 class="mb-20 color-blue">Dedicated Team</h4>
                        <p>With two clinics specializing in the care for our patients’ total health and well being our doctors are able to create life long relationships. Having the whole picture lets your doctor know what your needs are with your current health while also being prepared for any future medical needs. <br>
        Through preventative health care, exercise/diet programs, and regular examinations, our staff can help you enjoy a lifetime of good health. .
        </p>
                        <a href="#" class="btn mt-40">Take Appointment</a>

                    </div>
                </div>
            </div>
        </section>

        <div class="bg-blue color-white pb-50 pt-10 about-texts">
            <div class="container">
                <div class="row">
                    <div class="col-sm-3 mt-30">
                        <h6 class="text-bold">Philosophy title</h6>
                        <p>Through preventative health care, exercise/diet programs, and regular examinations, our staff can help you enjoy a lifetime.</p>
                    </div>
                    <div class="col-sm-3 mt-30">
                        <h6 class="text-bold">Philosophy title</h6>
                        <p>Through preventative health care, exercise/diet programs, and regular examinations, our staff can help you enjoy a lifetime.</p>
                    </div>
                    <div class="col-sm-3 mt-30">
                        <h6 class="text-bold">Philosophy title</h6>
                        <p>Through preventative health care, exercise/diet programs, and regular examinations, our staff can help you enjoy a lifetime.</p>
                    </div>
                    <div class="col-sm-3 mt-30">
                        <h6 class="text-bold">Philosophy title</h6>
                        <p>Through preventative health care, exercise/diet programs, and regular examinations, our staff can help you enjoy a lifetime.</p>
                    </div>
                </div>
            </div>
        </div>   --%> 

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
                    Made by <a href="#">SapCreations</a> &copy;
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
