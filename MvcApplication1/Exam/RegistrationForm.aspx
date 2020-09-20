<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="MvcApplication1.Exam.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: FBNPC : Registration ::</title>
     <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
        <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
        <meta content="Coderthemes" name="author" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    
        <link rel="shortcut icon" href="../assets/demo-data/logo_fbnpc.png">
     <link href="../Admin/FBNPC/css/components-md.css" rel="stylesheet" />
    <link href="../Admin/FBNPC/css/components-rounded.css" rel="stylesheet" />
        <!-- Bootstrap core CSS -->
    <link href="../Admin/FBNPC/css/components.css" rel="stylesheet" />
        <!-- Bootstrap core CSS -->
        <link href="../Admin/FBNPC/css/bootstrap.min.css" rel="stylesheet">
        <!-- Icons CSS -->
        <link href="../Admin/FBNPC/css/icons.css" rel="stylesheet">
        <!-- Custom styles for this template -->
        <link href="../Admin/FBNPC/css/style.css" rel="stylesheet">
           <script type="text/javascript">
               document.addEventListener("contextmenu", function (e) {
                   e.preventDefault();
               }, false);
    </script>
     
</head>
<body style="background-color: white;">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-3"><a href="../Default.aspx">
                    <img src="../assets/demo-data/logo_fbnpc_new.png" alt="FBNPC" /></a>
                </div>
                <div class="col-md-9">
                    <p style="font-weight: 500; color: #b33131; font-size: 24px; padding-top: 20px;">Future Building Nursing Prep Center                                                 <span style="font-weight: 500; color: #498c16; font-size: 24px;">(Register Now) </span></p>
                </div>
            </div>
            <div class="tab-pane" id="Userinfo" runat="server" visible="true">
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            Personal Information
                        </div>
                    </div>
                    <div class="portlet-body form">
                        <!-- BEGIN FORM-->

                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div>
                                        <label class="control-label">First Name</label>
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" AutoCompleteType="Disabled" required=""></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div>
                                        <label class="control-label">Last Name</label>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div>
                                        <label class="control-label">Address</label>
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div>
                                        <label class="control-label">City</label>
                                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" AutoCompleteType="Disabled" required=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div>
                                        <label class="control-label">State / Province</label>
                                        <asp:TextBox ID="txtState" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div>
                                        <label class="control-label">Postal / Zip Code</label>
                                        <asp:TextBox ID="txtPostal" runat="server" CssClass="form-control" AutoCompleteType="Disabled" required=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div>
                                        <label class="control-label">Phone No</label>
                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" AutoCompleteType="Disabled" required="" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div>
                                        <label class="control-label">Email ID</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Email" required=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div>
                                        <label class="control-label">Class You are Opting for</label>
                                        <asp:RadioButtonList ID="rbtnlist" runat="server" RepeatDirection="Vertical" RepeatLayout="UnorderedList">
                                            <asp:ListItem Value="1" Text="NCLEX" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="CPNRE"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="IELTS"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="CELBAN"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="OTHERS"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div>
                                        <label class="control-label">Please specify tentative date of exam you intend to write:</label>
                                        <asp:TextBox ID="txtExamDate" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div>
                                        <label class="control-label">Specific/Special Request:</label>
                                        <asp:TextBox ID="txtSpecialReq" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions right">
                                <asp:Button ID="btnSave" runat="server" Text="Register Now" CssClass="btn blue" OnClick="Register" />

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
