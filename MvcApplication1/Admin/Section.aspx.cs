using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;
using System.Data.SqlClient;
using common;
using FBNPC.layers.DataLayers;

namespace MvcApplication1.Admin
{
    public partial class Section : System.Web.UI.Page
    {
        ML_ExamMaster objML_ExamMaster = new ML_ExamMaster();
        BL_ExamMaster objBL_ExamMaster = new BL_ExamMaster();
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
            }
        }
        protected void BindProgramsInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_ExamMaster.BL_BindSection(objML_ExamMaster);
                if (dt.Rows.Count > 0)
                {
                    GrdSection.DataSource = dt;
                    GrdSection.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GrdSection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdSection.PageIndex = e.NewPageIndex;
            BindProgramsInfo();
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtSection.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Section Name');", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select max(SectionID) as SectionID from FBNPC_Sections";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_ExamMaster.ID = dr["SectionID"].ToString();
                    }
                    if (clsCommon.myLen(objML_ExamMaster.ID) <= 0)
                    {
                        objML_ExamMaster.ID = "SEC0000001";
                    }
                    else
                    {
                        objML_ExamMaster.ID = clsCommon.incval(objML_ExamMaster.ID);
                    }
                    con.Close();
                    objML_ExamMaster.SectionName = txtSection.Text != "" ? txtSection.Text : null;
                    objML_ExamMaster.Description = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_ExamMaster.CreatedBy = Session["UserName"].ToString();
                    objML_ExamMaster.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_ExamMaster.BL_InsSection(objML_ExamMaster);
                    if (x == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved!');", true);
                        Reset();
                        BindProgramsInfo();
                    }
                }
                else
                {
                    objML_ExamMaster.ID = lblID.Text != "" ? lblID.Text : null;
                    objML_ExamMaster.SectionName = txtSection.Text != "" ? txtSection.Text : null;
                    objML_ExamMaster.Description = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_ExamMaster.CreatedBy = Session["UserName"].ToString();
                    objML_ExamMaster.ModifyBy = Session["UserName"].ToString();

                    int x = objBL_ExamMaster.BL_InsSection(objML_ExamMaster);
                    if (x == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved!');", true);
                        Reset();
                        BindProgramsInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtSection.Text = "";
            txtDesc.Text = "";
            lblID.Text = "";
            btnSave.Text = "Save";

        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_ExamMaster.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_ExamMaster.BL_DeleteSection(objML_ExamMaster);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindProgramsInfo();
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
                    dt = objBL_ExamMaster.BL_EditSection(objML_ExamMaster);
                    if (dt.Rows.Count > 0)
                    {
                        txtDesc.Text = dt.Rows[0]["Description"].ToString();
                        txtSection.Text = dt.Rows[0]["SectionName"].ToString();
                        lblID.Text = dt.Rows[0]["SectionID"].ToString();
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