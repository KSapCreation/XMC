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
using System.Drawing;

namespace MvcApplication1.Exam
{
    public partial class ListExam : System.Web.UI.Page
    {
        BL_StudentProfile objBL_StudentProfile = new BL_StudentProfile();
        ML_StudentProfile objML_StudentProfile = new ML_StudentProfile();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/LoginIn.aspx", true);
            }
            if (!IsPostBack)
            {
                BindExamList();
            }
        }
        private void BindExamList()
        {
            try
            {
                DataTable dt = new DataTable();
                objML_StudentProfile.ID = Session["Username"].ToString();
                dt = objBL_StudentProfile.BL_BindStudentExamList(objML_StudentProfile);
                if (dt.Rows.Count > 0)
                {
                    dlExamList.DataSource = dt;
                    dlExamList.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void GetExam(object sender, EventArgs e)
        {
            try
            {
                DataListItem gvr = (DataListItem)(((Control)sender).NamingContainer);
                {
                    Label lblID = (Label)gvr.FindControl("lblExamID");
                    DataTable dt = new DataTable();
                    objML_StudentProfile.ID = lblID.Text != "" ? lblID.Text : null;
                    if (lblID.Text != "")
                    {
                        Session["ExamName"] = lblID.Text != "" ? lblID.Text : null;
                        //Response.Redirect("FBNPCTearms.aspx", true);
                        Response.RedirectToRoute("FBNPCTearms", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
    }
}