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
    public partial class Default : System.Web.UI.Page
    {
        ML_Default objML_Default = new ML_Default();
        BL_Default objBL_Default = new BL_Default();
        CommonClass objCommonClass = new CommonClass();

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                BindSliders();
                BindOurPrograms();
                BindTestimonials();
                BindOtherDetail();
                BindMenu();
            }
        }
        protected void BindSliders()
        {
            DataTable dt = new DataTable();
            dt = objBL_Default.BL_SlidersData(objML_Default);
            if (dt.Rows.Count > 0)
            {
                Slider1Title.Text = dt.Rows[0]["ShortName"].ToString();
                Slider1Desc.Text = dt.Rows[0]["Description"].ToString();
            }
            if (dt.Rows.Count > 1)
            {
                Slider2Title.Text = dt.Rows[1]["ShortName"].ToString();
                Slider2Desc.Text = dt.Rows[1]["Description"].ToString();
            }
            if (dt.Rows.Count > 2)
            {
                Slider3Title.Text = dt.Rows[2]["ShortName"].ToString();
                Slider3Desc.Text = dt.Rows[2]["Description"].ToString();
            }
        }
        protected void BindOurPrograms()
        {
             DataTable dt = new DataTable();
             dt = objBL_Default.BL_ProgramsData(objML_Default);
             if (dt.Rows.Count > 0)
             {
                 dlPrograms.DataSource = dt;
                 dlPrograms.DataBind();
             }
        }
        protected void BindTestimonials()
        {
            DataTable dt = new DataTable();
            dt = objBL_Default.BL_TestimonialsData(objML_Default);
            if (dt.Rows.Count > 0)
            {
                DlTestimonials.DataSource = dt;
                DlTestimonials.DataBind();
            }
        }
        protected void BindOtherDetail()
        {
            DataTable dt = new DataTable();
            dt = objBL_Default.BL_OtherData(objML_Default);
            if (dt.Rows.Count > 0)
            {
                dlOtherInfo.DataSource = dt;
                dlOtherInfo.DataBind();
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