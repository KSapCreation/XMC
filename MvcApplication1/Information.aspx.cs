using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.ModelLayer;
using MvcApplication1.Admin.Layer.Businesslayer;
using System.Data;

namespace MvcApplication1
{
    public partial class Information : System.Web.UI.Page
    {
        BL_SiteDetail objBL_SiteDetail = new BL_SiteDetail();
        ML_SiteDetail objML_SiteDetail = new ML_SiteDetail();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPrograms();
                BindMenu();
            }
        }
        protected void BindPrograms()
        {
            DataTable dt = new DataTable();
            objML_SiteDetail.ID = "O";
            dt = objBL_SiteDetail.BL_OthersInfo(objML_SiteDetail);
            if (dt.Rows.Count > 0)
            {
                dlOthers.DataSource = dt;
                dlOthers.DataBind();
            }
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