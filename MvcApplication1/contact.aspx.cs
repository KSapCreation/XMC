using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using FBNPC;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace MvcApplication1
{
    public partial class contact : System.Web.UI.Page
    {
        ML_Default objML_Default = new ML_Default();
        BL_Default objBL_Default = new BL_Default();
        CommonClass objCommonClass = new CommonClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenu();
            }
        }
        protected void SaveMail(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Name')", true);
            }
            else if (txtPhone.Text == "")
            {
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Phone No')", true);
            }
            else
            {
               objCommonClass.LayoutData(txtName.Text, txtEmail.Text, txtPhone.Text, txtdesc.Text);
               objCommonClass.ThankyouLayout(txtName.Text, txtEmail.Text);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Mail Sent')", true);
                Reset();
            }
        }
        private void Reset()
        {
            txtdesc.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
        }
        protected void BindMenu()
        {
            DataTable dt = new DataTable();
            dt = objBL_Default.BL_DLMenu(objML_Default);
            if (dt.Rows.Count > 0)
            {
                DLMenu.DataSource = dt;
                DLMenu.DataBind();
            }
        }
        protected void EditShow(object sender, EventArgs e)
        {
            DataListItem gvr = (DataListItem)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblID");
                DataTable dt = new DataTable();
                objML_Default.ID = lblID.Text != "" ? lblID.Text : null;
                dt = objBL_Default.BL_ProgramsData(objML_Default);
                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("Detail.aspx?ID=" + lblID.Text, true);
                }
            }
        }
    }
}