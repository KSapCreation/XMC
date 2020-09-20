<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MvcApplication1.Default" %>

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
    
    <link href="assets/css/theme.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="assets/css/flexslider.css">
<link rel="stylesheet" type="text/css" href="assets/css/animations.css">
<link rel="stylesheet" type="text/css" href="assets/css/font-awesome.min.css">
<link rel="stylesheet" type="text/css" href="assets/css/jquery.flickr.css">
<link rel="stylesheet" type="text/css" href="assets/css/prettyPhoto.css">
<link rel="stylesheet" href="assets/css/main.css">

<script src="assets/js/lib/modernizr-2.6.2-respond-1.1.0.min.js"></script>
    <link rel="shortcut icon" href="assets/demo-data/Logo_fbnpc_new.png">
      <script type="text/javascript">
          document.addEventListener("contextmenu", function (e) {
              e.preventDefault();
          }, false);
    </script>
   <script>
       $('.multiple-items').slick({
           infinite: true,
           slidesToShow: 3,
           slidesToScroll: 3
       });

   </script>
</head>
<body>
    <form id="form1" runat="server">
<!--========================================
Body Content
===========================================-->
<div class="offsetWrap">
    
    <div class="offsetMaker"> 
        
        <header class="bg-white doc-header">
            <div class="head-contact clearfix">
            <div class="container" style="padding-right:0px;">
                <ul class="nav-top pull-left">
                    <li><a href="Exam/RegistrationForm.aspx" class="appointment">Register Now</a></li>                    
                    <li><a href="LoginIn.aspx">My Account</a></li>
                    <%--<li><a href="ExamDefault.aspx" class="TakeTest">Take the Test Now</a></li>--%>
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
                        <li class="active"><a href="Default.aspx">Home</a></li>
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
                        <li><a href="batches.aspx">Batches</a></li>
                        <li><a href="StudyMaterial.aspx">Study Materials</a></li>
                        
                     <%-- <li class="parent"><a href="#">Our Programs</a>
                            <ul>
                                <li><a href="CELBAN.aspx">CELBAN</a></li>
                                <li><a href="IELTS.aspx">IELTS</a></li>
                                <li><a href="OurPrograms.aspx">NCLEX & CPNRE</a></li>                                
                            </ul>
                        </li>--%>
                        <li><a href="gal.aspx">Our Gallery</a></li>
                        <li><a href="contact.aspx">Contact</a></li>
                        
                    </ul>
                </div>                
            </nav>
        </header>    

        <section class="custom-slider no-pad">
            <div id="home-slider" class="xv_slider flexslider">
                <ul class="slides">
                    <li class="xv_slide" data-slideBg="url(assets/demo-data/slider1.png)" >
                        <div class="flex-caption">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-offset-7 col-md-5 col-sm-6 col-sm-offset-6">
                                        <h3 class="mb-25 text-uppercase color-blue text-bold after-left-l pb-30 animated fadeInLeft">
                                            <asp:Label ID="Slider1Title" runat="server"></asp:Label>
                                        </h3>
                                        <p class="animated fadeInRight"><asp:Label ID="Slider1Desc" runat="server"></asp:Label> </p>
                                        <a href="Exam/RegistrationForm.aspx" class="btn animated fadeInUp">Take Test</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                    <li class="xv_slide" data-slideBg="url(assets/demo-data/slider2.jpg)" >
                        <div class="flex-caption">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-offset-7 col-md-5 col-sm-6 col-sm-offset-6">
                                        <h3 class="mb-25 text-uppercase color-blue text-bold after-left-l pb-30 animated fadeInLeft">
                                            <asp:Label ID="Slider2Title" runat="server"></asp:Label>
                                        </h3>
                                                <p class="animated fadeInRight"><asp:Label ID="Slider2Desc" runat="server"></asp:Label> </p>
                                        <a href="Exam/RegistrationForm.aspx" class="btn animated fadeInUp">Take Test</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>

                    <li class="xv_slide" data-slideBg="url(assets/demo-data/slider3.jpg)" >
                           <div class="flex-caption">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-offset-7 col-md-5 col-sm-6 col-sm-offset-6">
                                        <h3 class="mb-25 text-uppercase color-blue text-bold after-left-l pb-30 animated fadeInLeft">
                                            <asp:Label ID="Slider3Title" runat="server"></asp:Label>
                                        </h3>
                                                <p class="animated fadeInRight"><asp:Label ID="Slider3Desc" runat="server"></asp:Label> </p>
                                        <a href="Exam/RegistrationForm.aspx" class="btn animated fadeInUp">Take Test</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </section>

        <%--<section class="services bg-blue color-white no-pad clearfix">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 col-sm-6 service no-pad style1 bg-blue1">
                        <h6 class="text-uppercase text-bold after-left-s pb-45 mb-15"><img src="assets/demo-data/i6.png" class="pull-left" alt="/"><span class="pad">HEART<br> SPECIALIST</span></h6>
                        <p>We have talented heart specialist doctors.</p>
                    </div>
                    <div class="col-md-3 col-sm-6 service no-pad style2 bg-blue2">
                        <h6 class="text-uppercase text-bold after-left-s pb-45 mb-15"><img src="assets/demo-data/i2.png" class="pull-left" alt="/"><span class="pad">CHILD<br> SPECIALIST</span></h6>
                        <p>Child care specialist are available 7 days in a week.</p>
                    </div>
                    <div class="col-md-3 col-sm-6 service no-pad style3 bg-blue3">
                        <h6 class="text-uppercase text-bold after-left-s pb-45 mb-15"><img src="assets/demo-data/i1.png" class="pull-left" alt="/"><span class="pad">DNA<br> LABORATORY</span></h6>
                        <p>Let us take care of your eyes with new technology.</p>
                    </div>
                    <div class="col-md-3 col-sm-6 service no-pad style4 bg-blue4">
                        <h6 class="text-uppercase text-bold after-left-s pb-45 mb-15"><img src="assets/demo-data/i3.png" class="pull-left" alt="/"><span class="pad">TOOTH<br> SPECIALIST</span></h6>
                        <p>Let us take care of your eyes with new technology.</p>
                    </div>
                </div>
            </div>
        </section>--%>

        <section class="clearfix animatedParent">
            <div class="container">
                <div class="row">
                    <div class="col-md-7 col-sm-6">
                        <h3 class="text-bold after-left-l pb-25 mb-55">About Us</h3>
                       <p> At Future Building Nursing Prep Center we are dedicated to cater all your needs to pursue a nursing career in Canada.</p>
                        <p> Conveniently located in Regina, Saskatchewan, we take pride in our work ethics and student-centric approach. </p>
                        <P>Our highly qualified and trained staff ensures best possible and effective learning environment.</P>
                        <a href="about.aspx" class="btn mt-25">Read More</a>
                    </div>
                   <div class="col-md-5 col-sm-6 schedules">
                        <h3 class="text-bold after-left-l pb-25 mb-55 ls-5">SCHEDULE</h3>

                        <div class="schedule bg-blue1 radius-top color-white clearfix">
                            <h6 class="text-uppercase text-bold pull-left"><span class="pad">SCHEDULE <br /> Classes</span></h6>
                            <div class="pull-right text-center">
                                <strong>MON - FRI</strong><br />
                                09:00 AM -05:00 PM
                            </div>
                        </div>
                        
                        <div class="schedule bg-blue3 color-white clearfix">
                       <h6 class="text-uppercase text-bold pull-left"><span class="pad">SCHEDULE <br /> Classes</span></h6>
                            <div class="pull-right text-center">
                                <strong>Flexible Hours</strong><br />
                                
                            </div>
                        </div>
                        <div class="schedule bg-blue1 radius-top color-white clearfix">
                             <div class="pull-right text-center">
                                <strong>Late office hours are available on Request</strong><br />
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="clearfix features text-center animatedParent">
            <div class="container">
                
               
                    <%--<div class="col-sm-4 mt-70 animated fadeInLeft">
                        <figure><img src="assets/demo-data/child.png" alt="/"></figure>
                        <h5 class="text-bold color-blue">CHILD CARE</h5>
                        <p>We provide special child care service from age 3 to 11 and also provide play room for kids.</p>
                    </div>           --%>

                    <asp:DataList ID="dlOtherInfo" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                        <ItemTemplate>
                           <%-- <div class="b-advantages__inner effect-border">
                                <div class="icon-box-3col">--%>
                                    <div class="container-fluid no-padding">
                                        <div class="icon-box-modern col-md-11">
                                            <h4 style="font-size: 15px">
                                                <asp:Label ID="lblTitleName" runat="server" Text='<%#Eval("TitleName")%>'></asp:Label></h4>
                                            <p>
                                                <asp:Label ID="lblTitleDesc" runat="server" Text='<%#Eval("TitleDescription")%>'></asp:Label>
                                            </p>
                                            <a class="bttn skin-white" href="Information.aspx">FIND OUT MORE</a>

                                        </div>
                                    </div>
                             <%--   </div>
                            </div>        --%>
                            <%--<div class="row">
                                <div class="col-sm-11 mt-70 animated fadeInLeft" style="background-color: antiquewhite; border-style: groove;">
                                    <h2 class="text-bold text-uppercase color-blue after-mid-l pb-25">
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("TitleName")%>'></asp:Label>
                                    </h2>
                                    <p>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("TitleDescription")%>'></asp:Label>
                                    </p>
                                </div>
                            </div>--%>
                        </ItemTemplate>
                    </asp:DataList>
                              
                  
            </div>
        </section>
          <div class="promo bg-blue4 color-white clearfix pt-20 pb-20">
          </div>
        <section class="clearfix reviews animatedParent">
            <div class="container">
                <h3  class="text-bold text-uppercase after-mid-l pb-25 text-center">OUR PROGRAMS</h3>
                <section class="b-advantages b-advantages-2 b-advantages_6-col">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
                                <asp:DataList ID="dlPrograms" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" RepeatLayout="Table">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <div class="b-advantages__inner effect-border">
                                                        <h3 class="b-advantages__title ui-title-inner">
                                                            <asp:LinkButton ID="linkShow" runat="server" OnClick="EditShow">
                                                                <asp:Label ID="lblDesc1" runat="server" Text='<%#Eval("TitleName")%>'></asp:Label>
                                                            </asp:LinkButton>
                                                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("ProgramsID")%>' Visible="false"></asp:Label>
                                                        </h3>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>

                                    </ItemTemplate>

                                </asp:DataList>
                            </asp:Panel>
                             <a href="OurPrograms.aspx" class="btn mt-25">Read More</a>
                        </div>
                    </div>
                </section>            
                
            </div>
            
        </section>
     
          <div class="promo bg-blue4 color-white clearfix pt-20 pb-20">
               </div>
        <%--<section class="clearfix bg-white our-doctors animatedParent">
            <div class="container">
                <h3 class="text-bold text-center text-uppercase after-mid-l pb-25">OUR CENTER</h3>
                
                <div class="row color-white">
                    <div class="col-sm-3 mt-50 no-pad doctor style1 bg-blue1 animated fadeInLeft">
                        <figure><img src="assets/demo-data/dm.jpg" alt="/"></figure>
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">Sara Doe</h6>
                        <p>Tooth Specialist</p>
                        </div>
                    </div>
                    <div class="col-sm-3 mt-50 no-pad doctor style2 bg-blue2 animated fadeInLeft">
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">John Doe</h6>
                        <p>Heart Specialist</p>
                        </div>
                        <figure><img src="assets/demo-data/d12.jpg" alt="/"></figure>
                    </div>
                    <div class="col-sm-3 mt-50 no-pad doctor style1 bg-blue3 animated fadeInLeft">
                        <figure><img src="assets/demo-data/d22.jpg" alt="/"></figure>
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">Umar Doe</h6>
                        <p>Eye Specialist</p>
                        </div>
                    </div>
                    <div class="col-sm-3 mt-50 no-pad doctor style2 bg-blue4 animated fadeInLeft">
                        <div class="info">
                        <h6 class="text-bold text-uppercase after-left-s pb-20">Emma Doe</h6>
                        <p>Child Specialist</p>
                        </div>
                        <figure><img src="assets/demo-data/dr.jpg" alt="/"></figure>
                    </div>
                </div>
            </div>
        </section>--%>

        <section class="our-posts">
            <div class="container">
                <h3 class="text-bold text-uppercase after-mid-l pb-25 text-center">Testimonials</h3>
                
                <div class="row">
                    <div class="col-md-12" style="background-color: white;border-radius: 11px;">
                                     <marquee direction="up" scrollamount="3" onmouseover="this.stop()" onmouseout="this.start()" behavior="scroll" height="200px">     

                            <asp:DataList ID="DlTestimonials" runat="server" RepeatColumns="1" RepeatDirection="Vertical" >
                                <ItemTemplate>                                   
                                    <div class="col-sm-12" >
                                       
                                                
                                                <table>
                                                    <tr>
                                                        <td>
                                                           ( <asp:Label ID="lblSrno" runat="server" Text='<%#Eval("Srno")%>'></asp:Label> )
                                                             <b><asp:Label ID="Label1" runat="server" Text='<%#Eval("TitleName")%>'></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                              <asp:Label ID="Label3" runat="server" Text='<%#Eval("TitleDescription")%>'></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <br />
                                                         </td>
                                                    </tr>
                                                </table>
                                                   
                                    </div>

                                </ItemTemplate>
                            </asp:DataList>
                             </marquee>
                                          
                                        
                        
                            
                        <a href="Testimonials.aspx" class="btn mt-25">Read More</a>
                    </div>
                </div>
                           
                </div>
          <%--  <div class="row">
                <div class="col-sm-12">
                    <a href="Testimonials.aspx" class="btn">Read More</a>
                </div>
            </div>    --%>
            
        </section>

        <div class="promo bg-blue4 color-white clearfix pt-20 pb-20">         
        </div>

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
                    Made by <a href="http://www.sapcreation.com">KSapCreations</a> &copy;

                              <span id="siteseal" style="padding-left:60%;"><script async type="text/javascript" src="https://seal.godaddy.com/getSeal?sealID=9UIAOM0d8Jh1G3ZEC4xR6xKAmLELqSTht1DssmGbAD5w6tOl57dzmW81GRIh"></script></span>
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
