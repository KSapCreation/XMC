using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;
using FBNPC;
using System.Data.SqlClient;
using common;
using FBNPC.layers.DataLayers;


namespace MvcApplication1.Exam
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        BL_Registration objBL_Registration = new BL_Registration();
        ML_Registration objML_Registration = new ML_Registration();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        CommonClass objclsCommon = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            }
        }
        protected void Register(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                string qry = "";
                qry = "select max(RegisterID) as RegisterID from FBNPC_REGISTRATION";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Transaction = trans;
                cmd.Clone();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objML_Registration.ID = dr["RegisterID"].ToString();
                }
                if (clsCommon.myLen(objML_Registration.ID) <= 0)
                {
                    objML_Registration.ID = "REG000001";
                }
                else
                {
                    objML_Registration.ID = clsCommon.incval(objML_Registration.ID);
                }
                con.Close();
                objML_Registration.UserName = txtFirstName.Text != "" ? txtFirstName.Text : null;
                objML_Registration.LastName = txtLastName.Text != "" ? txtLastName.Text : null;
                objML_Registration.Address = txtAddress.Text != "" ? txtAddress.Text : null;
                objML_Registration.City = txtCity.Text != "" ? txtCity.Text : null;
                objML_Registration.State = txtState.Text != "" ? txtState.Text : null;
                objML_Registration.PostalCode = txtPostal.Text != "" ? txtPostal.Text : null;
                objML_Registration.PhoneNo = txtPhone.Text != "" ? txtPhone.Text : null;
                objML_Registration.EmailID = txtEmail.Text != "" ? txtEmail.Text : null;
                objML_Registration.ClassOption = rbtnlist.SelectedValue != "" ? rbtnlist.SelectedValue : null;
                objML_Registration.ExamDate = txtExamDate.Text != "" ? txtExamDate.Text : null;
                objML_Registration.SpecialRequest = txtSpecialReq.Text != "" ? txtSpecialReq.Text : null;
                objML_Registration.CreatedBy = txtFirstName.Text != "" ? txtFirstName.Text : null;
                objML_Registration.ModifyBy = txtFirstName.Text != "" ? txtFirstName.Text : null;
                int x = objBL_Registration.BL_InsUpdRegistration(objML_Registration);
                if (x == 1)
                {
                    objclsCommon.RegisterLayout(txtFirstName.Text + " " + txtLastName.Text);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Thank You for Registration FBNPC.');", true);                    
                    Reset();
                }
                
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Reset()
        {
            txtAddress.Text = "";
            txtCity.Text = "";
            txtEmail.Text = "";
            txtExamDate.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtPostal.Text = "";
            txtSpecialReq.Text = "";
            txtState.Text = "";
            rbtnlist.SelectedIndex = 1;
        }
    }
}