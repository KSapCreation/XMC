using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;
using System.Data.SqlClient;
using common;
using FBNPC.layers.DataLayers;

namespace MvcApplication1.Admin
{
    public partial class Series : System.Web.UI.Page
    {
        ML_ExamMaster objML_ExamMaster = new ML_ExamMaster();
        BL_ExamMaster objBL_ExamMaster = new BL_ExamMaster();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            if (!IsPostBack)
            {
                BindSubject();
                BindSection();
                BindQuestion();
                BindAVMaster();
                BindExamName();
            }
        }
        protected void BindSubject()
        {
            DataTable dt = new DataTable();
            dt = objBL_ExamMaster.BL_BindSubject(objML_ExamMaster);
            if (dt.Rows.Count > 0)
            {
                ddlSubject.DataSource = dt;
                ddlSubject.DataTextField = "SubjectName";
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataBind();
                ddlSubject.Items.Insert(0, "Select");
            }
            else
            {
                ddlSubject.Items.Insert(0, "Select");
            }
        }
        protected void BindSection()
        {
            DataTable dt = new DataTable();
            dt = objBL_ExamMaster.BL_BindSection(objML_ExamMaster);
            if (dt.Rows.Count > 0)
            {
                ddlSection.DataSource = dt;
                ddlSection.DataTextField = "SectionName";
                ddlSection.DataValueField = "SectionID";
                ddlSection.DataBind();
                ddlSection.Items.Insert(0, "Select");
            }
            else
            {
                ddlSection.Items.Insert(0, "Select");
            }
        }
        protected void BindExamName()
        {
            DataTable dt = new DataTable();
            dt = objBL_ExamMaster.BL_BindExamListName(objML_ExamMaster);
            if (dt.Rows.Count > 0)
            {
                ddlExamName.DataSource = dt;
                ddlExamName.DataTextField = "ExamName";
                ddlExamName.DataValueField = "ExamID";
                ddlExamName.DataBind();
                ddlExamName.Items.Insert(0, "Select");
            }
            else
            {
                ddlSubject.Items.Insert(0, "Select");
            }
        }
        protected void BindAVMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_ExamMaster.BL_BindAVMaster(objML_ExamMaster);
                if (dt.Rows.Count > 0)
                {
                    GrdCategory.DataSource = dt;
                    GrdCategory.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void BindQuestion()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_ExamMaster.BL_BindQuestion(objML_ExamMaster);
                if (dt.Rows.Count > 0)
                {
                    GRdQuestion.DataSource = dt;
                    GRdQuestion.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (ddlSubject.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Subject First !');", true);
                }
                else if (ddlSection.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Section !');", true);
                }
                else if (btnSave.Text == "Save")
                {

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            ddlSection.SelectedIndex = 0;
            ddlSubject.SelectedIndex = 0;
            BindQuestion();
            BindAVMaster();
        }
    }
}