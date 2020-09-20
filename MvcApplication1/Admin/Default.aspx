<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MvcApplication1.Admin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
        <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
        <meta content="Coderthemes" name="author" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />

        <link rel="shortcut icon" href="../assets/demo-data/logoTitle.png">

        <!-- Bootstrap core CSS -->
        <link href="FBNPC/css/bootstrap.min.css" rel="stylesheet">
        <!-- Icons CSS -->
        <link href="FBNPC/css/icons.css" rel="stylesheet">
        <!-- Custom styles for this template -->
        <link href="FBNPC/css/style.css" rel="stylesheet">
    <title>:: FBNPC Login ::</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>    
        <!-- HOME -->
        <section>
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">

                        <div class="wrapper-page">
                            <asp:Label ID="lblOTP" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblMac" runat="server" Visible="false"></asp:Label>
                            <div class="m-t-40 card-box" id="LoginInfo" runat="server" visible="true">
                                <div class="text-center">
                                    <h2 class="text-uppercase m-t-0 m-b-30">
                                        <a href="#" class="text-success">
                                            <span><img src="../assets/demo-data/Logo_fbnpc_new.png" alt="" height="100"></span>
                                        </a>
                                    </h2>
                                    <!--<h4 class="text-uppercase font-bold m-b-0">Sign In</h4>-->
                                </div>
                                <div class="account-content">
                                    
                                        <div class="form-group m-b-20">
                                            <div class="col-xs-12">
                                                <label for="emailaddress">User Name</label>
                                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="User Name" AutoCompleteType="Disabled"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group m-b-20">
                                            <div class="col-xs-12">
                                                <asp:LinkButton ID="lnk" runat="server" class="text-muted pull-right font-14" OnClick="ResetLogin">Forgot your password?</asp:LinkButton>                 
                                                <label for="password">Password</label>
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                                            </div>
                                        </div>                                      
                                   
                                    <div class="form-group m-b-20">
                                            <div class="col-xs-12">
                                                <asp:UpdatePanel ID="UP1" runat="server">
                                                    <ContentTemplate>
                                                        <div class="row">
                                                            <div class="col-sm-3">
                                                                <label for="password">Verify Code</label>
                                                                <asp:TextBox ID="txtVerifyCode" runat="server" CssClass="form-control" placeholder="Verify Code" AutoCompleteType="Disabled" ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3" style="margin-top:7%;">
                                                                <asp:LinkButton ID="linkbtn" runat="server" OnClick="CaptchaRefresh">
                                                                      <img src="FBNPC/images/Refresh.ico" alt="Refresh" width="20" height="20"/>
                                                                </asp:LinkButton>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <label for="password">Enter Code</label>
                                                                <asp:TextBox ID="txtCaptcha" runat="server" CssClass="form-control" placeholder="Code" AutoCompleteType="Disabled"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>                                      
                                     <div class="form-group m-b-20" style="margin-left:60%;">
                                               <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtVerifyCode" ControlToValidate="txtCaptcha" ErrorMessage="Invalid Code !" Display="Dynamic" ForeColor="#cc3300" />
                                         </div>
                                        <div class="form-group account-btn text-center m-t-20">
                                            <div class="col-xs-12">
                                                <asp:Button ID="btnlogin" runat="server" class="btn btn-lg btn-custom btn-block" Text="Sign In" OnClick="Login" />                                                                          </div>
                                        </div>

                                    

                                    <div class="clearfix"></div>

                                </div>
                            </div>
                            <!-- end card-box-->
                            <div class="m-t-40 card-box" id="LoginReset" runat="server" visible="false">
                                <div class="text-center">
                                    <h2 class="text-uppercase m-t-0 m-b-30">
                                        <a href="index.html" class="text-success">
                                            <span><img src="FBNPC/images/logo_fbnpc.png" alt="" height="100"></span>
                                        </a>
                                    </h2>
                                    <!--<h4 class="text-uppercase font-bold m-b-0">Sign In</h4>-->
                                </div>
                                <div class="account-content">                                    
                                        <div class="form-group m-b-20">
                                            <div class="col-xs-12">
                                                <label for="emailaddress">Email ID</label>
                                                <asp:TextBox ID="txtForgetEmail" runat="server" CssClass="form-control" placeholder="Email ID" AutoCompleteType="Disabled" TextMode="Email"></asp:TextBox>
                                            </div>
                                        </div>
                                    <div>
                                        <br />
                                    </div>
                                   
                                    <div class="form-group m-b-20" id="OTPVerify" runat="server" visible="false">
                                        <div class="col-xs-12">
                                            <label for="password">OTP</label>
                                            <asp:TextBox ID="txtOTP" runat="server" CssClass="form-control" placeholder="OTP"></asp:TextBox>
                                        </div>
                                    </div>          
                                    <div class="form-group m-b-20" id="forgetpassword" runat="server" visible="false">
                                        <div class="col-xs-12">
                                            <label for="password">New Password</label>
                                            <asp:TextBox ID="txtNewPwd" runat="server" CssClass="form-control" placeholder="New Password" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-12">
                                            <label for="password">Conform Password</label>
                                            <asp:TextBox ID="txtConformPwd" runat="server" CssClass="form-control" placeholder="Conform Password" TextMode="Password"></asp:TextBox>
                                        </div>
                                           <div class="col-xs-12">
                                              <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txtNewPwd" ControlToValidate="txtConformPwd" ErrorMessage="Your passwords do not match!" Display="Dynamic" ForeColor="#cc3300" />
                                               </div>
                                    </div>                                                        
                                    <div>
                                        <br />
                                    </div>
                                        <div class="form-group account-btn text-center m-t-10">
                                            <div class="col-xs-6">
                                                <asp:Button ID="forget" runat="server" Text="OTP" class="btn btn-lg btn-custom btn-block" OnClick="ForgetPassword" />
                                            </div>
                                            <div class="col-xs-6">
                                                <asp:Button ID="btnBackToLogin" runat="server" Text="Cancel" class="btn btn-lg btn-custom btn-block" OnClick="BackToLogin" />
                                            </div>
                                        </div>

                                    

                                    <div class="clearfix"></div>

                                </div>
                            </div>
                            <!-- Product Key -->
                            <div id="ProductKeyDiv" runat="server" visible="false" class="note note-success note-bordered">
                                <h2>Application Has Been Expired,For Renewal or More Details </h2>
                                <h3 style="color:#ea7373;">Contact to KSap Creation</h3>
                                <asp:Button ID="btnYes" runat="server" Text="Enter Product Key" class="btn btn-lg btn-custom btn-block" OnClick="ProductKetEnter" />
                            </div>
                             <div class="m-t-40 card-box" id="ProductKeyName" runat="server" visible="false">
                                <div class="text-center">
                                    <h2 class="text-uppercase m-t-0 m-b-30">
                                        <a href="index.html" class="text-success">
                                            <span><img src="FBNPC/images/logo_fbnpc.png" alt="" height="100"></span>
                                        </a>
                                    </h2>
                                    <!--<h4 class="text-uppercase font-bold m-b-0">Sign In</h4>-->
                                </div>
                                <div class="account-content">                       
                         
                                    <div class="form-group m-b-20">
                                       <div class="form-group m-b-20">
                                        <div class="col-xs-12">
                                            <label for="password">Product Key A</label>
                                            <asp:TextBox ID="txtProductKey1" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                            <div class="col-xs-12">
                                            <label for="password">Product Key B</label>
                                            <asp:TextBox ID="txtProductKey2" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div> 
                                    </div>                                               
                                                                                            
                                    <div>
                                        <br /><br />
                                    </div>
                                        <div class="form-group account-btn text-center m-t-20">
                                            <div class="col-xs-12">
                                                <asp:Button ID="btnProduct" runat="server" Text="Product Key" class="btn btn-lg btn-custom btn-block" OnClick="ProductKey" />
                                            </div>                                         
                                        </div>                                    

                                    <div class="clearfix"></div>

                                </div>
                            </div>

                        </div>
                        <!-- end wrapper -->

                    </div>
                </div>
            </div>
        </section>
        <!-- END HOME -->



        <!-- js placed at the end of the document so the pages load faster -->
        <script src="FBNPC/js/jquery-2.1.4.min.js"></script>
        <script src="FBNPC/js/bootstrap.min.js"></script>
        <script src="FBNPC/js/jquery.slimscroll.min.js"></script>

        <!-- App Js -->
        <script src="FBNPC/js/jquery.app.js"></script>
    </form>
    </body>
</html>
