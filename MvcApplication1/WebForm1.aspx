<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MvcApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script language="javascript" type="text/javascript">
      function showMacAddress() {
          var obj = new ActiveXObject("WbemScripting.SWbemLocator");
          var s = obj.ConnectServer(".");
          var properties = s.ExecQuery("SELECT * FROM Win32_NetworkAdapterConfiguration");
          var e = new Enumerator(properties);
          var output;
          output = '<table border="0" cellPadding="5px" cellSpacing="1px" bgColor="#CCCCCC">';
          output = output + '<tr bgColor="#EAEAEA"><td>Caption</td><td>MACAddress</td></tr>';
          while (!e.atEnd()) {
              e.moveNext();
              var p = e.item();
              if (!p) continue;
              output = output + '<tr bgColor="#FFFFFF">';
              output = output + '<td>' + p.Caption; +'</td>';
              output = output + '<td>' + p.MACAddress + '</td>';
              output = output + '</tr>';
          }
          output = output + '</table>';
          document.getElementById("box").innerHTML = output;
      }
</script>
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="text" id="txtMACAdress" />
<input type="text" id="txtIPAdress" />
<input type="text" id="txtComputerName" />
    </div>
    </form>
</body>
</html>
