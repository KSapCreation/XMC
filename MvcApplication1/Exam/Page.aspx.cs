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
using common;

namespace MvcApplication1.Exam
{
    public partial class Page : System.Web.UI.Page
    {
        protected bool blExamDocType;
        ML_ExamTransaction objML_ExamTransaction = new ML_ExamTransaction();
        BL_ExamTransaction objBL_ExamTransaction = new BL_ExamTransaction();
        string DocTypeValue = string.Empty;
        
        
        protected void Page_Load(object sender, EventArgs e)
        {           
           
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/ExamDefault.aspx", true);
            }
            if (!IsPostBack)
            {
                if (Session["ExamDocType"].ToString() == "Multiple")
                {                    
                    BindCollection();
                    BindVideoCollection();
                    BindReadingCollection();
                    BindExamEnd();
                }
                else
                {
                    BindIndividualQuestionCollection();
                }
                
                SessionExpireStop.Text = Session["UserName"].ToString();
                
                //BindExamSheet();
                //BindExamAudio();
            }
            if (Session["ExamDocType"].ToString() == "Multiple")
            {
                blExamDocType = true;
            }
            else
            {
                blExamDocType = false;
            }
            //DataTable dt = new DataTable();
            ////dt.Columns.Add("EndDate", typeof(DateTime));
            ////dt.Rows.Add("2020-06-10 15:45:34.943");
            //DateTime startDate = DateTime.Now;
            //DateTime endDate = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
            //lblTime.Text = CalculateTimeDifference(startDate, endDate);
        }
        public void BindSectionTime()
        {
            DataTable dt = new DataTable();
            objML_ExamTransaction.ExamName = Session["ExamName"].ToString();
            dt = objBL_ExamTransaction.BL_GetSectionTime(objML_ExamTransaction);
            if(dt.Rows.Count>0)
            {
                DateTime startDate = DateTime.Now;
                DateTime endDate = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
                //  lblTime.Text = CalculateTimeDifference(startDate, endDate);
            }

        }
        public string CalculateTimeDifference(DateTime startDate, DateTime endDate)
        {
            int days = 0; int hours = 0; int mins = 0; int secs = 0;
            string final = string.Empty;
            if (endDate > startDate)
            {
                days = (endDate - startDate).Days;
                hours = (endDate - startDate).Hours;
                mins = (endDate - startDate).Minutes;
                secs = (endDate - startDate).Seconds;
                final = string.Format("{0} days {1} hours {2} mins {3} secs", days, hours, mins, secs);
            }
            return final;
        }
        protected void UpdateTimer_Tick(object sender, EventArgs e)
        {
            Session["Username"] = SessionExpireStop.Text;
        }
        protected void GetTime(object sender, EventArgs e)
        {
          //  lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        #region BindAllData
        private void BindIndividualQuestionCollection()
        {
            DataTable dt = new DataTable();
            objML_ExamTransaction.ID = Session["ExamName"].ToString();
            objML_ExamTransaction.StudentName = Session["UserName"].ToString();
            dt = objBL_ExamTransaction.BL_BindIndividualCollection(objML_ExamTransaction);
            if (dt.Rows.Count > 0)
            {
                DlIndividual.DataSource = dt;
                DlIndividual.DataBind();     
            }
           
        }
        private void BindCollection()
        {
            DataTable dt = new DataTable();
            objML_ExamTransaction.ID = Session["ExamName"].ToString();
            objML_ExamTransaction.StudentName = Session["UserName"].ToString();
            dt = objBL_ExamTransaction.BL_BindCollection(objML_ExamTransaction);
            if (dt.Rows.Count > 0)
            {
                DlListening.DataSource = dt;
                DlListening.DataBind();
                DlListening.Visible = true;
                lblListeningMsg.Visible = false;
            }
            else
            {
                DlListening.Visible = false;
                lblListeningMsg.Text = "Section Complete";
                lblListeningMsg.Visible = true;
                lblcount4.Text = "0";
            }
        }
        private void BindVideoCollection()
        {
            DataTable dt = new DataTable();
            objML_ExamTransaction.ID = Session["ExamName"].ToString();
            objML_ExamTransaction.StudentName = Session["UserName"].ToString();
            dt = objBL_ExamTransaction.BL_BindSpeakingCollection(objML_ExamTransaction);
            if (dt.Rows.Count > 0)
            {
                DlSpeaking.DataSource = dt;
                DlSpeaking.DataBind();
                DlSpeaking.Visible = true;
                lblSpeakingMsg.Visible = false;
            }
            else
            {
                DlSpeaking.Visible = false;
                lblSpeakingMsg.Text = "Section Complete";
                lblSpeakingMsg.Visible = true;
                lblcount1.Text = "0";
            }
        }
        private void BindReadingCollection()
        {
            DataTable dt = new DataTable();
            objML_ExamTransaction.ID = Session["ExamName"].ToString();
            objML_ExamTransaction.StudentName = Session["UserName"].ToString();
            dt = objBL_ExamTransaction.BL_BindReadingCollection(objML_ExamTransaction);
            if (dt.Rows.Count > 0)
            {
                DLReading.DataSource = dt;
                DLReading.DataBind();
                DLReading.Visible = true;
            }
            else
            {
                DLReading.Visible = false;
                lblcount2.Text = "0";

            }
        }
        private void BindExamSheet()
        {
            DataTable dt = new DataTable();
            objML_ExamTransaction.ID = Session["ExamName"].ToString();
            dt = objBL_ExamTransaction.BL_BindQuestionSheet(objML_ExamTransaction);
            if (dt.Rows.Count > 0)
            {
      
                ddlExamQuestion.DataSource = dt;
                ddlExamQuestion.DataBind();
                lblPaperID.Text = dt.Rows[0]["PaperID"].ToString();
                StartPageDiv.Visible = false;
            }
        }
        private void BindExamAudio(string AudioID)
        {
            DataTable dt = new DataTable();
            objML_ExamTransaction.ID= AudioID;
            dt = objBL_ExamTransaction.BL_BindExamAudio(objML_ExamTransaction);
            if (dt.Rows.Count > 0)
            {
                DlAudioSection.DataSource = dt;
                DlAudioSection.DataBind();
                StartPageDiv.Visible = false;
            }
        }
        private void BindExamVideo(string VideoID)
        {
            DataTable dt = new DataTable();
            objML_ExamTransaction.ID = VideoID;
            dt = objBL_ExamTransaction.BL_BindExamVideo(objML_ExamTransaction);
            if (dt.Rows.Count > 0)
            {
                DLVideoSection.DataSource = dt;
                DLVideoSection.DataBind();                
                StartPageDiv.Visible = false;
            }
        }
        private void BindExamComprehension(string ReadingID)
        {
            DataTable dt = new DataTable();
            objML_ExamTransaction.ID = ReadingID;
            dt = objBL_ExamTransaction.BL_BindExamCompreension(objML_ExamTransaction);
            if (dt.Rows.Count > 0)
            {
                pnlComprehsion.Height = 300;
                DLComprehension.DataSource = dt;
                DLComprehension.DataBind();                
                StartPageDiv.Visible = false;
            }
        }

        #endregion
        protected void LogOff(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Clear();
            Response.Redirect("~/ExamDefault.aspx");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }

        #region ShowData
        protected void ShowListening(object sender, EventArgs e)
        {
            ddlExamQuestion.DataSource = "";
            DataListItem gvr = (DataListItem)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblID");
                LinkButton lnkCounted = (LinkButton)gvr.FindControl("LinkButton3");
                DataTable dt = new DataTable();
                objML_ExamTransaction.ID = lblID.Text != "" ? lblID.Text : null;
                objML_ExamTransaction.ExamName = Session["ExamName"].ToString();
                dt = objBL_ExamTransaction.BL_ShowListening(objML_ExamTransaction);
                if (dt.Rows.Count > 0)
                {
                    ddlExamQuestion.DataSource = dt;
                    ddlExamQuestion.DataBind();
                    SaveDiv.Visible = true;
                    lblAllID.Text = dt.Rows[0]["AVID"].ToString();
                    lblPaperID.Text = dt.Rows[0]["PaperID"].ToString();
                    lnkCounted.BackColor = System.Drawing.Color.Gray;
                    lnkCounted.ForeColor = System.Drawing.Color.Black;
                    DLVideoSection.DataSource = "";
                    DLVideoSection.Visible = false;
                    DLComprehension.DataSource = "";
                    DLComprehension.Visible = false;
                    DlAudioSection.Visible = true;
                    pnQuestion.Height = 300;
                    //ddlExamQuestion.Height = 300;
                    ddlExamQuestion.Visible = true;
                    ThankuSubmit.Visible = false;
                    BindExamAudio(lblID.Text);
                    
                }
            }
        }
        protected void ShowSpeaking(object sender, EventArgs e)
        {
            ddlExamQuestion.DataSource = "";
            DataListItem gvr = (DataListItem)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblID");
                LinkButton lnkCounted = (LinkButton)gvr.FindControl("LinkButton3");
                DataTable dt = new DataTable();
                objML_ExamTransaction.ID = lblID.Text != "" ? lblID.Text : null;
                objML_ExamTransaction.ExamName = Session["ExamName"].ToString();
                dt = objBL_ExamTransaction.BL_ShowSpeaking(objML_ExamTransaction);
                if (dt.Rows.Count > 0)
                {
                    ddlExamQuestion.DataSource = dt;
                    ddlExamQuestion.DataBind();
                    SaveDiv.Visible = true;
                    lblAllID.Text = dt.Rows[0]["VideoID"].ToString();
                    lblPaperID.Text = dt.Rows[0]["PaperID"].ToString();
                    lnkCounted.BackColor = System.Drawing.Color.Gray;
                    
                    DlAudioSection.DataSource = "";
                    DlAudioSection.Visible = false;
                    DLComprehension.DataSource = "";
                    DLComprehension.Visible = false;
                    pnQuestion.Height = 300;
                    DLVideoSection.Visible = true;
                    ddlExamQuestion.Visible = true;
                    ThankuSubmit.Visible = false;
                    BindExamVideo(lblID.Text);
                }
            }
        }
        protected void ShowReading(object sender, EventArgs e)
        {
            ddlExamQuestion.DataSource = "";
            
            DataListItem gvr = (DataListItem)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblID");
                LinkButton lnkCounted = (LinkButton)gvr.FindControl("LinkButton3");
                DataTable dt = new DataTable();
                objML_ExamTransaction.ID = lblID.Text != "" ? lblID.Text : null;
                objML_ExamTransaction.ExamName = Session["ExamName"].ToString();
                dt = objBL_ExamTransaction.BL_ShowReading(objML_ExamTransaction);
                if (dt.Rows.Count > 0)
                {
                    ddlExamQuestion.DataSource = dt;
                    ddlExamQuestion.DataBind();
                    SaveDiv.Visible = true;
                    lblAllID.Text = dt.Rows[0]["ComprehensionID"].ToString();
                    lblPaperID.Text = dt.Rows[0]["PaperID"].ToString();
                    lnkCounted.BackColor = System.Drawing.Color.Gray;
                    lnkCounted.ForeColor = System.Drawing.Color.Black;
                    DlAudioSection.DataSource = "";
                    DlAudioSection.Visible = false;
                    DLVideoSection.Visible = false;
                    DLComprehension.Visible = true;
                    pnQuestion.Height = 300;
                    DLReading.Visible = true;
                    ddlExamQuestion.Visible = true;
                    ThankuSubmit.Visible = false;
                    BindExamComprehension(lblID.Text);
                }
            }
        }

        protected void ShowIndividualQuestion(object sender, EventArgs e)
        {
            ddlExamQuestion.DataSource = "";
            DataListItem gvr = (DataListItem)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblID");
                Label lblQuesNo = (Label)gvr.FindControl("Label1");
                LinkButton lnkCounted = (LinkButton)gvr.FindControl("LinkButton3");
                DataTable dt = new DataTable();
                objML_ExamTransaction.ID = lblID.Text != "" ? lblID.Text : null;
                objML_ExamTransaction.ExamName = Session["ExamName"].ToString();
                dt = objBL_ExamTransaction.BL_ShowIndividualQuestion(objML_ExamTransaction);
                if (dt.Rows.Count > 0)
                {
                    ddlExamQuestion.DataSource = dt;
                    ddlExamQuestion.DataBind();
                    SaveDiv.Visible = true;
                    multiplediv.Visible = false;
                    DivQuestion_DocType.Attributes.Add("Class", "col-sm-12");
                    ddlExamQuestion.Height = 200;
                    lblAllID.Text = dt.Rows[0]["QuestionID"].ToString();
                    lblPaperID.Text = dt.Rows[0]["PaperID"].ToString();
                    lnkCounted.BackColor = System.Drawing.Color.Gray;
                    lnkCounted.ForeColor = System.Drawing.Color.Black;                   
                    pnQuestion.Height = 300;                    
                    ddlExamQuestion.Visible = true;
                    ThankuSubmit.Visible = false;
                    StartPageDiv.Visible = false;
                    lblQusNo.Text = lblQuesNo.Text;
                }
            }
        }
        #endregion

        #region Next Previous
        protected void TempSaveExam(object sender, EventArgs e)
        {
            try
            {
                int i = 0;

                foreach (DataListItem dlist in ddlExamQuestion.Items)
                {
                    Label QuestionID = ((Label)dlist.FindControl("lblQuestionID"));
                    RadioButton OPtionA = ((RadioButton)dlist.FindControl("RadioButton4"));
                    RadioButton OptionB = ((RadioButton)dlist.FindControl("RadioButton1"));
                    RadioButton OptionC = ((RadioButton)dlist.FindControl("RadioButton2"));
                    RadioButton OptionD = ((RadioButton)dlist.FindControl("RadioButton3"));

                    if (OPtionA.Checked == true)
                    {
                        objML_ExamTransaction.OptionA = "1";
                    }
                    else
                    {
                        objML_ExamTransaction.OptionA = "0";
                    }
                    // Option B Selection
                    if (OptionB.Checked == true)
                    {
                        objML_ExamTransaction.OptionB = "1";
                    }
                    else
                    {
                        objML_ExamTransaction.OptionB = "0";
                    }
                    // Option C Selection
                    if (OptionC.Checked == true)
                    {
                        objML_ExamTransaction.OptionC = "1";
                    }
                    else
                    {
                        objML_ExamTransaction.OptionC = "0";
                    }
                    // Option D Selection
                    if (OptionD.Checked == true)
                    {
                        objML_ExamTransaction.OptionD = "1";
                    }
                    else
                    {
                        objML_ExamTransaction.OptionD = "0";
                    }
                    objML_ExamTransaction.Question = QuestionID.Text != "" ? QuestionID.Text : null;
                    objML_ExamTransaction.ExamName = Session["ExamName"].ToString();
                    objML_ExamTransaction.StudentName = Session["UserName"].ToString();
                    objML_ExamTransaction.PaperID = lblPaperID.Text != "" ? lblPaperID.Text : null;
                    objML_ExamTransaction.DocType = Session["ExamDocType"].ToString();
                    objML_ExamTransaction.QusNo = lblQusNo.Text;
                    int x = objBL_ExamTransaction.BL_InsTempSaveExam(objML_ExamTransaction);
                    if (x == 1)
                    { }

                    i = i + 1;
                }


                // Next Question Appear
                DataTable dt = new DataTable();
                objML_ExamTransaction.ID = Session["ExamName"].ToString();
                objML_ExamTransaction.StudentName = Session["UserName"].ToString();
                objML_ExamTransaction.QusNo = lblQusNo.Text;
                dt = objBL_ExamTransaction.BL_TempIndividualNext(objML_ExamTransaction);
                if (dt.Rows.Count > 0)
                {
                    ddlExamQuestion.DataSource = dt;
                    ddlExamQuestion.DataBind();
                    SaveDiv.Visible = true;
                    multiplediv.Visible = false;
                    DivQuestion_DocType.Attributes.Add("Class", "col-sm-12");
                    ddlExamQuestion.Height = 200;
                    lblAllID.Text = dt.Rows[0]["QuestionID"].ToString();
                    lblPaperID.Text = dt.Rows[0]["PaperID"].ToString();
                                        
                    pnQuestion.Height = 300;
                    ddlExamQuestion.Visible = true;
                    ThankuSubmit.Visible = false;
                    StartPageDiv.Visible = false;
                    lblQusNo.Text = dt.Rows[0]["num"].ToString();

                   
                    // Temp Answear By user if submit for Temp
                    foreach (DataListItem dlist in ddlExamQuestion.Items)
                    {
                        RadioButton OPtionA = ((RadioButton)dlist.FindControl("RadioButton4"));
                        RadioButton OptionB = ((RadioButton)dlist.FindControl("RadioButton1"));
                        RadioButton OptionC = ((RadioButton)dlist.FindControl("RadioButton2"));
                        RadioButton OptionD = ((RadioButton)dlist.FindControl("RadioButton3"));
                        int UserAns= Convert.ToInt32(dt.Rows[0]["UserAns"].ToString());
                        if (UserAns==1)
                        {
                            OPtionA.Checked = true;
                        }
                        else if(UserAns == 2)
                        {
                            OptionB.Checked = true;
                        }
                        else if (UserAns == 3)
                        {
                            OptionC.Checked = true;
                        }
                        else if (UserAns == 4)
                        {
                            OptionD.Checked = true;
                        }

                    }
                    // End
                    btnNext.Enabled = true;
                }
                else
                {
                    btnNext.Enabled = false;
                }
                // End
                

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void TempPrevious(object sender, EventArgs e)
        {
            try
            {
                int i = 0;

                foreach (DataListItem dlist in ddlExamQuestion.Items)
                {
                    Label QuestionID = ((Label)dlist.FindControl("lblQuestionID"));
                    RadioButton OPtionA = ((RadioButton)dlist.FindControl("RadioButton4"));
                    RadioButton OptionB = ((RadioButton)dlist.FindControl("RadioButton1"));
                    RadioButton OptionC = ((RadioButton)dlist.FindControl("RadioButton2"));
                    RadioButton OptionD = ((RadioButton)dlist.FindControl("RadioButton3"));

                    if (OPtionA.Checked == true)
                    {
                        objML_ExamTransaction.OptionA = "1";
                    }
                    else
                    {
                        objML_ExamTransaction.OptionA = "0";
                    }
                    // Option B Selection
                    if (OptionB.Checked == true)
                    {
                        objML_ExamTransaction.OptionB = "1";
                    }
                    else
                    {
                        objML_ExamTransaction.OptionB = "0";
                    }
                    // Option C Selection
                    if (OptionC.Checked == true)
                    {
                        objML_ExamTransaction.OptionC = "1";
                    }
                    else
                    {
                        objML_ExamTransaction.OptionC = "0";
                    }
                    // Option D Selection
                    if (OptionD.Checked == true)
                    {
                        objML_ExamTransaction.OptionD = "1";
                    }
                    else
                    {
                        objML_ExamTransaction.OptionD = "0";
                    }
                    objML_ExamTransaction.Question = QuestionID.Text != "" ? QuestionID.Text : null;
                    objML_ExamTransaction.ExamName = Session["ExamName"].ToString();
                    objML_ExamTransaction.StudentName = Session["UserName"].ToString();
                    objML_ExamTransaction.PaperID = lblPaperID.Text != "" ? lblPaperID.Text : null;
                    objML_ExamTransaction.DocType = Session["ExamDocType"].ToString();
                    objML_ExamTransaction.QusNo = lblQusNo.Text;
                    int x = objBL_ExamTransaction.BL_InsTempSaveExam(objML_ExamTransaction);
                    if (x == 1)
                    { }

                    i = i + 1;
                }


                DataTable dt = new DataTable();
                objML_ExamTransaction.ID = Session["ExamName"].ToString();
                objML_ExamTransaction.StudentName = Session["UserName"].ToString();
                objML_ExamTransaction.QusNo = lblQusNo.Text;
                dt = objBL_ExamTransaction.BL_TempIndividualPrevious(objML_ExamTransaction);
                if (dt.Rows.Count>0)
                {
                    ddlExamQuestion.DataSource = dt;
                    ddlExamQuestion.DataBind();
                    SaveDiv.Visible = true;
                    multiplediv.Visible = false;
                    DivQuestion_DocType.Attributes.Add("Class", "col-sm-12");
                    ddlExamQuestion.Height = 200;
                    lblAllID.Text = dt.Rows[0]["QuestionID"].ToString();
                    lblPaperID.Text = dt.Rows[0]["PaperID"].ToString();
                    //lnkCounted.BackColor = System.Drawing.Color.Gray;
                    //lnkCounted.ForeColor = System.Drawing.Color.Black;
                    pnQuestion.Height = 300;
                    ddlExamQuestion.Visible = true;
                    ThankuSubmit.Visible = false;
                    StartPageDiv.Visible = false;
                    lblQusNo.Text = dt.Rows[0]["num"].ToString();
                    btnNext.Enabled = true;
                    // Temp Answear By user if submit for Temp
                    foreach (DataListItem dlist in ddlExamQuestion.Items)
                    {
                        RadioButton OPtionA = ((RadioButton)dlist.FindControl("RadioButton4"));
                        RadioButton OptionB = ((RadioButton)dlist.FindControl("RadioButton1"));
                        RadioButton OptionC = ((RadioButton)dlist.FindControl("RadioButton2"));
                        RadioButton OptionD = ((RadioButton)dlist.FindControl("RadioButton3"));
                        int UserAns = Convert.ToInt32(dt.Rows[0]["UserAns"].ToString());
                        if (UserAns == 1)
                        {
                            OPtionA.Checked = true;
                        }
                        else if (UserAns == 2)
                        {
                            OptionB.Checked = true;
                        }
                        else if (UserAns == 3)
                        {
                            OptionC.Checked = true;
                        }
                        else if (UserAns == 4)
                        {
                            OptionD.Checked = true;
                        }

                    }
                    // End
                    
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        #endregion

        #region  Save Function

        protected void SubmitExam(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                DataTable dt = new DataTable();
                objML_ExamTransaction.ExamName = Session["ExamName"].ToString();
                objML_ExamTransaction.StudentName = Session["UserName"].ToString();
                dt = objBL_ExamTransaction.BL_ShowTempQuestionList(objML_ExamTransaction);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        objML_ExamTransaction.Question = dr["QuestionID"].ToString();
                        objML_ExamTransaction.OptionA = dr["OptionA"].ToString();
                        objML_ExamTransaction.OptionB = dr["OptionB"].ToString();
                        objML_ExamTransaction.OptionC = dr["OptionC"].ToString();
                        objML_ExamTransaction.OptionD = dr["OptionD"].ToString();
                        objML_ExamTransaction.ExamName = Session["ExamName"].ToString();
                        objML_ExamTransaction.StudentName = Session["UserName"].ToString();
                        objML_ExamTransaction.PaperID = lblPaperID.Text != "" ? lblPaperID.Text : null;
                        objML_ExamTransaction.DocType = Session["ExamDocType"].ToString();
                        int x = objBL_ExamTransaction.BL_InsSubmitExam(objML_ExamTransaction);
                        if (x == 1)
                        { }

                        i = i + 1;
                    }

                    ExamQuestionValidate(objML_ExamTransaction.ExamName, objML_ExamTransaction.StudentName, objML_ExamTransaction.PaperID);
                    ExamTempDelete(objML_ExamTransaction.ExamName, objML_ExamTransaction.StudentName, objML_ExamTransaction.PaperID);
                    VisiblitySections();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        private void VisiblitySections()
        {
            ddlExamQuestion.Visible = false;
            DlAudioSection.Visible = false;
            DLVideoSection.Visible = false;
            DLComprehension.Visible = false;
            pnlComprehsion.Height = 0;
            DLReading.Visible = false;
            SaveDiv.Visible = false;
            ThankuSubmit.Visible = true;
            pnQuestion.Height = 0;
            BindVideoCollection();
            BindCollection();
            BindReadingCollection();
            string ExamDocType = Session["ExamDocType"].ToString();
            if (ExamDocType == "Individual")
            {
                DlIndividual.Visible = false;
            }
            
        }
        private void ExamQuestionValidate(string ExamName, string Student, string PaperID)
        {
            objML_ExamTransaction.ExamName = ExamName;
            objML_ExamTransaction.StudentName = Student;
            objML_ExamTransaction.PaperID = PaperID;
            int x = objBL_ExamTransaction.BL_InsValidateQuestion(objML_ExamTransaction);
            if (x == 1)
            { }
        }
        private void ExamTempDelete(string ExamName, string Student, string PaperID)
        {
            objML_ExamTransaction.ExamName = ExamName;
            objML_ExamTransaction.StudentName = Student;
            objML_ExamTransaction.PaperID = PaperID;
            int x = objBL_ExamTransaction.BL_DelTempTableExamStudent(objML_ExamTransaction);
            if (x == 1)
            { }
        }
        #endregion

        #region Validation

        private void QuestionValidation()
        {
          try
          {
              int i = 0;
              int j = 0;
           
              foreach (DataListItem dlist in ddlExamQuestion.Items)
              {
                  Label QuestionID = ((Label)dlist.FindControl("lblQuestionID"));
                  RadioButton OPtionA = ((RadioButton)dlist.FindControl("RadioButton4"));
                  RadioButton OptionB = ((RadioButton)dlist.FindControl("RadioButton1"));
                  RadioButton OptionC = ((RadioButton)dlist.FindControl("RadioButton2"));
                  RadioButton OptionD = ((RadioButton)dlist.FindControl("RadioButton3"));

                  if (OPtionA.Checked == true)
                  {
                      i = i + 1;
                  }
                  else
                  {
                      j = j + 1;
                  }
                  // Option B Selection
                  if (OptionB.Checked == true)
                  {
                      i = i + 1;
                  }
                  else
                  {
                      j = j + 1;
                  }
                  // Option C Selection
                  if (OptionC.Checked == true)
                  {
                      i = i + 1;
                  }
                  else
                  {
                      j = j + 1;
                  }
                  // Option D Selection
                  if (OptionD.Checked == true)
                  {                      
                      i = i + 1;
                  }
                  else
                  {
                      j = j + 1;
                  }
                
              }
              if (i == 0)
              {
                  ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose Atleast One Option');", true);
              }
          }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }


        #endregion

        private void BindExamEnd()
        {
            if (lblcount1.Text == "0" && lblcount4.Text == "0")
            {
                ContactDiv.Visible = true;
                StartPageDiv.Visible = false;
            }
            else
            {
                StartPageDiv.Visible = true;
            }
        }


    }
}