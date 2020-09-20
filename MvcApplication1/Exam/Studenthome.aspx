
<%@ Page Title="" Language="C#" MasterPageFile="~/Exam/Student.Master" AutoEventWireup="true" CodeBehind="Studenthome.aspx.cs" Inherits="MvcApplication1.Exam.Studenthome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <meta charset="utf-8"/>
<title>:: FBNPC || Student ::</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1.0" name="viewport"/>
<meta http-equiv="Content-type" content="text/html; charset=utf-8">
<meta content="" name="description"/>
<meta content="" name="author"/>
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css">
<link href="plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
<link href="plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css">
<link href="plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css">
<link href="plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css">
<!-- END GLOBAL MANDATORY STYLES -->
        
<!-- BEGIN PAGE LEVEL STYLES -->
<link href="plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.css" rel="stylesheet" type="text/css"/>
<link href="plugins/fancybox/source/jquery.fancybox.css" rel="stylesheet"/>
<!-- BEGIN:File Upload Plugin CSS files-->
<link href="plugins/jquery-file-upload/blueimp-gallery/blueimp-gallery.min.css" rel="stylesheet"/>
<link href="plugins/jquery-file-upload/css/jquery.fileupload.css" rel="stylesheet"/>
<link href="global/plugins/jquery-file-upload/css/jquery.fileupload-ui.css" rel="stylesheet"/>
<!-- END:File Upload Plugin CSS files-->
<!-- END PAGE LEVEL STYLES -->
<!-- BEGIN PAGE LEVEL STYLES -->
<link href="Pages/css/profile.css" rel="stylesheet" type="text/css"/>
    <link href="Pages/css/tasks.css" rel="stylesheet" type="text/css"/>
<!-- END PAGE LEVEL STYLES -->
<!-- BEGIN THEME STYLES -->
<link href="css/components-rounded.css" id="style_components" rel="stylesheet" type="text/css">
<link href="css/plugins.css" rel="stylesheet" type="text/css">
<link href="css/layout.css" rel="stylesheet" type="text/css">
<link href="css/themes/default.css" rel="stylesheet" type="text/css" id="style_color">
<link href="css/custom.css" rel="stylesheet" type="text/css">
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="../assets/demo-data/Logo_fbnpc_new.png"/>
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        });
</script> 
  

      <script type="text/javascript">
          document.addEventListener("contextmenu", function (e) {
              e.preventDefault();
          }, false);
    </script>
    
<script type='text/javascript'>
    document.onkeydown = function (e) {
        var key = e.charCode || e.keyCode;
        if (key == 13) {
            // enter key do nothing
        } else {
            e.preventDefault();
        }
    }
</script>

    <style>
        .loader {
    position: fixed;
    left: 0px;
    top: 0px;
    width: 100%;
    height: 100%;
    z-index: 9999;
    background: url('images/Loader.gif') 50% 50% no-repeat rgb(249,249,249);
    opacity: .8;
}
           
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 	<!-- BEGIN PROFILE CONTENT -->

					<div class="profile-content">
                        <div id="Div1" class="row" runat="server" visible="true">
                                   <div class="col-md-6">
                        <div class="tab-pane">
								<div class="portlet box blue">
									<div class="portlet-title">
										<div class="caption">
											<i class="fa fa-gift"></i>Score Board
										</div>
									</div>
									<div class="portlet-body form">
										<!-- BEGIN FORM-->                          		
											<div>
                                               <div>                                                    
                                                     <div id="visualization" style="height:250px;">                                                       
                                                        </div>                                     
                                                     
                                               </div>
                                            </div>
                                        </div>
                                    </div>
                            </div>
                      </div>
                                    <div class="col-md-6">
                        <div class="tab-pane">
								<div class="portlet box blue">
									<div class="portlet-title">
										<div class="caption">
											<i class="fa fa-gift"></i>FBNPC Updates
										</div>
									</div>
									<div class="portlet-body form">
                                        <marquee direction="up" style="height:250px;padding-left: 5px;" scrollamount="3" onmouseover="this.stop();" onmouseout="this.start();" behavior="scroll">
                                        <asp:DataList ID="dlUpdates" runat="server" RepeatColumns="1">
                                            <ItemTemplate>
                                              
                                            <p>    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Description")%>'></asp:Label> </p>
                                                <span style="padding-left:25%; color:red;">**** End ****</span>
									
                                            </ItemTemplate>
                                        </asp:DataList>
										</marquee>
                                     </div>
                                    </div>
                            </div>
                      </div>
                                   </div>
						<div class="row">
							<div class="col-md-12">
								<!-- BEGIN PORTLET -->
								<div class="tab-pane" id="Userinfo" runat="server" visible="true">
                                <div class="portlet box blue">
                                     <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Personal Information
                                            </div>
                                        </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                       
                                        <div class="form-body">
                                            <div class="row">
                                            
                                            <div class="col-md-6">
                                                <div class="form-group has-error">
                                                    <label class="control-label">First Name</label>
                                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name" ReadOnly="true"></asp:TextBox>

                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Last Name</label>
                                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last Name" ReadOnly="true"></asp:TextBox>

                                                </div>
                                            </div>

                                        </div>
                                              <div class="row">
                                            <div class="col-md-6 ">
                                                <div class="form-group">
                                                    <label>Email ID</label>
                                                    <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-6 ">
                                                <div class="form-group">
                                                    <label>Mobile No</label>
                                                    <asp:TextBox ID="txtPhoneNo" runat="server" Class="form-control" placeholder="Mobile No" TextMode="Phone" MaxLength="10"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                               <div class="form-actions right">
                                             <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn blue" OnClick="Save" />
                                    </div>
                                        </div>
                                       
                                    </div>
                                </div>
                            </div>
								<!-- END PORTLET -->
							</div>							
						</div>	
                        	<!-- Exam Reloader -->    
                        		<div class="row">
							<div class="col-md-12">
								<!-- BEGIN PORTLET -->
								<div class="tab-pane" id="Div2" runat="server" visible="true">
                                <div class="portlet box blue">
                                     <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Exam Re-Loader
                                            </div>
                                        </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                       
                                        <div class="form-body">
                                            <div class="row">
                                            
                                            <div class="col-md-6">
                                                <div class="form-group has-error">
                                                    <label class="control-label">Student Name</label>
                                                    <asp:label ID="lblStudentID" runat="server" CssClass="form-control" Visible="false"></asp:label>
                                                     <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control" placeholder="Student Name" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Exam Name</label>
                                                  <asp:DropDownList ID="ddlExamlist" runat="server" CssClass="form-control" OnSelectedIndexChanged="CheckAvailability" AutoPostBack="true"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>                                            
                                            <div class="form-actions right">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Availability" CssClass="btn blue" OnClick="AvailabilityReloader" />
                                            </div>
                                        </div>
                                       
                                    </div>
                                </div>
                            </div>
								<!-- END PORTLET -->
							</div>							
						</div>			
                        <!-- End -->
					</div>
        
            
            <div class="loader"></div>
     
					<!-- END PROFILE CONTENT -->

     <!-- Dashboard Charts Scripts -->
      <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="//www.google.com/jsapi"></script>
  <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <!--first chart -->
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Studenthome.aspx/GetData',
                data: '{}',
                success:
                    function (response) {
                        drawVisualization(response.d);
                    }
            });
        })

        function drawVisualization(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].ColumnName, dataValues[i].Value]);
            }
            new google.visualization.PieChart(document.getElementById('visualization')).
                draw(data, { title: "Status: Listening Audio Video", is3D: true });
            // draw(data, { title: "Status", pieHole: 0.4 }); Donut Piechart Function
        }
    </script>
</asp:Content>
