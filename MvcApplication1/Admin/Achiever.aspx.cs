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
    public partial class Achiever : System.Web.UI.Page
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
                BindAchieverList();
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
                int x = objBL_Panels.BL_DeleteOtherInfo(objML_Panels);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindAchieverList();
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
                    dt = objBL_Panels.BL_UpdateInfo(objML_Panels);
                    if (dt.Rows.Count > 0)
                    {                      
                        txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                        txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                        txtCity.Text = dt.Rows[0]["City"].ToString();
                        txtCountry.Text = dt.Rows[0]["Country"].ToString();
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