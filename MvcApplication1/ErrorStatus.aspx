<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorStatus.aspx.cs" Inherits="MvcApplication1.ErrorStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: FBNPC : Custom Error ::</title>
       <script type="text/javascript">
           document.addEventListener("contextmenu", function (e) {
               e.preventDefault();
           }, false);
    </script>
</head>
<body style="background-color: aliceblue;">
 <div style="margin-left:40%; margin-top:10%;">
     <p style="padding-left:2%;"><b>Connection lost !</b></p>            
    <img src="Exam/img/signal.png" alt="Connection Lost" width="150" height="100" />
     <p style="margin-left:3%;"><b>try again later !</b></p>  
     <a href="www.fbnpc.com" title="FBNPC" style="margin-left:3%;">www.fbnpc.com</a>
    </div>
</body>
</html>
