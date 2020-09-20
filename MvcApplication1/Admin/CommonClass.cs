using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MvcApplication1.Admin.Layer.ModelLayer;
using MvcApplication1.Admin.Layer.Businesslayer;
using System.Net.Mail;
using System.Data;
using System.IO;
using System.Security.Cryptography;

namespace FBNPC
{
    public class CommonClass
    {
        private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");

        #region Password Encrpt
        public string GetEncrptPassword(string password)
        {
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(encode);

          
        }
        public string GetDecrptPassword(string password)
        {
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(password);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            return new String(decoded_char);
        }

        #endregion

        #region Page Control
        public bool GetPageAccess(string strUserId, string strPage)
        {
            bool blAccess = false;
            if (HttpContext.Current.Session["UserId"] == null && HttpContext.Current.Request.Cookies["Tecxpert"] != null)
            {
                //SetSessionFromCookies();
              //  blAccess = GetScreenAccess(strPage);
            }
            else if (HttpContext.Current.Session["UserId"] == null && HttpContext.Current.Request.Cookies["Tecxpert"] == null)
             {
                 SetSessionFromCookies();
                 blAccess = GetScreenAccess(strPage);
             }
            else
            {
                blAccess = GetScreenAccess(strPage);
            }
            return blAccess;
        }

        private bool GetScreenAccess(string strPage)
        {
            bool blAccess = false;         
            //BL_UserAccess objBL_UserAccess = new BL_UserAccess();
            //ML_UserAccess objML_UserAccess = new ML_UserAccess();
            //objML_UserAccess.UserId = Convert.ToString(HttpContext.Current.Session["UserId"]);
            //objML_UserAccess.PageName = strPage;
            //DataTable dt = objBL_UserAccess.BL_SelectPagesName(objML_UserAccess);
            //if (dt != null)
            //{
            //    if (dt.Rows.Count > 0)
            //    {                 
            //            blAccess = true;                   
            //    }
            //    else
            //    {
            //        blAccess = false;
            //    }                
            //}           
            return blAccess;
        }
        public bool SetSessionFromCookies()
        {
            bool blCookie = false;        
            if (HttpContext.Current.Request.Cookies["Tecxpert"] != null)
            {
                HttpContext.Current.Session["UserId"] = HttpContext.Current.Request.Cookies["Tecxpert"]["UserId"];
                HttpContext.Current.Session["UserType"] = HttpContext.Current.Request.Cookies["Tecxpert"]["UserType"];                
                blCookie = true;
            }
            else
            {
                blCookie = false;
            }
            return blCookie;

        }
        #endregion

        public void LayoutData(string Name, string Email, string PhoneNo,string Message)
        {
            string Desgnbody = "";
            string subject = "";
            StringBuilder emailMessage = new StringBuilder();
            emailMessage.Append("<b>" + "Welcome to Future Building  Nursing Prep Center" + "</b><br /><br />");
            emailMessage.AppendLine();
            emailMessage.Append("<b> Name:  </b>" + Name + "<br /><br />");
            emailMessage.AppendLine();
            emailMessage.Append("<b> Email ID:  </b>" + Email + "<br /><br />");
            emailMessage.AppendLine();
            emailMessage.Append("<b> Phone No:  </b>" + PhoneNo + "<br /><br />");
            emailMessage.AppendLine();
            emailMessage.Append("<b> Enquiry :  </b>" + Message + "<br /><br />");
            emailMessage.AppendLine();   
            emailMessage.Append("Thank you<br />");
            emailMessage.Append("<b>" + "FBNPC" + "</b>");
            Desgnbody = emailMessage.ToString();

            // Subject Body
            StringBuilder SubjectMessage = new StringBuilder();
            SubjectMessage.Append("Query FBNPC");
            // function called
            subject = SubjectMessage.ToString();
            SendMail("Feedback@fbnpc.com", Desgnbody, subject);    


        }
        public void RegisterLayout(string Name)
        {
            string Desgnbody = "";
            string subject = "";
            StringBuilder emailMessage = new StringBuilder();
            emailMessage.Append("" + "One Registration for <b>" + Name + " </b> please check you admin panel for more detail<br />");
            emailMessage.AppendLine();          
            emailMessage.Append("Thank you<br />");
            emailMessage.Append("<b>" + "FBNPC" + "</b>");
            Desgnbody = emailMessage.ToString();

            // Subject Body
            StringBuilder SubjectMessage = new StringBuilder();
            SubjectMessage.Append("Register FBNPC");
            // function called
            subject = SubjectMessage.ToString();
            SendMail("Feedback@fbnpc.com", Desgnbody, subject);


        }
        public void LoginOTPLayout(string Name,string OTP,string MailID)
        {
            string Desgnbody = "";
            string subject = "";
            StringBuilder emailMessage = new StringBuilder();
            emailMessage.Append("" + "One Time Password used for Password  <b>" + OTP + " </b> <br />");
            emailMessage.AppendLine();
            emailMessage.Append("Thank you<br />");
            emailMessage.Append("<b>" + "FBNPC" + "</b>");
            Desgnbody = emailMessage.ToString();

            // Subject Body
            StringBuilder SubjectMessage = new StringBuilder();
            SubjectMessage.Append("Register FBNPC");
            // function called
            subject = SubjectMessage.ToString();
            SendMail(MailID, Desgnbody, subject);


        }
        public void ThankyouLayout(string Name,string Email)
        {
            string Desgnbody = "";
            string subject = "";
            StringBuilder emailMessage = new StringBuilder();
            emailMessage.Append("" + "Thank you very much for contacting Future Building Nursing Prep Center. One of our expert advisors will be in touch with you soon. <br /> If your enquiry needs urgent attention please, call us at 306-316-0411 <br /> ");
            emailMessage.AppendLine();
            emailMessage.Append("Thank you<br />");
            emailMessage.Append("<b>" + "FBNPC" + "</b>");
            Desgnbody = emailMessage.ToString();

            // Subject Body
            StringBuilder SubjectMessage = new StringBuilder();
            SubjectMessage.Append("FBNPC");
            // function called
            subject = SubjectMessage.ToString();
            SendMail(Email, Desgnbody, subject);


        }

        #region Send Mail System

        public void SendMail(string mailTo, string mailBody, string subject)
        {
            string strMailCredentialUserName = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["MailCredentialUserName"]);
            string strMailCredentialPassword = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["MailCredentialPassword"]);
            string strMailClientHost = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["MailClientHost"]);
            string strWebSmtpPort = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"]);
            string strMailFrom = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["MailFrom"]);

            SmtpClient SmtpServer = new SmtpClient();
            
            SmtpServer.Credentials = new System.Net.NetworkCredential(strMailCredentialUserName, strMailCredentialPassword);

            SmtpServer.Host = strMailClientHost;
            SmtpServer.EnableSsl = false;
                       
            MailMessage mail = new MailMessage();
            try
            {
                mail.From = new MailAddress(strMailCredentialUserName, "FBNPC", System.Text.Encoding.UTF8);
             
                mail.Subject = subject;
                mail.Body = mailBody;
                mail.IsBodyHtml = true;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.ReplyTo = new MailAddress(strMailFrom);                              
                {
                    mail.To.Add(mailTo);
                    mail.CC.Add("nursingprepcenter@gmail.com");                    
                    SmtpServer.Send(mail);
                }
            }
            catch (Exception err)
            {

            }


        }
        #endregion

        #region Profile
        public bool UserPrifleAccess(string EmpDep)
        {
            bool blAccess = false;
            if (EmpDep == "Dep/1004")
            {
                blAccess = false;
            }
            else
            {
                blAccess = true;
            }
            return blAccess;

        }

        #endregion
    }
}