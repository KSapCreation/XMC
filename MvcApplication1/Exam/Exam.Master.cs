using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcApplication1.Exam
{
    public partial class Exam : System.Web.UI.MasterPage
    {
        Label lblGender = new Label();
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
            }
        }
    }
}