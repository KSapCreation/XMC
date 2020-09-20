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
using System.Data;
using System.Data.SqlClient;
using FBNPC.layers.DataLayers;
using System.IO;


namespace MvcApplication1.Admin
{
    public partial class VideoMaster : System.Web.UI.Page
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
                BindProgramsInfo();
            }
        }
        protected void BindProgramsInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_ExamMaster.BL_BindVideoMaster(objML_ExamMaster);
                if (dt.Rows.Count > 0)
                {
                    GRDVideo.DataSource = dt;
                    GRDVideo.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GRDAudioVideo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GRDVideo.PageIndex = e.NewPageIndex;
            BindProgramsInfo();

        }
        protected void Save(object sender, EventArgs e)
        {
            if (txtCategory.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Subject Name')", true);
            }
            else if (txtVideo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Video Link')", true);
            }

            else if (btnSave.Text == "Save")
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                string qry = "";
                qry = "select max(AudioID) as AudioID from FBNPC_Video_Master";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Transaction = trans;
                cmd.Clone();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objML_ExamMaster.ID = dr["AudioID"].ToString();
                }
                if (clsCommon.myLen(objML_ExamMaster.ID) <= 0)
                {
                    objML_ExamMaster.ID = "VDO000000001";
                }
                else
                {
                    objML_ExamMaster.ID = clsCommon.incval(objML_ExamMaster.ID);
                }
                con.Close();
                objML_ExamMaster.SubjectName = txtCategory.Text != "" ? txtCategory.Text : null;
                objML_ExamMaster.TransType = "Video";
                objML_ExamMaster.Description = txtVideo.Text != "" ? txtVideo.Text : null;
                objML_ExamMaster.CreatedBy = Session["UserName"].ToString();
                objML_ExamMaster.ModifyBy = Session["UserName"].ToString();
                int x = objBL_ExamMaster.BL_InsUpdVideoMaster(objML_ExamMaster);
                if (x == 1)
                {
                    BindProgramsInfo();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data  Saved')", true);                    
                }

            }
            else
            {
                objML_ExamMaster.ID = lblID.Text != "" ? lblID.Text : null;
                objML_ExamMaster.SubjectName = txtCategory.Text != "" ? txtCategory.Text : null;
                objML_ExamMaster.TransType = "Video";
                objML_ExamMaster.Description = txtVideo.Text != "" ? txtVideo.Text : null;
                objML_ExamMaster.CreatedBy = Session["UserName"].ToString();
                objML_ExamMaster.ModifyBy = Session["UserName"].ToString();
                int x = objBL_ExamMaster.BL_InsUpdVideoMaster(objML_ExamMaster);
                if (x == 1)
                {
                    BindProgramsInfo();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data  Saved')", true);
                }
            }
           
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtCategory.Text = "";
            txtVideo.Text = "";
            btnSave.Text = "Save";
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                LinkButton imgEdit = (LinkButton)gvr.FindControl("lnkEdit");
                LinkButton imgDelete = (LinkButton)gvr.FindControl("linkDelete");
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_ExamMaster.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_ExamMaster.BL_DeleteVideoMaster(objML_ExamMaster);
                if (x == 1)
                {
                    BindProgramsInfo();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);                    
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
                    DataTable dt = new DataTable();
                    objML_ExamMaster.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_ExamMaster.BL_EditVideoMaster(objML_ExamMaster);
                    if (dt.Rows.Count > 0)
                    {
                        lblID.Text = dt.Rows[0]["AudioID"].ToString();
                        txtCategory.Text = dt.Rows[0]["SubjectName"].ToString();
                        txtVideo.Text = dt.Rows[0]["FileName"].ToString();
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