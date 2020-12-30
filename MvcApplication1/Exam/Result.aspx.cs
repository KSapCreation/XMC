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
using System.Text.RegularExpressions;

namespace MvcApplication1.Exam
{
    public partial class Result : System.Web.UI.Page
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
                BindProgramsInfo();                
            }
        }
        protected void SelectRbtnMultiple(object sender, EventArgs e)
        {
            BindExamList();   
        }
        private void BindExamList()
        {
            DataTable dt = new DataTable();
            objML_StudentProfile.ID = Session["UserName"].ToString();
            if (rbtnIndividual.Checked == true)
            {
                objML_StudentProfile.doctype = rbtnIndividual.Text;
            }
            else
            {
                objML_StudentProfile.doctype = rbtnMultiple.Text;
            }

            dt = objBL_StudentProfile.BL_BindExamList(objML_StudentProfile);
            if (dt.Rows.Count > 0)
            {
                ddlExamName.DataSource = dt;
                ddlExamName.DataTextField = "ExamName";
                ddlExamName.DataValueField = "ExamCode";
                ddlExamName.DataBind();
                ddlExamName.Items.Insert(0, "Select Exam");
            }
            else
            {
                ddlExamName.DataSource = dt;
                ddlExamName.DataTextField = "";
                ddlExamName.DataValueField = "";
                ddlExamName.DataBind();
                ddlExamName.Items.Insert(0, "No Exam");
            }

        }
    
        private void BindProgramsInfo()
        {
            DataTable dt = new DataTable();
            objML_StudentProfile.ID = Session["UserName"].ToString();
            //objML_StudentProfile.ExamName = Session["ExamName"].ToString();
            dt = objBL_StudentProfile.BL_Result(objML_StudentProfile);
            if (dt.Rows.Count > 0)
            {
                GrdCategory.DataSource = dt;
                GrdCategory.DataBind();
                int i = 0;
                int y = 0;
                foreach (GridViewRow row in GrdCategory.Rows)
                {
                    Label lblTick = (Label)row.FindControl("lbl");
                    Label lblStudentAns = (Label)row.FindControl("StudentAns");
                    Label lblCorrctAns = (Label)row.FindControl("CorrectAns");
                    Label lblStudentPreviewAns = (Label)row.FindControl("lblCorrect");
                    if (lblCorrctAns.Text == lblStudentAns.Text)
                    {
                        lblTick.Text = "&#10004;";
                        i = i + 1;
                    }
                    else if (lblStudentAns.Text == "")
                    {
                        lblTick.Text = "🏳️";
                    }
                    else
                    {
                        lblTick.Text = "&#10060;";
                        lblStudentPreviewAns.Text = lblCorrctAns.Text;
                        y = y + 1;
                    }
                }
                lblCorrect.Text = i.ToString();
                lblWrong.Text = y.ToString();
                lblTotalQus.Text = dt.Rows.Count.ToString();
            }
        }
        //protected void GrdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GrdCategory.PageIndex = e.NewPageIndex;
        //    BindProgramsInfo();

        //}
        public string HighlightText(string InputTxt)
        {
            string Search_Str = txtSearch.Text;
            // Setup the regular expression and add the Or operator.
            Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
            // Highlight keywords by calling the
            //delegate each time a keyword is found.
            return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
        }
        public string ReplaceKeyWords(Match m)
        {
            return ("<span class=highlight>" + m.Value + "</span>");
        }
        protected void Search(object sender, EventArgs e)
        {
            try
            {
                if (ddlExamName.SelectedValue == "Select Exam")
                {
                    throw new Exception("Select Exam Name");
                }
                DataTable dt = new DataTable();
                objML_StudentProfile.StudentName = Session["UserName"].ToString();
                objML_StudentProfile.ID = txtSearch.Text != "" ? txtSearch.Text : null;
                if (objML_StudentProfile.ID==null)
                {
                    objML_StudentProfile.ID = "";
                }
                    objML_StudentProfile.ExamName = ddlExamName.SelectedItem.Value != "" ? ddlExamName.SelectedItem.Value : null;
                
                if (rbtnMultiple.Checked==true)
                {
                    objML_StudentProfile.doctype = rbtnMultiple.Text;
                }
                else
                {
                    objML_StudentProfile.doctype = rbtnIndividual.Text;
                }                
                dt = objBL_StudentProfile.BL_SerachQuestionInfo(objML_StudentProfile);
                if (dt.Rows.Count > 0)
                {                    
                    GrdCategory.DataSource = dt;
                    GrdCategory.DataBind();
                    int i = 0;
                    int y = 0;
                    foreach (GridViewRow row in GrdCategory.Rows)
                    {
                        Label lblTick = (Label)row.FindControl("lbl");
                        Label lblStudentAns = (Label)row.FindControl("StudentAns");
                        Label lblCorrctAns = (Label)row.FindControl("CorrectAns");
                        if (lblCorrctAns.Text == lblStudentAns.Text)
                        {
                            lblTick.Text = "&#10004;";
                            i = i + 1;
                        }
                        else
                        {
                            lblTick.Text = "&#10060;";
                            y = y + 1;
                        }
                    }
                    lblCorrect.Text = i.ToString();
                    lblWrong.Text = y.ToString();
                    lblTotalQus.Text = dt.Rows.Count.ToString();
                    GrdCategory.Visible = true;
                }
                else
                {
                    GrdCategory.DataSource = dt;
                    GrdCategory.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('No Data Found')", true);
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            BindProgramsInfo();
            txtSearch.Text = "";
        }
    }

}