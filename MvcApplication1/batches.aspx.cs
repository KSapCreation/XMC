using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using FBNPC;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace MvcApplication1
{
    public partial class batches : System.Web.UI.Page
    {
        BL_SiteDetail objBL_SiteDetail = new BL_SiteDetail();
        ML_SiteDetail objML_SiteDetail = new ML_SiteDetail();
        CommonClass objCommonClass = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindProgramsInfo();
                BindBatchInfo();
                BindMenu();
            }
        }
        protected void BindProgramsInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_SiteDetail.BL_BindBatches(objML_SiteDetail);
                if (dt.Rows.Count > 0)
                {
                    GrdBatch.DataSource = dt;
                    GrdBatch.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void BindBatchInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_SiteDetail.BL_BindBatches(objML_SiteDetail);
                if (dt.Rows.Count > 0)
                {
                    ddlBatch.DataSource = dt;
                    ddlBatch.DataTextField = "BatchName";
                    ddlBatch.DataValueField = "BatchID";
                    ddlBatch.DataBind();
                    ddlBatch.Items.Insert(0, "Select");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Search(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_SiteDetail.ID = ddlBatch.SelectedValue != "" ? ddlBatch.SelectedValue : null;
                dt = objBL_SiteDetail.BL_SearchBatches(objML_SiteDetail);
                if (dt.Rows.Count > 0)
                {
                    GrdBatch.DataSource = dt;
                    GrdBatch.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this,this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            ddlBatch.SelectedIndex = 0;
            BindProgramsInfo();
        }
        protected void BindMenu()
        {
            DataTable dt = new DataTable();
            dt = objBL_SiteDetail.BL_DLMenu(objML_SiteDetail);
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
                objML_SiteDetail.ID = lblID.Text != "" ? lblID.Text : null;
                dt = objBL_SiteDetail.BL_DLMenu(objML_SiteDetail);
                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("Detail.aspx?ID=" + lblID.Text, true);
                }
            }
        }
    }
}