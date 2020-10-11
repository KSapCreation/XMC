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


        <input type="text" readonly ="true" size="8" id="counter" runat="server" style="text-align:center; font-size:x-large; font-weight:bold; color:Red;"/>

        <input type="hidden" size="8" id="HidHours" value="3" runat="server"/>

<input type="hidden" size="8" id="HidMinutes" value="" runat="server"/>

<input type="hidden" size="8" id="HidSeconds" value="" runat="server"/>


        <script>

            var hours = document.getElementById('HidHours').value;

            var minutes = document.getElementById('HidMinutes').value;

            var seconds = document.getElementById('HidSeconds').value;

            function

                display() {

                if (seconds <= 0) {

                    if ((hours == 0) && (minutes == 0))

                        seconds = 0;

                    else {

                        seconds = 60;

                        minutes -= 1;

                    }

                }

                if (minutes <= 0) {

                    if ((hours < 0) && (minutes < 0)) {

                        hours = minutes = seconds = 0;

                    }

                    else {

                        if ((hours == 0) && (minutes == 0))

                            hours = minutes = 0;

                        if ((hours > 0) && (minutes < 0)) {

                            minutes = 59;

                            hours -= 1;

                        }

                    }

                }

                if ((minutes <= -1) || (hours <= -1)) {

                    if (hours <= -1) {

                        minutes = 0;

                        hours += 1;

                    }

                    else

                        minutes -= 1;

                    seconds = 0;

                    minutes += 1;

                }

                else

                    if (seconds > 0)

                        seconds -= 1;

                document.getElementById('counter').value = hours +": "+minutes +": "+seconds;

                setTimeout("display() ", 1000);

            }

            display();

        </script>

    </form>
</body>
</html>
