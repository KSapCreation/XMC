<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginIn.aspx.cs" Inherits="MvcApplication1.LoginIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>:: Future Building Nursing Prep Center ::</title>
    	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="ExamLogin/vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="ExamLogin/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="ExamLogin/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="ExamLogin/vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="ExamLogin/vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="ExamLogin/vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="ExamLogin/vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="ExamLogin/vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="ExamLogin/css/util.css">
	<link rel="stylesheet" type="text/css" href="ExamLogin/css/main.css">
<!--===============================================================================================-->

</head>
<body style="background-color: #666666;">
	<form id="Form1" runat="server">

	
	<div class="limiter">
		<div class="container-login100">
            <div class="wrap-login100">
				<div class="login100-form validate-form">
                     <span class="login100-form-title p-b-43">
						<img src="assets/demo-data/Logo_fbnpc_new.png" />
					</span>
					<asp:Label ID="lblMac" runat="server" Visible="false"></asp:Label>
					
					<div class="wrap-input100 validate-input" data-validate = "Valid email is required: ex@abc.xyz">
						<asp:TextBox ID="txtEmail" runat="server" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100"></span>
                        <span class="label-input100">Email</span>           
					</div>
					
					
					<div class="wrap-input100 validate-input" data-validate="Password is required">
					<asp:TextBox ID="txtPwd" runat="server" CssClass="input100" TextMode="Password"></asp:TextBox>
                        <span class="focus-input100"></span>
                        <span class="label-input100">Password</span>     
                        		
					</div>
                    	
			

					<div class="container-login100-form-btn">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="#ff3300"></asp:Label>
					    <asp:Button ID="BLogin" runat="server" class="login100-form-btn"  Text="Login" OnClick="btnLogin" />
					</div>
					
				

				
				</div>

				<div class="login100-more" style="background-image: url('Examlogin/images/ExamLogin.png');">
				</div>
			</div>
		</div>
	</div>
	
	

	
	
<!--===============================================================================================-->
	<script src="ExamLogin/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="ExamLogin/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="ExamLogin/vendor/bootstrap/js/popper.js"></script>
	<script src="ExamLogin/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="ExamLogin/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="ExamLogin/vendor/daterangepicker/moment.min.js"></script>
	<script src="ExamLogin/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="ExamLogin/vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="ExamLogin/js/main.js"></script>
    </form>
</body>
</html>
