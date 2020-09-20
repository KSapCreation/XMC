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
    public partial class OurPrograms : System.Web.UI.Page
    {
        BL_SiteDetail objBL_SiteDetail = new BL_SiteDetail();
        ML_SiteDetail objML_SiteDetail = new ML_SiteDetail();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPrograms();
            }
        }
        protected void BindPrograms()
        {
            DataTable dt = new DataTable();
            dt = objBL_SiteDetail.BL_OurProgramInfo(objML_SiteDetail);
            if (dt.Rows.Count > 0)
            {
                dlOurPrograms.DataSource = dt;
                dlOurPrograms.DataBind();
            }
        }
    }
}