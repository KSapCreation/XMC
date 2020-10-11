using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FBNPC.layers.DataLayers;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Drawing;
using common;
using System.Globalization;

namespace MvcApplication1.Exam
{
    public partial class Exam : System.Web.UI.MasterPage
    {
        Label lblGender = new Label();
        string SectionTime;
        DateTime endDate;
        ML_ExamTransaction objML_ExamTransaction = new ML_ExamTransaction();
        BL_ExamTransaction objBL_ExamTransaction = new BL_ExamTransaction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/LoginIn.aspx", true);
            }
            if (!IsPostBack)
            {
                lblGender.Text = Session["Gender"].ToString();
                if (lblGender.Text == "Female")
                {                    
                    logoutFemale.Visible = true;
                }
                else
                {                 
                    logoutmale.Visible = true;
                }
                this.lblStudentLOginName.Text = Session["Name"].ToString();
                if (lblExamSectionTime.Text.Length == 0)
                {
                    BindSectionTime();
                }
                
            }
            
        }

             protected void timer10(object sender, EventArgs e)
        {
            var CaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Canada Central Standard Time");
            DateTime CaTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, CaTimeZone);
            lblTImerCA.Text = Convert.ToString(CaTime);

            DateTime startdate = CaTime;

            
            DateTime Sectionendtime = Convert.ToDateTime(lblExamSectionTime.Text);
            lblTime.Text = CalculateTimeDifference(startdate, Sectionendtime);
        }
        public void BindSectionTime()
        {          
            
            
            DataTable dt = new DataTable();
            
            objML_ExamTransaction.ExamName = Session["ExamName"].ToString();
            objML_ExamTransaction.ID = Session["UserName"].ToString();
            dt = objBL_ExamTransaction.BL_GetSectionTime(objML_ExamTransaction);
            if (dt.Rows.Count > 0)
            {
               
                SectionTime = (dt.Rows[0]["time_added"].ToString());
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("EndDate", typeof(DateTime));
                dt1.Rows.Add(SectionTime);

                var CaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Canada Central Standard Time");
                DateTime CaTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, CaTimeZone);
                lblTImerCA.Text = Convert.ToString(CaTime);

                DateTime startdate = CaTime;

                endDate = Convert.ToDateTime(dt1.Rows[0]["EndDate"].ToString());
                                endDate = DateTime.Parse(endDate.ToString("HH:mm:ss"));
                lblExamSectionTime.Text = Convert.ToString(endDate);
                
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
                final = string.Format("{0} hours {1} mins {2} secs",  hours, mins, secs);
            }
            return final;
        }

    }
  
}