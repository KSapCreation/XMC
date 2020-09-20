using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.ModelLayer;
using MvcApplication1.Admin.Layer.Businesslayer;
using common;
using FBNPC;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using FBNPC.layers.DataLayers;

namespace MvcApplication1.Admin
{
    public partial class UserMaster : System.Web.UI.Page
    {
        BL_Login objBL_Login=new BL_Login();
        ML_Login objML_Logn = new ML_Login();
        CommonClass objCommonClass = new CommonClass();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            if (!IsPostBack)
            {
                BindProgramsInfo();
                BindExamList();
            }
        }
        protected void PraticeMethod(object sender, EventArgs e)
        {
            if (chkPratice.Checked == true)
            {
                ddlExamList.Enabled = false;
            }
            else
            {
                ddlExamList.Enabled = true;
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtFirstName.Text == "")
                {
                    txtFirstName.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill First Name')", true);
                }
                else if (btnSave.Text == "Save")
                {
                    if (txtPwd.Text == "")
                    {
                        txtPwd.Focus();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Password')", true);
                    }
                    else if (txtPhoneNo.Text == "")
                    {
                        txtPhoneNo.Focus();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Phone No')", true);
                    }
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select max(User_Code) as User_Code from fbnpc_user_master";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Logn.ID = dr["User_Code"].ToString();
                    }
                    if (clsCommon.myLen(objML_Logn.ID) <= 0)
                    {
                        objML_Logn.ID = "USER00000001";
                    }
                    else
                    {
                        objML_Logn.ID = clsCommon.incval(objML_Logn.ID);
                    }
                    con.Close();
                    objML_Logn.UserName = txtFirstName.Text != "" ? txtFirstName.Text : "";
                    objML_Logn.LastName = txtLastName.Text != "" ? txtLastName.Text : "";
                    objML_Logn.Gender = ddlGender.SelectedItem.Text != "" ? ddlGender.SelectedItem.Text : "";
                    objML_Logn.DOB = txtdate.Text != "" ? txtdate.Text : "";
                    objML_Logn.Password = objCommonClass.GetEncrptPassword(txtPwd.Text);
                    objML_Logn.CPwd = objCommonClass.GetEncrptPassword(txtCPwd.Text);
                    objML_Logn.EmailID = txtEmail.Text != "" ? txtEmail.Text : "";
                    objML_Logn.PhoneNo = txtPhoneNo.Text != "" ? txtPhoneNo.Text : "";
                    objML_Logn.CreatedBy = Session["UserName"].ToString();
                    objML_Logn.ModifyBy = Session["UserName"].ToString();
                    objML_Logn.IPAddress = GetIPAddress();
                    //objML_Logn.ID = lblID.Text != "" ? lblID.Text : null;
                    objML_Logn.ExamName = ddlExamList.SelectedItem.Value != "" ? ddlExamList.SelectedItem.Value : null;
                    if (chkPratice.Checked == true)
                    {
                        objML_Logn.Practice = "1";
                    }
                    else
                    {
                        objML_Logn.Practice = "0";
                    }
                    if (chhkAdminGroup.Checked == true)
                    {
                        objML_Logn.AdminGroup = "1";
                    }
                    else
                    {
                        objML_Logn.AdminGroup = "0";
                    }
                    int x = objBL_Login.BL_InsUpdUserDetail(objML_Logn);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('User Saved')", true);
                        BindProgramsInfo();
                        Reset();
                    }
                }
                else
                {
                    objML_Logn.UserName = txtFirstName.Text != "" ? txtFirstName.Text : "";
                    objML_Logn.LastName = txtLastName.Text != "" ? txtLastName.Text : "";
                    objML_Logn.Gender = ddlGender.SelectedItem.Text != "" ? ddlGender.SelectedItem.Text : "";
                    objML_Logn.DOB = txtdate.Text != "" ? txtdate.Text : "";
                    objML_Logn.Password = objCommonClass.GetEncrptPassword(txtPwd.Text);
                    objML_Logn.CPwd = objCommonClass.GetEncrptPassword(txtCPwd.Text);
                    objML_Logn.EmailID = txtEmail.Text != "" ? txtEmail.Text : "";
                    objML_Logn.PhoneNo = txtPhoneNo.Text != "" ? txtPhoneNo.Text : "";
                    objML_Logn.CreatedBy = Session["UserName"].ToString();
                    objML_Logn.ModifyBy = Session["UserName"].ToString();
                    objML_Logn.IPAddress = GetIPAddress();
                    objML_Logn.ID = lblID.Text != "" ? lblID.Text : null;
                    objML_Logn.ExamName = ddlExamList.SelectedItem.Value != "" ? ddlExamList.SelectedItem.Value : null;
                    if (chkPratice.Checked == true)
                    {
                        objML_Logn.Practice = "1";
                    }
                    else
                    {
                        objML_Logn.Practice = "0";
                    }
                    if (chhkAdminGroup.Checked == true)
                    {
                        objML_Logn.AdminGroup = "1";
                    }
                    else
                    {
                        objML_Logn.AdminGroup = "0";
                    }
                    int x = objBL_Login.BL_InsUpdUserDetail(objML_Logn);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('User Saved')", true);
                        BindProgramsInfo();
                        Reset();
                    }
                }
            
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('"+ ex.Message.ToString() +"')", true);
            }

        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtCPwd.Text = "";
            txtdate.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhoneNo.Text = "";
            txtPwd.Text = "";
            btnSave.Text = "Save";
            ddlExamList.SelectedIndex = 0;
            chkPratice.Checked = false;
            lblID.Text = "";
            ddlExamList.Enabled = true;
            chhkAdminGroup.Checked = false;
        }
        private string GetIPAddress()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            Console.WriteLine(hostName);
            // Get the IP
            string strIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return strIP;

        }
        protected void BindProgramsInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Login.BL_UserList(objML_Logn);
                if (dt.Rows.Count > 0)
                {
                    GrdUserMaster.DataSource = dt;
                    GrdUserMaster.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GrdUserMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdUserMaster.PageIndex = e.NewPageIndex;
            BindProgramsInfo();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                LinkButton imgEdit = (LinkButton)gvr.FindControl("lnkEdit");
                LinkButton imgDelete = (LinkButton)gvr.FindControl("linkDelete");
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_Logn.ID = lblID.Text != "" ? lblID.Text : null;
                dt = objBL_Login.BL_ChecUser_UsedOrNot(objML_Logn);
                if (dt.Rows.Count < 0)
                {
                    int x = objBL_Login.BL_DeleteUser(objML_Logn);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                        BindProgramsInfo();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Already User Used for exam !')", true);
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    LinkButton imgEdit = (LinkButton)gvr.FindControl("lnkEdit");
                    Label lblProgramsID = (Label)gvr.FindControl("lblProgramsID");
                    Label lblTitle = (Label)gvr.FindControl("lblTitleName");
                    Label lblActive = new Label();
                    DataTable dt = new DataTable();
                    objML_Logn.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Login.BL_EditUser(objML_Logn);
                    if (dt.Rows.Count > 0)
                    {
                        txtFirstName.Text = dt.Rows[0]["First_Name"].ToString();
                        txtLastName.Text = dt.Rows[0]["Last_Name"].ToString();
                        txtEmail.Text = dt.Rows[0]["E_mail"].ToString();
                        txtdate.Text = dt.Rows[0]["DOB"].ToString();
                        txtPhoneNo.Text = dt.Rows[0]["Phone"].ToString();
                        lblID.Text = dt.Rows[0]["User_Code"].ToString();
                        ddlGender.SelectedItem.Text = dt.Rows[0]["Gender"].ToString();
                        ddlExamList.SelectedValue = dt.Rows[0]["ExamName"].ToString();
                        btnSave.Text = "Update";
                        string Practice = "";
                        Practice = dt.Rows[0]["PraticeType"].ToString();
                        string AdminGroup = "";
                        AdminGroup = dt.Rows[0]["AdminGroup"].ToString();
                        if (Practice == "0")
                        {
                            chkPratice.Checked = false;
                            ddlExamList.Enabled = true;
                        }
                        else
                        {
                            chkPratice.Checked = true;
                            ddlExamList.Enabled = false;
                        }
                        if (AdminGroup == "0")
                        {
                            chhkAdminGroup.Checked = false;
                        }
                        else
                        {
                            chhkAdminGroup.Checked = true;
                        }
                                              
                    }
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void BindExamList()
        {
            DataTable dt = new DataTable();
            dt = objBL_Login.BL_BindExamList(objML_Logn);
            if (dt.Rows.Count > 0)
            {
                ddlExamList.DataSource = dt;
                ddlExamList.DataValueField = "ExamID";
                ddlExamList.DataTextField = "ExamName";
                ddlExamList.DataBind();
                ddlExamList.Items.Insert(0, "Select");
            }
        }
    }
}