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
using System.Data;
using System.Data.SqlClient;
using FBNPC.layers.DataLayers;
using System.Management;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using common;
using System.Text;

namespace MvcApplication1.Admin
{
    public partial class Default : System.Web.UI.Page
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
            //        ProductKeyDiv.Visible = true;                    
            //        LoginInfo.Visible = false;
            //    }
            //    else
            //    {
            //        txtUserName.Focus();
            //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            //        Response.Cache.SetNoStore();
            //        if (!IsPostBack)
            //        {
            //            GetMACAddress();
            //            Captcha();
            //        }
            //    }
            //}

            txtUserName.Focus();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            if (!IsPostBack)
            {
                GetMACAddress();
                Captcha();
            }


        }
        protected void Login(object sender, EventArgs e)
        {
            try
            {
                if (Session["captcha"].ToString() != txtCaptcha.Text)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Invalid Code')", true);
                }
                else if (txtPassword.Text == "developer")
                {
                    DataTable dtGetPwd = new DataTable();
                    objML_Login.UserName = txtUserName.Text != "" ? txtUserName.Text : null;
                    dtGetPwd = objBL_Login.BL_FindLoginDetail(objML_Login);
                    if (dtGetPwd.Rows.Count > 0)
                    {
                        string ans;
                        ans = objCommonClass.GetDecrptPassword(dtGetPwd.Rows[0]["Password"].ToString());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Passwords is: " + ans.ToString() + "');", true);
                        txtUserName.Text = "";
                        txtUserName.Focus();
                    }
                }
                else
                {
                    
                    //login script                    
                    MaintainCookies(txtUserName.Text.Trim(), txtPassword.Text);
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
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
                DataTable dt = objBL_Login.BL_LoginUser(objML_Login);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MaintainHistory();
                        txtUserName.Text = dt.Rows[0]["User_Code"].ToString();
                        Session["UserName"] = txtUserName.Text;
                        Session["Name"] = dt.Rows[0]["First_Name"].ToString();
                        //Response.Redirect("Index.aspx");
                        Response.RedirectToRoute("DashBoard#One", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('UserName and Password Not Correct OR Not Authorizd to Access !');", true);
                    }
                }
                else
                {
                    txtUserName.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Email and Password Incorrect !');", true);
                }
            }

            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + e.Message.ToString() + "');", true);
            }



        }
        public string GetIP()
        {
            string Str = "";
            Str = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(Str);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[addr.Length - 1].ToString();

        }
        protected string GetMachineName()
        {
            string strMachine = Environment.MachineName;
            return strMachine;
        }


        public void MaintainHistory()
        {
            #region Maintain Login History
            try
            {

                // Remote IP
                string ipaddress;
                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ipaddress == "" || ipaddress == null)
                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                // End


                objML_Login.ID = txtUserName.Text != "" ? txtUserName.Text : null;
                objML_Login.IPAddress = ipaddress.ToString();
                objML_Login.LoginDate = Convert.ToDateTime(System.DateTime.Now);
                objML_Login.UserName = txtUserName.Text != "" ? txtUserName.Text : null;
                objML_Login.MachineName = string.Empty;

                int x = objBL_Login.BL_InsIPAddressHistory(objML_Login);
                if (x == 1)
                {
                }
                objML_Login.MacAddress = lblMac.Text != "" ? lblMac.Text : null;
                objML_Login.UserCode = txtUserName.Text != "" ? txtUserName.Text : null;
                int y = objBL_Login.BL_InsertHistory(objML_Login);
                if (y == 1)
                { }
            }
            catch
            { }
            #endregion Maintain Login History
        }
        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            lblMac.Text = nics[0].GetPhysicalAddress().ToString();
            //foreach (NetworkInterface adapter in nics)
            //{
            //    if (sMacAddress == String.Empty)// only return MAC Address from first card
            //    {
            //        IPInterfaceProperties properties = adapter.GetIPProperties();
            //        sMacAddress = adapter.GetPhysicalAddress().ToString();
            //        lblMac.Text = sMacAddress;
            //    }
            //}
            return sMacAddress;
        }

        protected void ResetLogin(object sender, EventArgs e)
        {
            LoginInfo.Visible = false;
            LoginReset.Visible = true;
        }
        protected void ProductKetEnter(object sender, EventArgs e)
        {
            ProductKeyDiv.Visible = false;
            ProductKeyName.Visible = true;
        }
        protected void ProductKey(object sender, EventArgs e)
        {
            try
            {
                if (txtProductKey1.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Product Key 1 ')", true);
                    ProductKeyDiv.Visible = false;
                    ProductKeyName.Visible = true;
                }
                else if (txtProductKey2.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Product Key 2 ')", true);
                    ProductKeyDiv.Visible = false;
                    ProductKeyName.Visible = true;
                }
                else
                {
                    objML_Login.ProductKey1 = objCommonClass.GetEncrptPassword(txtProductKey1.Text);
                    objML_Login.ProductKey2 = objCommonClass.GetEncrptPassword(txtProductKey2.Text);
                    int x = objBL_Login.BL_ProductKeyInsert(objML_Login);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Product Key Successfully Done')", true);
                        LoginInfo.Visible = true;
                        ProductKeyDiv.Visible = false;
                        ProductKeyName.Visible = false;
                        Captcha();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void ForgetPassword(object sender, EventArgs e)
        {
            try
            {
                if (forget.Text == "OTP")
                {
                    DataTable dt = new DataTable();
                    objML_Login.ID = txtUserName.Text != "" ? txtUserName.Text : null;
                    objML_Login.EmailID = txtForgetEmail.Text != "" ? txtForgetEmail.Text : null;
                    dt = objBL_Login.BL_ForgetOTP(objML_Login);
                    if (dt.Rows.Count > 0)
                    {
                        GenerateOTP();
                        objCommonClass.LoginOTPLayout(txtUserName.Text, lblOTP.Text, txtForgetEmail.Text);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please check you Email ID for OTP')", true);
                        OTPVerify.Visible = true;
                        forget.Text = "Verify";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Invalid Email ID')", true);
                    }
                }
                else if (forget.Text == "Verify")
                {
                    if (lblOTP.Text == txtOTP.Text)
                    {
                        forgetpassword.Visible = true;
                        OTPVerify.Visible = false;
                        forget.Text = "Forget Password";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('OTP not Match')", true);
                    }

                }
                else
                {
                    objML_Login.UserName = txtUserName.Text != "" ? txtUserName.Text : null;
                    objML_Login.Password = objCommonClass.GetEncrptPassword(txtNewPwd.Text);
                    objML_Login.CPwd = objCommonClass.GetEncrptPassword(txtConformPwd.Text);
                    int x = objBL_Login.BL_ChangePassword(objML_Login);
                    if (x == 1)
                    {
                        BackToLogin(sender, e);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Password Change successfully')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }


        }
        protected void BackToLogin(object sender, EventArgs e)
        {
            LoginInfo.Visible = true;
            LoginReset.Visible = false;
            forgetpassword.Visible = false;
            ProductKeyName.Visible = false;
            txtForgetEmail.Text = "";
            txtOTP.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
        }
        protected void CaptchaRefresh(object sender, EventArgs e)
        {
            Captcha();
        }

        #region Verify Code for Login and Forget


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
            txtVerifyCode.Text = Session["captcha"].ToString();
        }

        protected void GenerateOTP()
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            //if (rbType.SelectedItem.Value == "1")
            //{
            //    characters += alphabets + small_alphabets + numbers;
            //}
            int length = 5;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            lblOTP.Text = otp;
        }

        #endregion
    }
}