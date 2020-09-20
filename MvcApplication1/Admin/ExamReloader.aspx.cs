using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FBNPC;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data.SqlClient;
using System.Configuration;

namespace MvcApplication1.Admin
{
    public partial class ExamReloader : System.Web.UI.Page
    {
        ML_Login objML_Login = new ML_Login();
        BL_Login objBL_Login = new BL_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            if (!IsPostBack)
            {
            
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtStudent.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Fill Student Name');", true);
                }
                else if (txtExamName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Fill Exam Name');", true);
                }
                else
                {

                    lblMessage.Text = "Re-load Exam for <b>" + txtStudent.Text + "</b> Successfully done !";
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        private void Reset()
        {
            txtExamName.Text = "";
            txtStudent.Text = "";

        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.AppSettings["FBNPC"];

                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select User_Code from FBNPC_USER_MASTER where " + "first_name like '%' + @Search + '%' and PraticeType=1";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["User_Code"].ToString());
                        }
                    }
                    con.Close();
                    return countryNames;


                }

            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetExamList(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.AppSettings["FBNPC"];

                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select ExamName +' '+ ExamID as [ExamNameID] from FBNPC_EXAMLISTNAME where " + "ExamName like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["ExamNameID"].ToString());
                        }
                    }
                    con.Close();
                    return countryNames;
                }

            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
    }
}