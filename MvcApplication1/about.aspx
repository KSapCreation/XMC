<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="MvcApplication1.about" %>

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
    <link rel="shortcut icon" href="assets/demo-data/Logo_fbnpc_new.png">
     <script type="text/javascript" language="javascript">
         tinyMCE.init({
             // General options
             mode: "textareas",
             theme: "simple",
             plugins: "pagebreak,style,layer,table,save,advhr,advlink,emotions,iespell",

         });
    </script>
       <script type="text/javascript">
           document.addEventListener("contextmenu", function (e) {
               e.preventDefault();
           }, false);
    </script>
</head>
<!--========================================
Body Content
===========================================-->
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
                        <%--<li><a href="batches.aspx">Batches</a></li>
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
        
        <div class="head pt-50 pb-80">
            <div class="container">
                <ul class="bread-crumb">
                    <li><a href="default.aspx">Home</a></li>
                    <li><a href="#">About Us</a></li>
                </ul>
                
            </div>
        </div>

        <section class="style-res">
            <div class="container">
                <div class="row">
                    <div class="col-sm-6">
                        <asp:DataList ID="dlAboutCategory" runat="server" RepeatColumns="1" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <h3 class="text-uppercase">
                                    <asp:Label ID="lblTitleName" runat="server" Text='<%#Eval("Category")%>'></asp:Label></h3>
                                <p>
                                    <asp:Label ID="lblTitleDesc" runat="server" Text='<%#Eval("CompanyDesc")%>'></asp:Label></p>
                            </ItemTemplate>
                        </asp:DataList>                      
                        
                    </div>
                    <div class="col-sm-6">
                        <h3 class="text-uppercase after-left-l text-bold mb-20 pb-25">faq</h3>

                        <div class="accordian-wrapper mt-70">
                            <a href="#" class="accordian-trigger bg-blue1">Who must apply to NNAS?</a>
                            <div class="accordian-pane">
                                <p>As an Internationally Educated Nurse (IEN) you must set up an account with NNAS before your application will be considered by any Canadian nursing regulatory body if:</p>
                                <p>you received your post-secondary nursing education outside of Canada;</p>
                                <p>you have never registered to work as a nurse in Canada;</p>
                                <p>you want to work as a Registered Nurse (RN), Licensed Practical Nurse (LPN) or Registered Psychiatric Nurse (RPN) in Canada.</p>
                            </div>
                        </div>

                        <div class="accordian-wrapper">
                            <a href="#" class="accordian-trigger bg-blue1">Can I apply to the regulatory body directly?</a>
                            <div class="accordian-pane">
                                <p>No. All IENs who have never been registered to work as a nurse in Canada, must set up an account with NNAS before their application will be considered by any regulatory body.</p>
                            </div>
                        </div>

                        <div class="accordian-wrapper">
                            <a href="#" class="accordian-trigger bg-blue1">What are the steps of the application process?</a>
                            <div class="accordian-pane">
                                <p>All Internationally Educated Nurses must follow these steps (in order):</p>
                                <p>1. Set up an online account with National Nursing Assessment Service (NNAS) at <a href="www.nnas.ca.">www.nnas.ca.</a></p>
                                <p>2. Complete the online application.</p>
                                <p>3. Pay the required fee.</p>
                                <p>4. Follow the instructions about which documents to submit for verification.</p>
                                <p>5. Once your file is complete, NNAS will evaluate it and provide you with online access to an Advisory Report, which contains the results of the evaluation. NNAS will also send a copy of this report to the relevant regulatory body.</p>
                                <p>6. You can now apply directly to the regulatory body of your choice and pay their application fee. You will be able to do this from your NNAS online account.</p>
                            </div>
                        </div>
                         <div class="accordian-wrapper">
                            <a href="#" class="accordian-trigger bg-blue1">Can I apply to more than one province or nursing group (i.e. RN, LPN, RPN)?</a>
                            <div class="accordian-pane">
                                <p>Yes. Once you open a NNAS account, you can apply to more than one province, or to a different nursing group. Additional fees will apply.</p>
                                
                            </div>
                        </div>
                        <div class="accordian-wrapper">
                            <a href="#" class="accordian-trigger bg-blue1">After I submit my online application to NNAS, can I change my original requested province or nursing group to different province or nursing group?</a>
                            <div class="accordian-pane">
                                <p>Yes. You have two months from your submission date to create a new order and transfer your payment for a different Nursing Group.

REMEMBER: You have two months to change your nursing group or province for free, however, you still have until your report has been created to add a regulatory body or nursing discipline. This addition is available for a fee by purchasing an Additional Nursing Group or Additional Province through your dashboard.</p>
                                
                            </div>
                        </div>
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
