<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FBNPC.Master" AutoEventWireup="true" CodeBehind="Achiever.aspx.cs" Inherits="MvcApplication1.Admin.Achiever" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
        <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
        <meta content="Coderthemes" name="author" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />

        <link rel="shortcut icon" href="../assets/demo-data/logoTitle.png">
     <link href="FBNPC/css/components-md.css" rel="stylesheet" />
    <link href="FBNPC/css/components-rounded.css" rel="stylesheet" />
        <!-- Bootstrap core CSS -->
    <link href="FBNPC/css/components.css" rel="stylesheet" />
        <!-- Bootstrap core CSS -->
        <link href="FBNPC/css/bootstrap.min.css" rel="stylesheet">
        <!-- Icons CSS -->
        <link href="FBNPC/css/icons.css" rel="stylesheet">
        <!-- Custom styles for this template -->
        <link href="FBNPC/css/style.css" rel="stylesheet">
    <title>:: FBNPC Our Programs ::</title>
    <script type="text/javascript" src="tiny_mce/tiny_mce.js"></script>
<%-- <script type="text/javascript" language="javascript">
         tinyMCE.init({
             // General options
             mode: "textareas",
             theme: "simple",
             plugins: "pagebreak,style,layer,table,save,advhr,advlink,emotions,iespell",

         });
     </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>

                    <div class="container">    
                                                             
                            <div class="tab-pane" id="Userinfo" runat="server" visible="true">
                                <div class="portlet box blue">
                                     <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>Our Achievers
                                            </div>
                                        </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                       
                                        <div class="form-body">
                                                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>                                                                     
                                         <div class="row">                                               
                                                <div class="col-md-4">
                                                    <div>
                                                        <label class="control-label">First Name</label>
                                                       <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </div>
                                                </div>  
                                              <div class="col-md-4">
                                                    <div>
                                                        <label class="control-label">Last Name</label>
                                                       <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </div>
                                                </div>  
                                             <div class="col-md-4">
                                                    <div>
                                                        <label class="control-label">Doc Type</label>
                                                       <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoCompleteType="Disabled">
                                                           <asp:ListItem Value="Achiever" Text="Achiever"></asp:ListItem>
                                                           <asp:ListItem Value="Team" Text="Team"></asp:ListItem>
                                                       </asp:DropDownList>
                                                    </div>
                                                </div>  
                                             </div>
                                             
                                            
                                             <div class="row">
                                                   <div class="col-md-4">
                                                    <div>
                                                        <label class="control-label">Country Name</label>
                                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" OnSelectedIndexChanged="BindStateInfo" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                 <div class="col-md-4">
                                                     <div>
                                                         <label class="control-label">State Name</label>
                                                         <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" OnSelectedIndexChanged="BindCityInfo" AutoPostBack="true"></asp:DropDownList>
                                                     </div>
                                                 </div>
                                                  <div class="col-md-4">
                                                     <div>
                                                         <label class="control-label">City Name</label>
                                                         <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
                                                     </div>
                                                 </div>
                                               </div>
                                            <div class="row">                                     
                                                 <div class="col-md-4">
                                                    <div>
                                                        <label class="control-label">On Landing Page</label>
                                                       <asp:CheckBox ID="chkLandingPage" runat="server" CssClass="form-control" />
                                                    </div>
                                                </div>  
                                             </div>
                                            <div class="row">
                                             <div class="col-md-12">
                                                    <div>
                                                        <label class="control-label">Description
                                                            <span style="color:red;"> (only 130 words)</span>
                                                        </label>
                                                       <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>


                                                    </div>
                                                </div>    
                                            </div>
                                             <div class="row">
                                                <div class="col-md-4">
                                                    <div>
                                                        <label class="control-label">Is Active</label>
                                                       <asp:CheckBox ID="chkVisible" runat="server" CssClass="form-control" />
                                                    </div>
                                                </div>                                              
                                             <div class="col-md-4">
                                                    <div>
                                                        <label class="control-label">Image Upload</label>
                                                       <asp:FileUpload ID="fileImage" runat="server" CssClass="form-control" />
                                                        <asp:Label ID="lblPictureMsg" runat="server" ForeColor="Red"></asp:Label>
                                                    </div>
                                                </div>   
                                                 <div class="col-md-4">
                                                     <div>
                                                         <asp:CheckBox ID="chkImageEdit" runat="server" OnCheckedChanged="ImageEdit" AutoPostBack="true" Text="Edit Image" />
                                                         <asp:Image ID="imgEditFile" runat="server" ImageUrl='<%# "~/Handler1.ashx?ProgramEditID=" + Eval("ProgramsID")%>' Width="100px" BorderStyle="Groove" BorderColor="#000000" />

                                                     </div>
                                                 </div>    
                                            </div>
                                        </div>
                                        <div class="form-actions right">
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn default" Text="Cancel" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn blue" OnClick="Save"  />

                                        </div>
                                    </div>
                                </div>
                            </div>      
                        <!-- Grid Values -->  
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#ff3300"></asp:Label>
                          <asp:GridView ID="GrdPrograms" runat="server" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GrdPrograms_PageIndexChanging" PagerSettings-Mode="Numeric" PageSize="10">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProgramsID" runat="server" Text='<%# Eval("AchieverID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField Visible="true" HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" OnClick="Update"><img src="FBNPC/images/edit.png" width="20px" alt="" /></asp:LinkButton>&nbsp;&nbsp;
                                        <asp:LinkButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" OnClick="Delete"> <img src="FBNPC/images/delete.png" width="20px" alt="" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="First Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitleName" runat="server" Text='<%# Eval("firstName") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldesc" runat="server" Text='<%# Eval("Description") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Doc type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocType" runat="server" Text='<%# Eval("DocType") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Active">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("IsActive") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                <asp:TemplateField HeaderText="Update By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblModifyBy" runat="server" Text='<%# Eval("ModifyBy") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Update Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblModifyDate" runat="server" Text='<%# Eval("ModifyDate") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>  
                    </div>
                    <!-- end container -->
                                

                <div class="clearfix"></div>

            
        </form>
</asp:Content>
