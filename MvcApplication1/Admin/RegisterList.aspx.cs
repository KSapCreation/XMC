using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.ModelLayer;
using MvcApplication1.Admin.Layer.Businesslayer;
using common;
using FBNPC;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MvcApplication1.Admin
{
    public partial class RegisterList : System.Web.UI.Page
    {
        BL_Registration objBL_Registration = new BL_Registration();
        ML_Registration objML_Registration = new ML_Registration();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            if (!IsPostBack)
            {
                BindRegisterList();
            }
        }
        private void BindRegisterList()
        {
            DataTable dt = new DataTable();            
            dt = objBL_Registration.BL_RegistrationList(objML_Registration);
            if (dt.Rows.Count > 0)
            {
                GRdListRegister.DataSource = dt;
                GRdListRegister.DataBind();
            }
            else
            {
                lblMsg.Text = "No Records Found";
                GRdListRegister.DataSource = dt;
                GRdListRegister.DataBind();
            }
        }
        protected void GRdListRegister_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GRdListRegister.PageIndex = e.NewPageIndex;
            BindRegisterList();
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
                   com.CommandText = "select RegisterID,FirstName from FBNPC_Registration where " + "FirstName like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["FirstName"].ToString());
                        }
                    }
                    con.Close();
                    return countryNames;

                }
            }
        }
        protected void Search(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Registration.UserCode = txtSearch.Text;
                objML_Registration.FromDate = (txtdtfrom.Text != "" ? txtdtfrom.Text : null);
                objML_Registration.ToDate = (txtToDate.Text != "" ? txtToDate.Text : null);
                if (objML_Registration.FromDate == null)
                {
                    objML_Registration._TYpe = "not";
                }
                dt = objBL_Registration.BL_SearchList(objML_Registration);
                if (dt.Rows.Count > 0)
                {
                    GRdListRegister.DataSource = dt;
                    GRdListRegister.DataBind();
                }
                else
                {
                    BindRegisterList();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            BindRegisterList();
            txtSearch.Text = "";
            txtdtfrom.Text = Convert.ToString(DateTime.Now.AddDays(30));
            txtToDate.Text= Convert.ToString(DateTime.Now);
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_Registration.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_Registration.BL_DeleteRegistration(objML_Registration);
                if (x == 1)
                {
                    BindRegisterList();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Delete Successfully');", true);
                }
            }
        }
    }
}