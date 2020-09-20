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

namespace MvcApplication1.Admin
{
    public partial class About : System.Web.UI.Page
    {
        BL_Panels objBL_Panels = new BL_Panels();
        ML_Panels objML_Panels = new ML_Panels();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            if (!IsPostBack)
            {
                BindCompany();
            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtCompanyDesc.Text = "";
            btnSave.Text = "Save";
        }
        protected void Save(object sender, EventArgs e)
        {
            if (txtCompanyDesc.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Company Description');", true);
            }
            else
            {
                objML_Panels.CompanyName = "FBNPC";
                objML_Panels.CompanyDesc = txtCompanyDesc.Text != "" ? txtCompanyDesc.Text : null;
                objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                objML_Panels.Category = txtCtaegory.Text != "" ? txtCtaegory.Text : null;                
                objML_Panels.ModifyBy = Session["UserName"].ToString();
                objML_Panels.CreatedBy = Session["UserName"].ToString();
                int x = objBL_Panels.BL_InsUpdCompanyAbout(objML_Panels);
                if (x == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved.');", true);
                    BindCompany();
                }
            }
        }
        private void BindCompany()
        {
            DataTable dt = new DataTable();
            dt = objBL_Panels.BL_AboutInfo(objML_Panels);
            if (dt.Rows.Count > 0)
            {
                GrdAbout.DataSource = dt;
                GrdAbout.DataBind();
            }            
        }
        protected void GrdAbout_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdAbout.PageIndex = e.NewPageIndex;
            BindCompany();

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
                int x = objBL_Panels.BL_DeleteCompanyInfo(objML_Panels);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindCompany();
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
                    DataTable dt = new DataTable();
                    objML_Panels.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Panels.BL_UpdateCompanyBind(objML_Panels);
                    if (dt.Rows.Count > 0)
                    {
                        txtCompanyDesc.Text = dt.Rows[0]["CompanyDesc"].ToString();
                        txtCtaegory.Text=dt.Rows[0]["Category"].ToString();
                        lblID.Text = dt.Rows[0]["CompanyID"].ToString();
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