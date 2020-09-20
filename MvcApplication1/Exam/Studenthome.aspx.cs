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
using System.Web.Services;
using common;
using System.Data.SqlClient;

namespace MvcApplication1.Exam
{
    public partial class Studenthome : System.Web.UI.Page
    {
        BL_StudentProfile objBL_StudentProfile = new BL_StudentProfile();
        ML_StudentProfile objML_StudentProfile = new ML_StudentProfile();
        string StudentName = "";
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/LoginIn.aspx", true);
            }
            if (!IsPostBack)
            {         
                BindStudentInfo();
                BIndExamList();
                StudentName = Session["username"].ToString();
                txtStudentName.Text = Session["Name"].ToString();
                lblStudentID.Text = Session["UserName"].ToString();
                BindStudentUpdate();
              
            }
        }
        private void BindStudentInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                objML_StudentProfile.ID = Session["UserName"].ToString();
                dt = objBL_StudentProfile.BL_BindStudentInfo(objML_StudentProfile);
                if (dt.Rows.Count > 0)
                {
                    txtEmail.Text = dt.Rows[0]["E_mail"].ToString();
                    txtPhoneNo.Text = dt.Rows[0]["Phone"].ToString();
                    txtFirstName.Text = dt.Rows[0]["First_Name"].ToString();
                    txtLastName.Text = dt.Rows[0]["Last_Name"].ToString();
                    btnSave.Text = "Update";
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Connection lost')", true);
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                objML_StudentProfile.ID = txtFirstName.Text != "" ? txtFirstName.Text : null;
                objML_StudentProfile.EmailID = txtEmail.Text != "" ? txtEmail.Text : null;
                objML_StudentProfile.PhoneNo = txtPhoneNo.Text != "" ? txtPhoneNo.Text : null;
                objML_StudentProfile.ModifyBy = Session["UserName"].ToString();
                int x = objBL_StudentProfile.BL_UpdStudentInfo(objML_StudentProfile);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Update Saved.')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }

        #region Student Dashboard Graph
        public class Data
        {
            public string ColumnName = "";
            public int Value = 0;
            public string studentName = "";
            public Data(string columnName, int value)
            {
                ColumnName = columnName;
                Value = value;
                
            }
        }
        [WebMethod]        
        public static List<Data> GetData()
        {
            BL_StudentProfile objBL_StudentProfile = new BL_StudentProfile();
            ML_StudentProfile objML_StudentProfile = new ML_StudentProfile();
            
            DataTable dt = new DataTable();
            objML_StudentProfile.ID = HttpContext.Current.Session["User_Code"].ToString();
            dt = objBL_StudentProfile.BL_BindStudentScoreBoard(objML_StudentProfile);
            List<Data> dataList = new List<Data>();
            string cat = "";
            int val = 0;
            foreach (DataRow dr in dt.Rows)
            {
                cat = dr[0].ToString();
                val = Convert.ToInt32(dr[1]);
                dataList.Add(new Data(cat, val));
            }
            return dataList;
        }

        #endregion

        public void BIndExamList()
        {
            try
            {
                DataTable dt = new DataTable();
                objML_StudentProfile.ID = Session["UserName"].ToString();
                dt = objBL_StudentProfile.BL_BindStudentExamList(objML_StudentProfile);
                if (dt.Rows.Count > 0)
                {
                    ddlExamlist.DataSource = dt;
                    ddlExamlist.DataValueField = "ExamCode";
                    ddlExamlist.DataTextField = "ExamName";
                    ddlExamlist.DataBind();
                    ddlExamlist.Items.Insert(0, "Select");
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Connection lost')", true);
            }
        }
        protected void CheckAvailability(object sender, EventArgs e)
        {
            btnSubmit.Text = "Availability";
        }
        protected void AvailabilityReloader(object sender, EventArgs e)
        {
            try
            {                
                if (ddlExamlist.SelectedItem.Text == "Select")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Select Exam Name');", true);
                }
                else if (btnSubmit.Text == "Availability")
                {
                    DataTable dt = new DataTable();
                    DataTable dt1 = new DataTable();
                    Label lblQuestionTotal = new Label();
                    Label lblQuestionAttempted = new Label();
                    objML_StudentProfile.ID = txtStudentName.Text != "" ? txtStudentName.Text : null;
                    objML_StudentProfile.ExamName = ddlExamlist.SelectedItem.Value != "" ? ddlExamlist.SelectedItem.Value : null;
                    dt = objBL_StudentProfile.BL_Re_loaderCountExam_StudentTotal(objML_StudentProfile);
                    if (dt.Rows.Count > 0)
                    {
                        lblQuestionTotal.Text = dt.Rows[0]["cnt"].ToString();
                        dt1 = objBL_StudentProfile.BL_Re_loaderCountExam_StudentAttempted(objML_StudentProfile);
                        if (dt1.Rows.Count > 0)
                        {
                            if (lblQuestionTotal.Text == "0")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('No Data Found');", true);
                            }
                            else
                            {
                                lblQuestionAttempted.Text = dt1.Rows[0]["cnt"].ToString();
                                if (lblQuestionTotal.Text == lblQuestionAttempted.Text)
                                {
                                    btnSubmit.Text = "Re-loader";

                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Exam Not Re-Load, because all Questions not submit.');", true);
                                }
                            
                            }

                            

                        }
                    }
                }
                else
                {
                    // Question List Bind
                    int i = 0;
                    Label lblQuestionID = new Label();
                    Label lblOPtionA = new Label();
                    Label lblOPtionB = new Label();
                    Label lblOPtionC = new Label();
                    Label lblOPtionD = new Label();
                    Label lblExamNAme = new Label();
                    Label lblStudentName = new Label();
                    Label lblPaperID = new Label();
                    Label lblHistoryID = new Label();
                    DataTable dtQuestion = new DataTable();
                    objML_StudentProfile.StudentName = txtStudentName.Text != "" ? txtStudentName.Text : null;
                    objML_StudentProfile.ExamName = ddlExamlist.SelectedItem.Value != "" ? ddlExamlist.SelectedItem.Value : null;
                    dtQuestion = objBL_StudentProfile.BL_ReloaderStudentSubmitSelect(objML_StudentProfile);
                    if (dtQuestion.Rows.Count > 0)
                    {
                        con.Open();
                        SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                        string qry = "";
                        qry = "SELECT MAX(hist_version) as hist_version from FBNPC_Submit_Exam_History where studentname='" + txtStudentName.Text + "'";
                        SqlCommand cmd = new SqlCommand(qry, con);
                        cmd.Transaction = trans;
                        cmd.Clone();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            objML_StudentProfile.HIst_Version = dr["hist_version"].ToString();
                        }
                        if (clsCommon.myLen(objML_StudentProfile.HIst_Version) <= 0)
                        {
                            objML_StudentProfile.HIst_Version = txtStudentName.Text + "0000001";
                        }
                        else
                        {
                            objML_StudentProfile.HIst_Version = clsCommon.incval(objML_StudentProfile.HIst_Version);
                        }
                        con.Close();
                        foreach (DataRow row in dtQuestion.Rows)
                        {
                            objML_StudentProfile.Hist_By = Session["Username"].ToString();
                            objML_StudentProfile.QuestionID = row["QuestionID"].ToString();
                            objML_StudentProfile.OPtionA = row["OPtionA"].ToString();
                            objML_StudentProfile.OPtionB = row["OPtionB"].ToString();
                            objML_StudentProfile.OPtionC = row["OPtionC"].ToString();
                            objML_StudentProfile.OPtionD = row["OPtionD"].ToString();
                            objML_StudentProfile.ExamName = row["ExamName"].ToString();
                            objML_StudentProfile.StudentName = row["StudentName"].ToString();
                            objML_StudentProfile.PaperID = row["PaperID"].ToString();
                            int x = objBL_StudentProfile.BL_InsReloaderStudentSubmitHistory(objML_StudentProfile);
                            if (x == 1)
                            { }
                        }
                        // Delete Submit Data 
                        int YSubmitDelete = 0;
                         YSubmitDelete = objBL_StudentProfile.BL_InsReloaderStudentSubmitDelete(objML_StudentProfile);
                         if (YSubmitDelete == 1)
                         { i++; }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('No Data Found');", true);
                    }
                    // Exam Student Submit Drop to history Table******
                    // Exam Student validaion Mapping Drop to history Table
                    DataTable dtValidation = new DataTable();
                    dtValidation = objBL_StudentProfile.BL_ReloaderStudentValidationSelect(objML_StudentProfile);
                    if (dtValidation.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtValidation.Rows)
                        {
                            objML_StudentProfile.Hist_By = Session["Username"].ToString();
                            objML_StudentProfile.ExamName = row["ExamName"].ToString();
                            objML_StudentProfile.StudentName = row["StudentName"].ToString();
                            objML_StudentProfile.PaperID = row["PaperID"].ToString();
                            int xvalidation = objBL_StudentProfile.BL_InsReloaderExamValidationHistory(objML_StudentProfile);
                            if (xvalidation == 0)
                            { }
                        }
                        int YValidationDelete = objBL_StudentProfile.BL_InsReloaderExamValidationDelete(objML_StudentProfile);
                        if (YValidationDelete == 1)
                        {
                            i++;
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('No Data Found');", true);
                    }
                    // End Exam Student validaion Mapping Drop to history Table
                    if (i > 0)
                    {
                        btnSubmit.Text = "Availability";
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Exam Re-Load successfully');", true);
                    }
                }                
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void BindStudentUpdate()
        {
            try
            {
                DataTable dt = new DataTable();
                objML_StudentProfile.ID = Session["UserName"].ToString();
                dt = objBL_StudentProfile.BL_BindStudentUpdates(objML_StudentProfile);
                if (dt.Rows.Count > 0)
                {
                    dlUpdates.DataSource = dt;
                    dlUpdates.DataBind();
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Connection lost')", true);
            }
        }
    }
}