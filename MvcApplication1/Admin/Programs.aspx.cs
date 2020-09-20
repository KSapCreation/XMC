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
    public partial class Programs : System.Web.UI.Page
    {
        BL_Panels objBL_Panels = new BL_Panels();
        ML_Panels objML_Panels = new ML_Panels();
        clsCommon objCommon = new clsCommon();
        bool checkimage = false;

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
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (ddlType.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select type of Transaction')", true);
                }
                else if (txtTitle.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Title')", true);
                }
                else if (txtDesc.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Description')", true);
                }

                else if (btnSave.Text == "Save")
                {
                    if (fileImage.FileName == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select file Image')", true);
                    }
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
                        if (ext != string.Empty)
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
                            objML_Panels.Desc = txtDesc.Text != "" ? txtDesc.Text : null;
                            objML_Panels.CreatedBy = Session["UserName"].ToString();
                            objML_Panels.ModifyBy = Session["UserName"].ToString();
                            if (ddlType.SelectedValue == "P")
                            {
                                objML_Panels.DocType = "P";
                            }
                            else
                            {
                                objML_Panels.DocType = "T";
                            }
                            if (chkImageEdit.Checked == true)
                            {
                                objML_Panels.ImageID = "1";
                            }
                            else
                            {
                                objML_Panels.ImageID = "0";
                            }
                            ValidateFileSize();
                            if (checkimage == true)
                            {
                                throw new System.ArgumentException("Size not correct", "original");
                            }
                            objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                            int x = objBL_Panels.BL_InsProgramsInfo(objML_Panels);
                            if (x == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved')", true);
                                Reset();
                                BindProgramsInfo();
                            }
                        }
                    }
                }
                else
                {
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
                    objML_Panels.Desc = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_Panels.CreatedBy = Session["UserName"].ToString();
                    objML_Panels.ModifyBy = Session["UserName"].ToString();
                    if (chkImageEdit.Checked == true)
                    {
                        if (fileImage.FileName == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select file Image')", true);
                        }
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
                            if (ext != string.Empty)
                            {

                                Stream fs = fileImage.PostedFile.InputStream;
                                BinaryReader br = new BinaryReader(fs);
                                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                                objML_Panels.PicData = bytes;
                                objML_Panels.PicName = Path.GetFileName(filePath);
                                objML_Panels.PicType = Type;
                            }
                        }
                    }
                    if (ddlType.SelectedValue == "P")
                    {
                        objML_Panels.DocType = "P";
                    }
                    else
                    {
                        objML_Panels.DocType = "T";
                    }
                    if (chkImageEdit.Checked == true)
                    {
                        objML_Panels.ImageID = "1";
                    }
                    else
                    {
                        objML_Panels.ImageID = "0";
                    }
                    if (chkImageEdit.Checked == true)
                    {
                        ValidateFileSize();
                    }
                    if (checkimage == true)
                    {
                        throw new System.ArgumentException("Size not correct", "original");
                    }
                    objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                    int x = objBL_Panels.BL_InsProgramsInfo(objML_Panels);
                    if (x == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved');", true);
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
        protected void ValidateFileSize()
        {
            System.Drawing.Image img = System.Drawing.Image.FromStream(fileImage.PostedFile.InputStream);
            int height = img.Height;
            int width = img.Width;
            decimal size = Math.Round(((decimal)fileImage.PostedFile.ContentLength / (decimal)1024), 2);
            if (size > 400)
            {
                lblPictureMsg.Text = "File size must not exceed 400 KB.";
                checkimage = true;
            }
            if (height > 500 || width > 500)
            {
                lblPictureMsg.Text = "Height and Width must not exceed 500px.";
                checkimage = true;
            }
        }
        private void Reset()
        {
            txtTitle.Text = "";
            txtDesc.Text = "";
            ddlType.SelectedIndex = 0;
            chkVisible.Checked = false;
            imgEditFile.ImageUrl = "";
            chkImageEdit.Checked = false;            
            fileImage.Enabled = true;
            btnSave.Text = "Save";
            chkImageEdit.Visible = true;
        }
        //protected void ValidateFileSize(object sender, ServerValidateEventArgs e)
        //{
        //    System.Drawing.Image img = System.Drawing.Image.FromStream(fileImage.PostedFile.InputStream);
        //    int height = img.Height;
        //    int width = img.Width;
        //    decimal size = Math.Round(((decimal)fileImage.PostedFile.ContentLength / (decimal)1024), 2);
        //    if (size > 100)
        //    {
        //        CustomValidator1.ErrorMessage = "File size must not exceed 100 KB.";
        //        e.IsValid = false;
        //    }
        //    if (height > 100 || width > 100)
        //    {
        //        CustomValidator1.ErrorMessage = "Height and Width must not exceed 100px.";
        //        e.IsValid = false;
        //    }
        //}
        protected void BindProgramsInfo()
        {
            try
            {
                DataTable dt = new DataTable();            
                dt = objBL_Panels.BL_ProgramsInfo(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    GrdPrograms.DataSource = dt;
                    GrdPrograms.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GrdPrograms_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdPrograms.PageIndex = e.NewPageIndex;
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
                    Label lblProgramsID = (Label)gvr.FindControl("lblProgramsID");
                    Label lblTitle = (Label)gvr.FindControl("lblTitleName");
                    Label lblActive = new Label();
                    DataTable dt = new DataTable();
                    objML_Panels.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Panels.BL_UpdateInfo(objML_Panels);
                    if (dt.Rows.Count > 0)
                    {
                        ddlType.SelectedValue = dt.Rows[0]["Type"].ToString();
                        txtTitle.Text = dt.Rows[0]["TitleName"].ToString();
                        txtDesc.Text = dt.Rows[0]["TitleDescription"].ToString();
                        lblActive.Text = dt.Rows[0]["IsActive"].ToString();
                        lblID.Text = dt.Rows[0]["ProgramsID"].ToString();
                        if (lblActive.Text == "1")
                        {
                            chkVisible.Checked = true;
                        }
                        else
                        {
                            chkVisible.Checked = false;
                        }
                        btnSave.Text = "Update";
                        chkImageEdit.Visible = true;
                        imgEditFile.ImageUrl = "~/Handler1.ashx?TestimonialID=" + lblProgramsID.Text;

                        if (chkImageEdit.Checked == false)
                        {
                            fileImage.Enabled = false;
                        }
                        else
                        {
                            fileImage.Enabled = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void ImageEdit(object sender, EventArgs e)
        {
            if (chkImageEdit.Checked == true)
            {
                fileImage.Enabled = true;
            }
            else
            {
                fileImage.Enabled = false;
            }
        }
    }
}