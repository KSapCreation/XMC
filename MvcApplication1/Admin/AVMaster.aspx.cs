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
    public partial class AVMaster : System.Web.UI.Page
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
                dt = objBL_ExamMaster.BL_BindAVMaster(objML_ExamMaster);
                if (dt.Rows.Count > 0)
                {
                    GRDAudioVideo.DataSource = dt;
                    GRDAudioVideo.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GRDAudioVideo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GRDAudioVideo.PageIndex = e.NewPageIndex;
            BindProgramsInfo();

        }
        protected void Save(object sender, EventArgs e)
        {
            if (txtCategory.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Subject Name')", true);
            }
            else if (ddlTrans.SelectedItem.Text == "Select")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Doc Type')", true);
            }
            else if (!fileuploadname.HasFiles)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select File')", true);
            }
            else if (btnSave.Text == "Save")
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                string qry = "";
                qry = "select max(AVID) as AVID from FBNPC_Audio_Video_Master";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Transaction = trans;
                cmd.Clone();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objML_ExamMaster.ID = dr["AVID"].ToString();
                }
                if (clsCommon.myLen(objML_ExamMaster.ID) <= 0)
                {
                    objML_ExamMaster.ID = "AV000000001";
                }
                else
                {
                    objML_ExamMaster.ID = clsCommon.incval(objML_ExamMaster.ID);
                }
                con.Close();
                objML_ExamMaster.SubjectName = txtCategory.Text != "" ? txtCategory.Text : null;
                objML_ExamMaster.TransType = ddlTrans.SelectedItem.Text != "" ? ddlTrans.SelectedItem.Text : null;

                string filePath = fileuploadname.PostedFile.FileName;
                string fileName = Path.GetFileName(filePath);
                string getPath = string.Empty;
                string pathToStore = string.Empty;
                string finalPathToStore = string.Empty;
                string Type = string.Empty;
                string ext = Path.GetExtension(fileName);

                {
                    switch (ext)
                    {
                        case ".avi":
                            Type = "video/avi";
                            break;
                        case ".wav":
                            Type = "audio/wav";
                            break;
                        case ".mp3":
                            Type = "audio/mpeg3";
                            break;
                        case ".mpg":
                        case "mpeg":
                            Type = "video/mpeg";
                            break;
                       
                    }
                    if (ext == ".mp3")
                    {

                        Stream fs = fileuploadname.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                        objML_ExamMaster.FileName = Path.GetFileName(filePath);
                        objML_ExamMaster.FileData = bytes;
                        objML_ExamMaster.FileType = Type;
                        objML_ExamMaster.CreatedBy = Session["UserName"].ToString();
                        objML_ExamMaster.ModifyBy = Session["UserName"].ToString();
                        int x = objBL_ExamMaster.BL_InsUpdAV(objML_ExamMaster);
                        if (x == 1)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved');", true);
                            Reset();
                            BindProgramsInfo();
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please check format, only accept format mp3')", true);
                    }
                }
            }
            else
            {

            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtCategory.Text = "";
            ddlTrans.SelectedItem.Text = "Select";
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
                int x = objBL_ExamMaster.BL_DeleteAVMaster(objML_ExamMaster);
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
                    DataTable dt = new DataTable();
                    objML_ExamMaster.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_ExamMaster.BL_EditAVMaster(objML_ExamMaster);
                    if (dt.Rows.Count > 0)
                    {
                        lblID.Text = dt.Rows[0]["AVID"].ToString();
                        txtCategory.Text = dt.Rows[0]["SubjectName"].ToString();
                        ddlTrans.SelectedItem.Text = dt.Rows[0]["TransType"].ToString();
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