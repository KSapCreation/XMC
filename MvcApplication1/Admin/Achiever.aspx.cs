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
using FBNPC.layers.DataLayers;

namespace MvcApplication1.Admin
{
    public partial class Achiever : System.Web.UI.Page
    {
        BL_Panels objBL_Panels = new BL_Panels();
        ML_Panels objML_Panels = new ML_Panels();
        clsCommon objCommon = new clsCommon();
        bool checkimage = false;
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            if (!IsPostBack)
            {
                BindAchieverList();
                BindCountryInfo();
            }
        }
        protected void BindStateInfo(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Panels.ID = ddlCountry.SelectedValue != "" ? ddlCountry.SelectedValue : null;
                dt = objBL_Panels.BL_StateCountryWiseBind(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    ddlState.DataSource = dt;
                    ddlState.DataValueField = "StateID";
                    ddlState.DataTextField = "Name";
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, "Select State");
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void BindCityInfo(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Panels.ID = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                dt = objBL_Panels.BL_CityStateWiseBind(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    ddlCity.DataSource = dt;
                    ddlCity.DataValueField = "CityID";
                    ddlCity.DataTextField = "Name";
                    ddlCity.DataBind();
                    ddlCity.Items.Insert(0, "Select City");
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void BindCountryInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Panels.BL_CountryBind(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    ddlCountry.DataSource = dt;
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataTextField = "Name";
                    ddlCountry.DataBind();
                    ddlCountry.Items.Insert(0, "Select Country");
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void BindAchieverList()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Panels.BL_BindAchieverList(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    GrdPrograms.DataSource = dt;
                    GrdPrograms.DataBind();
                }
                else
                {
                    lblMessage.Text = "No Record found";
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
            BindAchieverList();
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
                int x = objBL_Panels.BL_DeleteAchieverInfo(objML_Panels);
                if (x == 1)
                {
                    BindAchieverList();
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
                    LinkButton imgEdit = (LinkButton)gvr.FindControl("lnkEdit");
                    Label lblProgramsID = (Label)gvr.FindControl("lblProgramsID");
                    Label lblTitle = (Label)gvr.FindControl("lblTitleName");
                    Label lblActive = new Label();
                    DataTable dt = new DataTable();
                    int lblOnLandingPage;
                    objML_Panels.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Panels.BL_UpdateAchieverInfo(objML_Panels);
                    if (dt.Rows.Count > 0)
                    {                      
                        txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                        txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                        ddlCity.SelectedValue = dt.Rows[0]["City"].ToString();
                        ddlCountry.SelectedValue = dt.Rows[0]["Country"].ToString();
                        ddlState.SelectedValue = dt.Rows[0]["State"].ToString();
                        lblOnLandingPage = int.Parse(dt.Rows[0]["OnlandingPage"].ToString());
                        if (lblOnLandingPage == 1)
                        {
                            chkLandingPage.Checked = true;
                        }
                        else
                        {
                            chkLandingPage.Checked = false;
                        }
                        txtDesc.Text = dt.Rows[0]["Description"].ToString();
                        lblActive.Text = dt.Rows[0]["IsActive"].ToString();
                        lblID.Text = dt.Rows[0]["AchieverID"].ToString();
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
                        imgEditFile.ImageUrl = "~/Handler1.ashx?AchieverID=" + lblProgramsID.Text;

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
        protected void Save(object sender, EventArgs e)
        {
            try
            {               
                if (txtFirstName.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill the Name.');", true);
                }
                else if (ddlCity.SelectedValue == "Select City")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select City.');", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select max(AchieverID) as AchieverID from KSCN_Achiever_Master";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Panels.ID = dr["AchieverID"].ToString();
                    }
                    if (clsCommon.myLen(objML_Panels.ID) <= 0)
                    {
                        objML_Panels.ID = "Achiev000001";
                    }
                    else
                    {
                        objML_Panels.ID = clsCommon.incval(objML_Panels.ID);
                    }
                    con.Close();

                    objML_Panels.FirstName = txtFirstName.Text != "" ? txtFirstName.Text : null;
                    objML_Panels.LastName = txtLastName.Text != "" ? txtLastName.Text : null;
                    if (chkLandingPage.Checked == true)
                    {
                        objML_Panels.OnLandingPage = 1;
                    }
                    else
                    {
                        objML_Panels.OnLandingPage = 0;
                    }

                    objML_Panels.Desc = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_Panels.CityID = ddlCity.SelectedValue != "" ? ddlCity.SelectedValue : null;
                    objML_Panels.CountryID = ddlCountry.SelectedValue != "" ? ddlCountry.SelectedValue : null;

                    if (chkVisible.Checked == true)
                    {
                        objML_Panels.ISActive = "1";
                    }
                    else
                    {
                        objML_Panels.ISActive = "0";
                    }


                    //Image Uploader
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
                    objML_Panels.ModifyBy = Session["UserName"].ToString();
                    objML_Panels.CreatedBy = Session["UserName"].ToString();

                    objML_Panels.ImageID = "0";

                    objML_Panels.StateID = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                    objML_Panels.DocType = ddlType.SelectedValue != "" ? ddlType.SelectedValue : null;
                    ValidateFileSize();
                        if (checkimage == true)
                        {
                            throw new System.ArgumentException("Size not correct", "original");
                        }
                        int x = objBL_Panels.BL_InsAchieverInfo(objML_Panels);
                    if (x == 1)
                    {
                        Reset();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved');", true);

                    }
                    
                }
                else
                {
                    objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                    objML_Panels.FirstName = txtFirstName.Text != "" ? txtFirstName.Text : null;
                    objML_Panels.LastName = txtLastName.Text != "" ? txtLastName.Text : null;

                    
                    objML_Panels.CityID = ddlCity.SelectedValue != "" ? ddlCity.SelectedValue : null;
                    objML_Panels.CountryID = ddlCountry.SelectedValue != "" ? ddlCountry.SelectedValue : null;
                    if (chkLandingPage.Checked == true)
                    {
                        objML_Panels.OnLandingPage = 1;
                    }
                    else
                    {
                        objML_Panels.OnLandingPage = 0;
                    }
                    objML_Panels.Desc = txtDesc.Text != "" ? txtDesc.Text : null;
                    if (chkVisible.Checked == true)
                    {
                        objML_Panels.ISActive = "1";
                    }
                    else
                    {
                        objML_Panels.ISActive = "0";
                    }
                    
                    

                    if (chkImageEdit.Checked == true)
                    {
                        objML_Panels.ImageID = "1";
                    }
                    else
                    {
                        objML_Panels.ImageID = "0";
                    }
                    objML_Panels.StateID = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                    //Image Uploader
                    if (chkImageEdit.Checked == true)
                        {
                            ValidateFileSize();
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
                        if (checkimage == true)
                        {
                            throw new System.ArgumentException("Size not correct", "original");
                        }
                    objML_Panels.CreatedBy = Session["UserName"].ToString();
                    objML_Panels.ModifyBy = Session["UserName"].ToString();

                    int x = objBL_Panels.BL_InsAchieverInfo(objML_Panels);
                    if (x == 1)
                    {
                        Reset();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved');", true);
                    }
                   
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void Reset()
        {
            txtDesc.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            chkVisible.Checked = false;
            chkLandingPage.Checked = false;
            chkImageEdit.Checked = false;

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
            if (height > 300 || width > 200)
            {
                lblPictureMsg.Text = "Please Height 300px and Width 200px.";
                checkimage = true;
            }
        }
    }
}