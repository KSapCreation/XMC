using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;

namespace MvcApplication1.Exam
{
    public partial class Student : System.Web.UI.MasterPage
    {
        BL_StudentProfile objBL_StudentProfile = new BL_StudentProfile();
        ML_StudentProfile objML_StudentProfile = new ML_StudentProfile();
        Label lblGender = new Label();
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!IsPostBack)
            {
                lblUSer.Text = Session["name"].ToString();
                lblUserName.Text = Session["name"].ToString();
                lblGender.Text = Session["Gender"].ToString();
                
                if (lblGender.Text == "Female")
                {
                    FeMale.Visible = true;
                    logoutFemale.Visible = true;
                }
                else
                {
                    Male.Visible = true;
                    logoutmale.Visible = true;
                }



                bindExamCount();
                
            }
        }
        protected void bindExamCount()
        {
            DataTable dt = new DataTable();
            objML_StudentProfile.ID = Session["UserName"].ToString();
            dt = objBL_StudentProfile.BL_BindStudentExam(objML_StudentProfile);
            if (dt.Rows.Count > 0)
            {
                lblCountExam.Text = dt.Rows[0]["cnt"].ToString();
            }
            else
            {
                lblCountExam.Text = "0";
            }


        }
        
       
    }
}