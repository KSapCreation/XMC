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
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace MvcApplication1.Admin
{
    public partial class Others : System.Web.UI.Page
    {
        BL_Panels objBL_Panels = new BL_Panels();
        ML_Panels objML_Panels = new ML_Panels();
        clsCommon objCommon = new clsCommon();

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
        private void Reset()
        {
            txtTitle.Text = "";
            txtDesc.Text = "";
            chkVisible.Checked = false;
            txtID.Text = "";

        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtTitle.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Title')", true);
                }
                else if (txtDesc.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Description')", true);
                }
                else
                {
                    string filePath = fileImage.PostedFile.FileName;
                    string fileName = Path.GetFileName(filePath);
                    string getPath = string.Empty;
                    string pathToStore = string.Empty;
                    string finalPathToStore = string.Empty;
                    string Type = string.Empty;
                    string ext = Path.GetExtension(fileName);

                    {
                        switch (ext)
                        {
                            case ".doc":
                                Type = "application/vnd.ms-word";
                                break;
                            case ".docx":
                                Type = "application/vnd.ms-word";
                                break;
                            case ".xls":
                                Type = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                Type = "application/vnd.ms-excel";
                                break;
                            case ".jpg":
                                Type = "image/jpg";
                                break;
                            case ".png":
                                Type = "image/png";
                                break;
                            case ".gif":
                                Type = "image/gif";
                                break;
                            case ".pdf":
                                Type = "application/pdf";
                                break;
                            case ".zip":
                                Type = "application/zip";
                                break;
                            case ".rar":
                                Type = "application/rar";
                                break;
                        }
                       // if (ext != string.Empty)
                        {

                            Stream fs = fileImage.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            objML_Panels.Title = txtTitle.Text != "" ? txtTitle.Text : null;
                            objML_Panels.Desc = txtDesc.Text != "" ? txtDesc.Text : null;
                            if (chkVisible.Checked == true)
                            {
                                objML_Panels.ISActive = "1";
                            }
                            else
                            {
                                objML_Panels.ISActive = "0";
                            }
                            objML_Panels.PicData = bytes;
                            objML_Panels.PicName = Path.GetFileName(filePath);
                            objML_Panels.PicType = Type;
                            objML_Panels.CreatedBy = Session["UserName"].ToString();
                            objML_Panels.ModifyBy = Session["UserName"].ToString();
                            objML_Panels.DocType = "O";
                            objML_Panels.ID = txtID.Text != "" ? txtID.Text : null;
                            int x = objBL_Panels.BL_InsProgramsInfo(objML_Panels);
                            if (x == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('User Saved')", true);
                                Reset();
                                BindProgramsInfo();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }

        }
        protected void BindProgramsInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Panels.ID = "O";
                dt = objBL_Panels.BL_ProgramsInfo(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    GrdOthers.DataSource = dt;
                    GrdOthers.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GrdOthers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdOthers.PageIndex = e.NewPageIndex;
            BindProgramsInfo();

        }

        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                LinkButton imgEdit = (LinkButton)gvr.FindControl("lnkEdit");
                LinkButton imgDelete = (LinkButton)gvr.FindControl("linkDelete");
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                Label lblTitle = (Label)gvr.FindControl("lblTitleName");
                DataTable dt = new DataTable();
                objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_Panels.BL_DeleteOtherInfo(objML_Panels);
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
                    LinkButton imgEdit = (LinkButton)gvr.FindControl("lnkEdit");
                    Label lblID = (Label)gvr.FindControl("lblProgramsID");
                    Label lblTitle = (Label)gvr.FindControl("lblTitleName");
                    Label lblActive = new Label();
                    DataTable dt = new DataTable();
                    objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                    dt = objBL_Panels.BL_UpdateInfo(objML_Panels);
                    if (dt.Rows.Count > 0)
                    {
                        txtID.Text = dt.Rows[0]["ProgramsID"].ToString();
                        txtTitle.Text = dt.Rows[0]["TitleName"].ToString();
                        txtDesc.Text = dt.Rows[0]["TitleDescription"].ToString();
                        lblActive.Text = dt.Rows[0]["IsActive"].ToString();
                        if (lblActive.Text == "1")
                        {
                            chkVisible.Checked = true;
                        }
                        else
                        {
                            chkVisible.Checked = false;
                        }
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