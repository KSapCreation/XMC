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
using System.Text.RegularExpressions;

namespace MvcApplication1.Admin
{
    public partial class WebForm : System.Web.UI.Page
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
                BindProgramsInfo();
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            if (txtSubject.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Question first');", true);
            }
            else if (txtA.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Option A');", true);
            }
            else if (txtB.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Option B');", true);
            }
            else if (txtC.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Option C');", true);
            }
            else if (txtD.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Option D');", true);
            }
            else if (ddlCorrectOption.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Right Option');", true);
            }
            else if (btnSave.Text == "Save")
            {

                con.Open();
                SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                string qry = "";
                qry = "select max(QuestionID) as QuestionID from FBNPC_QustionsSheet";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Transaction = trans;
                cmd.Clone();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objML_ExamMaster.ID = dr["QuestionID"].ToString();
                }
                if (clsCommon.myLen(objML_ExamMaster.ID) <= 0)
                {
                    objML_ExamMaster.ID = "QUS000000001";
                }
                else
                {
                    objML_ExamMaster.ID = clsCommon.incval(objML_ExamMaster.ID);
                }
                con.Close();
                objML_ExamMaster.Question = txtSubject.Text != "" ? txtSubject.Text : null;
                objML_ExamMaster.OPtionOne = txtA.Text != "" ? txtA.Text : null;
                objML_ExamMaster.OptionTwo = txtB.Text != "" ? txtB.Text : null;
                objML_ExamMaster.OptionThree = txtC.Text != "" ? txtC.Text : null;
                objML_ExamMaster.OptionFour = txtD.Text != "" ? txtD.Text : null;
                objML_ExamMaster.CorrectAns = ddlCorrectOption.SelectedItem.Text != "" ? ddlCorrectOption.SelectedItem.Text : null;
                objML_ExamMaster.CreatedBy = Session["UserName"].ToString();
                objML_ExamMaster.ModifyBy = Session["UserName"].ToString();
                int x = objBL_ExamMaster.BL_InsUpdQuestion(objML_ExamMaster);
                if (x == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved');", true);
                    Reset();

                }
            }
            else
            {
                objML_ExamMaster.ID = lblID.Text != "" ? lblID.Text : null;
                objML_ExamMaster.Question = txtSubject.Text != "" ? txtSubject.Text : null;
                objML_ExamMaster.OPtionOne = txtA.Text != "" ? txtA.Text : null;
                objML_ExamMaster.OptionTwo = txtB.Text != "" ? txtB.Text : null;
                objML_ExamMaster.OptionThree = txtC.Text != "" ? txtC.Text : null;
                objML_ExamMaster.OptionFour = txtD.Text != "" ? txtD.Text : null;
                objML_ExamMaster.CorrectAns = ddlCorrectOption.SelectedItem.Text != "" ? ddlCorrectOption.SelectedItem.Text : null;
                objML_ExamMaster.CreatedBy = Session["UserName"].ToString();
                objML_ExamMaster.ModifyBy = Session["UserName"].ToString();
                int x = objBL_ExamMaster.BL_InsUpdQuestion(objML_ExamMaster);
                if (x == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved');", true);
                    Reset();

                }
            }
        }
        private void Reset()
        {
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            txtSubject.Text = "";
            ddlCorrectOption.SelectedIndex = 0;
            btnSave.Text = "Save";
            txtSearch.Text = ""; BindProgramsInfo();
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        protected void BindProgramsInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_ExamMaster.BL_BindQuestion(objML_ExamMaster);
                if (dt.Rows.Count > 0)
                {
                    GrdQuestion.AllowPaging = true;
                    GrdQuestion.DataSource = dt;
                    GrdQuestion.DataBind();                    
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GrdQuestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdQuestion.PageIndex = e.NewPageIndex;
            BindProgramsInfo();

        }
        protected void Search(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_ExamMaster.ID = txtSearch.Text != "" ? txtSearch.Text : null;
                dt = objBL_ExamMaster.BL_SerachQuestion(objML_ExamMaster);
                if (dt.Rows.Count > 0)
                {
                    GrdQuestion.AllowPaging = false;
                    GrdQuestion.DataSource = dt;
                    GrdQuestion.DataBind();
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('No Data Found')", true);
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
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
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_ExamMaster.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_ExamMaster.BL_DeleteQuestion(objML_ExamMaster);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindProgramsInfo();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {              
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {                    
                    Label lblProgramsID = (Label)gvr.FindControl("lblProgramsID");
                    Label lblCategory = new Label();
                    DataTable dt = new DataTable();
                    objML_ExamMaster.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_ExamMaster.BL_EditQuestion(objML_ExamMaster);
                    if (dt.Rows.Count > 0)
                    {                    
                        lblID.Text = dt.Rows[0]["QuestionID"].ToString();
                        txtA.Text = dt.Rows[0]["OptionOne"].ToString();
                        txtB.Text = dt.Rows[0]["OptionTwo"].ToString();
                        txtC.Text = dt.Rows[0]["OptionThree"].ToString();
                        txtD.Text = dt.Rows[0]["OptionFour"].ToString();
                        ddlCorrectOption.SelectedItem.Text = dt.Rows[0]["CorrectAns"].ToString();
                        txtSubject.Text = dt.Rows[0]["Question"].ToString();
                        btnSave.Text = "Update";

                    }
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
    }
}