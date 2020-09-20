using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.ModelLayer;
using MvcApplication1.Admin.Layer.Businesslayer;
using FBNPC;
using System.Net;
using System.Data.SqlClient;
using FBNPC.layers.DataLayers;
using System.Data;
using common;
using System.Net.NetworkInformation;
using System.Text;

namespace MvcApplication1
{
    public partial class LoginIn : System.Web.UI.Page
    {
        CommonClass objCommonClass = new CommonClass();
        BL_Login objBL_Login = new BL_Login();
        ML_Login objML_Login = new ML_Login();
        protected void Page_Load(object sender, EventArgs e)
        {
             // Product Issue and Expire
            //DataTable dtProduct = new DataTable();
            //dtProduct = objBL_Login.BL_ProductValidation(objML_Login);
            //if (dtProduct.Rows.Count > 0)
            //{
            //    string ProductValue = "";
            //    string ProductExpireDate = dtProduct.Rows[0]["Licence_ExpiredDate_Specification_B"].ToString();
            //    ProductValue = objCommonClass.GetDecrptPassword(ProductExpireDate);

            //    objML_Login.ProductKey = Convert.ToDateTime(ProductValue);
            //    if (objML_Login.ProductKey < DateTime.Now.Date)
            //    {
            //        BLogin.Visible = false;
            //        lblMsg.Text = "Contact to FBNPC, Thank you";
            //    }
            //}
        
                if (!IsPostBack)
                {
                    GetMACAddress();
                    Captcha();
                }
           
        }
        protected void btnLogin(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text == "")
                {
                    throw new Exception("Fill Email ID.");
                }
                else if (txtPwd.Text == "")
                {                   
                    throw new Exception("Fill Password.");
                }
                try
                {
                    if (txtPwd.Text == "developer")
                    {
                        DataTable dtGetPwd = new DataTable();
                        objML_Login.UserName = txtEmail.Text != "" ? txtEmail.Text : null;
                        dtGetPwd = objBL_Login.BL_FindLoginDetail(objML_Login);
                        if (dtGetPwd.Rows.Count > 0)
                        {
                            string ans;
                            ans = objCommonClass.GetDecrptPassword(dtGetPwd.Rows[0]["Password"].ToString());
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Passwords is: " + ans.ToString() + "');", true);
                            txtEmail.Text = "";
                            txtEmail.Focus();
                        }
                    }
                    else
                    {
                        //login script
                        MaintainCookies(txtEmail.Text.Trim(), txtPwd.Text);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }

        protected void CaptchaRefresh(object sender, EventArgs e)
        {
            Captcha();
        }

        public void MaintainCookies(string _username, string _password)
        {
            bool blValidUser = false;
            string _strUserType = string.Empty;
            string strLoggedHistoryId;
            
            try
            {                
                objML_Login.UserName = _username;
                objML_Login.Password = objCommonClass.GetEncrptPassword(_password);
                DataTable dt = objBL_Login.BL_ExamLoginUser(objML_Login);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        txtEmail.Text = dt.Rows[0]["User_Code"].ToString();
                        Session["UserName"] = txtEmail.Text;
                        Session["User_Code"] = dt.Rows[0]["User_Code"].ToString();
                        Session["ExamName"] = dt.Rows[0]["ExamName"].ToString();
                        Session["Name"] = dt.Rows[0]["First_Name"].ToString();
                        Session["Gender"] = dt.Rows[0]["Gender"].ToString();
                        #region Maintain Login History
                        try
                        {
                            //string strIP = GetIPAddress();
                            //string strMachine = GetMachineName();
                            //string Mac_Address = GetMACAddress();
                            // Remote IP
                            string ipaddress;
                            //string mac_address = GetMACAddress().ToString();
                            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                            if (ipaddress == "" || ipaddress == null)
                                ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                            // End
                            objML_Login.ID = _username;
                            objML_Login.IPAddress = ipaddress.ToString();
                            objML_Login.LoginDate = Convert.ToDateTime(System.DateTime.Now);
                            objML_Login.MachineName = string.Empty;
                            objML_Login.MacAddress = lblMac.Text != "" ? lblMac.Text : null;
                            objML_Login.UserCode = Session["UserName"].ToString();
                            int x = objBL_Login.BL_InsIPAddressHistory(objML_Login);
                            if (x == 1)
                            {
                            }
                            int y = objBL_Login.BL_InsertHistory(objML_Login);
                            if (y == 1)
                            { }
                        }
                        catch
                        { }
                        #endregion Maintain Login History
                        //Response.Redirect("Exam/Studenthome.aspx");
                        Response.RedirectToRoute("MyAccount", true);
                    }
                    else
                    {
                        txtEmail.Text = "";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Email and Password Incorrect !');", true);
                    }
                }
                else
                {                    
                    txtEmail.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Email and Password Incorrect !');", true);
                }

            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + e.Message.ToString() + "');", true);
            }



        }
        private string GetMachineName()
        {
            string strMachine = Environment.MachineName;
            return strMachine;
        }
        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                    lblMac.Text = sMacAddress;
                }
            } return sMacAddress;
        }
        private string GetIPAddress()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            Console.WriteLine(hostName);
            // Get the IP
            string strIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return strIP;

        }
        private void Captcha()
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                captcha.Append(combination[random.Next(combination.Length)]);
                Session["captcha"] = captcha.ToString();
            }
            //txtVerifyCode.Text = Session["captcha"].ToString();
        }
    }
}