using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using FBNPC;
using System.Data.SqlClient;
using common;
using FBNPC.layers.DataLayers;

namespace MvcApplication1.Admin
{
    public partial class UpdatesInfo : System.Web.UI.Page
    {
        BL_ExamMaster objBL_ExamMaster = new BL_ExamMaster();
        ML_ExamMaster objML_ExamMaster = new ML_ExamMaster();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            if (!IsPostBack)
            {
                BindStudent();
                BindUpdate();
            }
        }
        protected void BindStudent()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_ExamMaster.BL_BindUserMaster(objML_ExamMaster);
                if (dt.Rows.Count > 0)
                {
                    ddlStudent.DataSource = dt;
                    ddlStudent.DataValueField = "User_Code";
                    ddlStudent.DataTextField = "First_Name";
                    ddlStudent.DataBind();
                    ddlStudent.Items.Insert(0, "All");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void Save(object sender, EventArgs e)
        { 
            try
            {
                if (txtDesc.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Description')", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select max(UpdatesID) as UpdatesID from FBNPC_Updates";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_ExamMaster.ID = dr["UpdatesID"].ToString();
                    }
                    if (clsCommon.myLen(objML_ExamMaster.ID) <= 0)
                    {
                        objML_ExamMaster.ID = "UPD0000001";
                    }
                    else
                    {
                        objML_ExamMaster.ID = clsCommon.incval(objML_ExamMaster.ID);
                    }
                    con.Close();
                    objML_ExamMaster.StudentName = ddlStudent.SelectedItem.Value != "" ? ddlStudent.SelectedItem.Value : null;
                    objML_ExamMaster.Description = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_ExamMaster.CreatedBy = Session["UserName"].ToString();
                    objML_ExamMaster.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_ExamMaster.BL_InsUpdates(objML_ExamMaster);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved !')", true);
                        BindUpdate();
                        Reset();
                    }
                }
                else
                {
                    objML_ExamMaster.ID = lblID.Text != "" ? lblID.Text : null;
                    objML_ExamMaster.StudentName = ddlStudent.SelectedItem.Value != "" ? ddlStudent.SelectedItem.Value : null;
                    objML_ExamMaster.Description = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_ExamMaster.CreatedBy = Session["UserName"].ToString();
                    objML_ExamMaster.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_ExamMaster.BL_InsUpdates(objML_ExamMaster);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Updated !')", true);
                        BindUpdate();
                        Reset();
                    }
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        private void Reset()
        {
            txtDesc.Text = "";
            btnSave.Text = "Save";
            ddlStudent.SelectedIndex = 0;
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        protected void BindUpdate()
        {
            DataTable dt = new DataTable();
            dt = objBL_ExamMaster.BL_BindUpdates(objML_ExamMaster);
            if (dt.Rows.Count > 0)
            {
                GrdUpdates.DataSource = dt;
                GrdUpdates.DataBind();
            }
            else
            {
                lblGrdMessage.Text = "No Data Found";
            }
        }
        protected void GrdUpdates_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdUpdates.PageIndex = e.NewPageIndex;
            BindUpdate();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_ExamMaster.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_ExamMaster.BL_DeleteUpdates(objML_ExamMaster);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindUpdate();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblProgramsID");
                    Label lblCategory = new Label();
                    DataTable dt = new DataTable();
                    objML_ExamMaster.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_ExamMaster.BL_EditUpdates(objML_ExamMaster);
                    if (dt.Rows.Count > 0)
                    {
                        txtDesc.Text = dt.Rows[0]["Description"].ToString();
                        ddlStudent.SelectedItem.Value = dt.Rows[0]["StudentName"].ToString();
                        lblID.Text = dt.Rows[0]["UpdatesID"].ToString();
                        btnSave.Text = "Update";
                    }
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
    }
}