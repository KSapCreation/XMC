<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FBNPC.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MvcApplication1.Admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
        <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
        <meta content="Coderthemes" name="author" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />

        <link rel="shortcut icon" href="FBNPC/images/logoTitle.png">
       <link href="FBNPC/css/components-md.css" rel="stylesheet" />
    <link href="FBNPC/css/components-rounded.css" rel="stylesheet" />
        <!--Morris Chart CSS -->
		<link rel="stylesheet" href="FBNPC/plugins/morris/morris.css">

        <!-- Bootstrap core CSS -->
        <link href="FBNPC/css/bootstrap.min.css" rel="stylesheet">
        <!-- Icons CSS -->
        <link href="FBNPC/css/icons.css" rel="stylesheet">
        <!-- Custom styles for this template -->
        <link href="FBNPC/css/style.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="page-contentbar">

                <!-- START PAGE CONTENT -->
                <div id="page-right-content" style="min-height:0px;">

                    <div class="container">
             <div class="row">
                 <div class="col-sm-4">
                     <div class="tab-pane">
                         <div class="portlet box blue">
                             <div class="portlet-title">
                                 <div class="caption">
                                     <i class="fa fa-gift"></i>Exam's Board
                                 </div>
                             </div>
                             <div class="portlet-body form">
                                 <div id="visualization" style="height: 230px;">
                                 </div>
                             </div>
                         </div>
                     </div>
                 </div>
                 <div class="col-sm-4">
                                <div class="tab-pane">
                                    <div class="portlet box blue">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Registration OR Exam
                                            </div>
                                        </div>
                                        <div class="portlet-body form">
                                            <div id="chartdiv" style="height: 230px;">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                 <div class="col-sm-4">
                                <div class="tab-pane">
                                    <div class="portlet box blue">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>No of Audio's Video's
                                            </div>
                                        </div>
                                        <div class="portlet-body form">
                                            <div id="AudioVideo" style="height: 230px;">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
            
                        <!-- end row -->                                       
                 
                  </div>
                        <div class="row">
                            
                            <div class="col-sm-6">
                     <div class="tab-pane">
                         <div class="portlet box blue">
                             <div class="portlet-title">
                                 <div class="caption">
                                     <i class="fa fa-gift"></i>Latest Student's List
                                 </div>
                             </div>
                             <div class="portlet-body form">
                               <asp:Panel ID="pnlUser" runat="server" ScrollBars="Auto">
                          <asp:GridView ID="GrdUserMaster" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" PagerSettings-Mode="Numeric" PageSize="10" ShowFooter="true">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProgramsID" runat="server" Text='<%# Eval("User_Code") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                               
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitleName" runat="server" Text='<%# Eval("First_Name") %>' ></asp:Label>
                                        <asp:Label ID="lbllasteName" runat="server" Text='<%# Eval("Last_Name") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Email ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("E_mail") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Phone No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("Phone") %>' ></asp:Label>
                                    </ItemTemplate>
                                     <FooterStyle HorizontalAlign="Center" />
                                     <FooterTemplate>
                                         <a href="UserMaster.aspx">For More Info</a>
                                     </FooterTemplate>
                                </asp:TemplateField>                                
                            </Columns>
                        </asp:GridView>  
                            </asp:Panel>  
                                  
                             </div>
                         </div>
                     </div>
                 </div>

                            <div class="col-sm-6">
                     <div class="tab-pane">
                         <div class="portlet box blue">
                             <div class="portlet-title">
                                 <div class="caption">
                                     <i class="fa fa-gift"></i>Latest Registration's List
                                 </div>
                             </div>
                             <div class="portlet-body form">
                               <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                          <asp:GridView ID="GrdReg" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" PagerSettings-Mode="Numeric" PageSize="10" ShowFooter="true">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProgramsID" runat="server" Text='<%# Eval("RegisterID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                               
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitleName" runat="server" Text='<%# Eval("FirstName") %>' ></asp:Label>
                                        <asp:Label ID="lbllasteName" runat="server" Text='<%# Eval("LastName") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Email ID & Phone No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("EmailID") %>' ></asp:Label>&nbsp;/
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("PhoneNo") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Special Request">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSpecialRequest" runat="server" Text='<%# Eval("SpecialRequest") %>' ></asp:Label>
                                    </ItemTemplate>
                                     <FooterStyle HorizontalAlign="Center" />
                                     <FooterTemplate>
                                         <a href="RegisterList.aspx">For More Info</a>
                                     </FooterTemplate>
                                </asp:TemplateField>                                
                            </Columns>
                        </asp:GridView>  
                            </asp:Panel>  
                                  
                             </div>
                         </div>
                     </div>
                 </div>
                        </div>
                    </div>
                    <!-- end container -->
                   

                </div>
                <!-- End #page-right-content -->

                <div class="clearfix"></div>

            </div>
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
                url: 'Index.aspx/GetData',
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
                draw(data, { title: "Status: Exam Question List", is3D: true });
            // draw(data, { title: "Status", pieHole: 0.4 }); Donut Piechart Function
        }
    </script>
        <!-- Second Chart-->

    <!-- Second chart -->
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'index.aspx/GetChartData',
                data: '{}',
                success:
                function (response) {
                    drawchart(response.d);
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })
        function drawchart(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].Convertname, dataValues[i].Total]);
            }
            new google.visualization.PieChart(document.getElementById('chartdiv')).
            draw(data, { title: "Status: Registration Vs Exam", is3D: true });
        }
</script>
          <!-- Thrid chart -->
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'index.aspx/GetChartAudioVideoCountData',
                data: '{}',
                success:
                function (response) {
                    drawAudiovideochart(response.d);
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })
        function drawAudiovideochart(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].AudioVideoname, dataValues[i].AudioVideoTotal]);
            }
            new google.visualization.PieChart(document.getElementById('AudioVideo')).
            draw(data, { title: "Staus: Audio Video", is3D: true });
        }
</script>
        </form>
</asp:Content>
