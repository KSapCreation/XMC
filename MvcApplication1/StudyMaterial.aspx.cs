using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;
using FBNPC;
using System.Data.SqlClient;
using common;
using FBNPC.layers.DataLayers;

namespace MvcApplication1
{
    public partial class StudyMaterial : System.Web.UI.Page
    {
        ML_SiteDetail objMLSiteDetail = new ML_SiteDetail();
        BL_SiteDetail objBL_SiteDetail = new BL_SiteDetail();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStudyBooks();
                BindCategory();
                BindMenu();
            }
        }
        protected void BindStudyBooks()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_SiteDetail.BL_BindStudyBooks(objMLSiteDetail);
                if (dt.Rows.Count > 0)
                {
                    dlStudyMaterial.DataSource = dt;
                    dlStudyMaterial.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void BindCategory()
        {
            DataTable dt = new DataTable();
            objMLSiteDetail.ID = "Study Materials";
            dt = objBL_SiteDetail.BL_BindCategory(objMLSiteDetail);
            if (dt.Rows.Count > 0)
            {
                //ddlCategry.DataSource = dt;
                //ddlCategry.DataValueField = "CategoryID";
                //ddlCategry.DataTextField = "Name";
                //ddlCategry.DataBind();
                //ddlCategry.Items.Insert(0, "Select");
            }
        }
        protected void BindMenu()
        {
            DataTable dt = new DataTable();
            dt = objBL_SiteDetail.BL_DLMenu(objMLSiteDetail);
            if (dt.Rows.Count > 0)
            {
                DLMenu.DataSource = dt;
                DLMenu.DataBind();
            }
        }
        protected void EditShow(object sender, EventArgs e)
        {
            DataListItem gvr = (DataListItem)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblID");
                DataTable dt = new DataTable();
                objMLSiteDetail.ID = lblID.Text != "" ? lblID.Text : null;
                dt = objBL_SiteDetail.BL_DLMenu(objMLSiteDetail);
                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("Detail.aspx?ID=" + lblID.Text, true);
                }
            }
        }

    }
}