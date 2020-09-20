using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using FBNPC;
using System.Data;

namespace MvcApplication1
{
    public partial class Detail : System.Web.UI.Page
    {
        ML_Default objML_Default = new ML_Default();
        BL_Default objBL_Default = new BL_Default();
        CommonClass objCommonClass = new CommonClass();

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
            objML_Default.ID = Request.QueryString["ID"];
            dt = objBL_Default.BL_ShowSingleProgramsData(objML_Default);
            if (dt.Rows.Count > 0)
            {
                dlShowPrograms.DataSource = dt;
                dlShowPrograms.DataBind();
            }
        }
        protected void EditShow(object sender, EventArgs e)
        {
            DataListItem gvr = (DataListItem)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblID");
                DataTable dt = new DataTable();
                objML_Default.ID = lblID.Text != "" ? lblID.Text : null;
                dt = objBL_Default.BL_ProgramsData(objML_Default);
                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("Detail.aspx?ID=" + lblID.Text, true);
                }
            }
        }
        protected void BindMenu()
        {
            DataTable dt = new DataTable();
            dt = objBL_Default.BL_DLMenu(objML_Default);
            if (dt.Rows.Count > 0)
            {
                DLMenu.DataSource = dt;
                DLMenu.DataBind();
            }
        }
    }
}