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
    public partial class Gallery : System.Web.UI.Page
    {
        BL_Panels objBL_Panels = new BL_Panels();
        ML_Panels objML_Panels = new ML_Panels();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        bool checkimage = false;
        string GalleryType, Actived;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            if (!IsPostBack)
            {
                BindGallery();
                BindCategoryList();
            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtdesc.Text = "";
            txtCompanyName.Text = "";
            ddlCategory.SelectedIndex = 0;
            txtLink.Text = "";
            txtName.Text = "";
            ddlTYpe.SelectedIndex = 0;
            btnSave.Text = "Save";
            fileImage.Enabled = true;
            ddlTYpe.Enabled = true;
            EditImageDiv.Visible = false;
            chkeditImage.Checked = false;
            lblPictureMsg.Text = "";
        }
        private void BindGallery()
        {
            DataTable dt = new DataTable();
            dt = objBL_Panels.BL_GalleryInfo(objML_Panels);
            if (dt.Rows.Count > 0)
            {
                GrdGallery.DataSource = dt;
                GrdGallery.DataBind();
            }
            
        }
        protected void GrdGallery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdGallery.PageIndex = e.NewPageIndex;
            BindGallery();

        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (ddlTYpe.SelectedValue == "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Gallery Type');", true);
                }
                else if (txtName.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill the Name for Display.');", true);
                }
                else if (ddlCategory.SelectedValue == "Select")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill the Category for Display.');", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select max(galleryID) as GalleryID from FBNPC_Gallery_Master";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Panels.ID = dr["GalleryID"].ToString();
                    }
                    if (clsCommon.myLen(objML_Panels.ID) <= 0)
                    {
                        objML_Panels.ID = "G00001";
                    }
                    else
                    {
                        objML_Panels.ID = clsCommon.incval(objML_Panels.ID);
                    }
                    con.Close();

                    objML_Panels.CompanyName = txtCompanyName.Text != "" ? txtCompanyName.Text : null;
                    objML_Panels.Category = ddlCategory.SelectedValue != "" ? ddlCategory.SelectedValue : null;
                    objML_Panels.GalleryType = ddlTYpe.SelectedValue != "" ? ddlTYpe.SelectedValue : null;
                    objML_Panels.CompanyDesc = txtName.Text != "" ? txtName.Text : null;
                    objML_Panels.Link = txtLink.Text != "" ? txtLink.Text : null;
                    objML_Panels.Desc = txtdesc.Text != "" ? txtdesc.Text : null;
                    objML_Panels.CreatedBy = Session["UserName"].ToString();
                    objML_Panels.ModifyBy = Session["UserName"].ToString();
                    if (chkActive.Checked == true)
                    {
                        objML_Panels.ISActive = "1";
                    }
                    else
                    {
                        objML_Panels.ISActive = "0";
                    }

                    //Image Uploader
                    if (ddlTYpe.SelectedValue == "1")
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
                        objML_Panels.ImageID = "0";

                    }

                    if (ddlTYpe.SelectedValue == "2")
                    {
                        int x = objBL_Panels.BL_InsGalleryInfo(objML_Panels);
                        if (x == 1)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved');", true);
                            Reset();
                            BindGallery();
                        }
                    }
                    else
                    {
                        ValidateFileSize();
                        if (checkimage == true)
                        {
                            throw new System.ArgumentException("Size not correct", "original");
                        }
                        int x = objBL_Panels.BL_InsGalleryImageInfo(objML_Panels);
                        if (x == 1)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved');", true);
                            Reset();
                            BindGallery();
                        }
                    }
                }
                else
                {
                    objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                    objML_Panels.CompanyName = txtCompanyName.Text != "" ? txtCompanyName.Text : null;
                    objML_Panels.Category = ddlCategory.SelectedValue != "" ? ddlCategory.SelectedValue : null;
                    objML_Panels.GalleryType = ddlTYpe.SelectedValue != "" ? ddlTYpe.SelectedValue : null;
                    objML_Panels.CompanyDesc = txtName.Text != "" ? txtName.Text : null;
                    objML_Panels.Link = txtLink.Text != "" ? txtLink.Text : null;
                    objML_Panels.Desc = txtdesc.Text != "" ? txtdesc.Text : null;
                    objML_Panels.CreatedBy = Session["UserName"].ToString();
                    objML_Panels.ModifyBy = Session["UserName"].ToString();
                    
                    if (chkActive.Checked == true)
                    {
                        objML_Panels.ISActive = "1";
                    }
                    else
                    {
                        objML_Panels.ISActive = "0";
                    }

                    //Image Uploader
                    if (ddlTYpe.SelectedValue == "1")
                    {
                        if (chkeditImage.Checked == true)
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
                        if (chkeditImage.Checked == true)
                        {
                            objML_Panels.ImageID = "1";
                        }
                        else
                        {
                            objML_Panels.ImageID = "0";
                        }

                    }

                    if (ddlTYpe.SelectedValue == "2")
                    {
                        int x = objBL_Panels.BL_InsGalleryInfo(objML_Panels);
                        if (x == 1)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved');", true);
                            Reset();
                            BindGallery();
                        }
                    }
                    else
                    {
                        if (chkeditImage.Checked == true)
                        {
                            ValidateFileSize();
                        }
                        if (checkimage == true)
                        {
                            throw new System.ArgumentException("Size not correct", "original");
                        }
                        int x = objBL_Panels.BL_InsGalleryImageInfo(objML_Panels);
                        if (x == 1)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved');", true);
                            Reset();
                            BindGallery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void BindCategoryList()
        {
            DataTable dt = new DataTable();            
            dt = objBL_Panels.BL_CategoryBind(objML_Panels);
            if (dt.Rows.Count > 0)
            {
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "Select");
            }
        }
        protected void DdlType(object sender, EventArgs e)
        {
            if (ddlTYpe.SelectedValue == "2")
            {
                VideoUploader.Visible = true;
                ImageUploader.Visible = false;
            }
            else
            {
                VideoUploader.Visible = false;
                ImageUploader.Visible = true;
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
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                LinkButton imgEdit = (LinkButton)gvr.FindControl("lnkEdit");
                LinkButton imgDelete = (LinkButton)gvr.FindControl("linkDelete");
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_Panels.BL_DeleteVideoImage(objML_Panels);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindGallery();
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
                    dt = objBL_Panels.BL_UpdateGalleryInfo(objML_Panels);
                    if (dt.Rows.Count > 0)
                    {
                        lblID.Text = dt.Rows[0]["GalleryID"].ToString();
                        txtCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                        txtName.Text = dt.Rows[0]["Name"].ToString();
                        ddlCategory.SelectedValue = dt.Rows[0]["Category"].ToString();
                        ddlTYpe.SelectedValue = dt.Rows[0]["GalleryType"].ToString();
                        txtLink.Text = dt.Rows[0]["youtubeLink"].ToString();
                        txtdesc.Text = dt.Rows[0]["Description"].ToString();
                        GalleryType = dt.Rows[0]["GalleryType"].ToString();
                        Actived = dt.Rows[0]["isactive"].ToString();

                        if (GalleryType == "1")
                        {
                            ImageUploader.Visible = true;
                            VideoUploader.Visible = false;
                            ddlTYpe.Enabled = false;
                            EditImageDiv.Visible = true;
                            fileImage.Enabled = false;
                            byte[] bytes = (byte[])dt.Rows[0]["FileData"];
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            imgEditFile.ImageUrl = "data:" + dt.Rows[0]["FileType"] + ";base64," + base64String;
                        }
                        else
                        {
                            ImageUploader.Visible = false;
                            VideoUploader.Visible = true;
                            ddlTYpe.Enabled = false;
                            EditImageDiv.Visible = false;
                        }
                        if (Actived == "1")
                        {
                            chkActive.Checked = true;
                        }
                        else
                        {
                            chkActive.Checked = false;
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
        protected void ImageEdition(object sender, EventArgs e)
        {
            if (chkeditImage.Checked == true)
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