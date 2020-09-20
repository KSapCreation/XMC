using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FBNPC.layers.DataLayers;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;

namespace MvcApplication1.Exam
{
    public partial class FBNPCTearms : System.Web.UI.Page
    {
        ML_ExamTransaction objML_ExamTransaction = new ML_ExamTransaction();
        BL_ExamTransaction objBL_ExamTransaction = new BL_ExamTransaction();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/ExamDefault.aspx", true);
            }
            if (!IsPostBack)
            {
                BindTearmsConditions();                
            }
        }
        private void BindTearmsConditions()
        {
            DataTable dt = new DataTable();
            dt = objBL_ExamTransaction.BL_BindTearmsCondition(objML_ExamTransaction);
            if (dt.Rows.Count > 0)
            {
                lblCondition.Text = dt.Rows[0]["TearmsCondition"].ToString();
            }
        }
       
        protected void btnStart(object sender, EventArgs e)
        {
            if (chkCondition.Checked == true)
            {
               //Response.Redirect("Page.aspx");
               Response.RedirectToRoute("StartExam", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Tearms and Conditions')", true);
            }
        }
    }
}