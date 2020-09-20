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
using System.Net;
using System.Data;

namespace MvcApplication1.Admin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        BL_Login objBL_Login = new BL_Login();
        ML_Login objML_Logn = new ML_Login();
        CommonClass objCommonClass = new CommonClass();  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            lblUserName.Text = Session["UserName"].ToString();
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCategory.Text == "")
                {
                    txtCategory.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Old Password')", true);
                }
                else if (txtNew.Text == "")
                {
                    txtNew.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill New Password')", true);
                }
                else if (txtConform.Text == "")
                {
                    txtConform.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Conform Password')", true);
                }
                else
                {
                    objML_Logn.UserName = Session["UserName"].ToString();
                    objML_Logn.UserID = objCommonClass.GetEncrptPassword(txtCategory.Text);
                    objML_Logn.Password = objCommonClass.GetEncrptPassword(txtNew.Text);
                    objML_Logn.CPwd = objCommonClass.GetEncrptPassword(txtConform.Text);
                    int x = objBL_Login.BL_ChangePassword(objML_Logn);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        
    }
}