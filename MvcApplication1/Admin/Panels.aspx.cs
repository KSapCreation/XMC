using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using common;
using FBNPC;
using System.Data;

namespace MvcApplication1.Admin
{
    public partial class Panels : System.Web.UI.Page
    {
        BL_Panels objBL_Panels = new BL_Panels();
        ML_Panels objML_Panels = new ML_Panels();
        clsCommon objCommon = new clsCommon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
        }
        protected void SaveSlider(object sender, EventArgs e)
        {
            try
            {
                if (ddlPanels.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Type')", true);
                }
                else if (txtTitle.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Title of slider')", true);
                }
                else if (txtTitle.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Slider Description)", true);
                }
                else 
                {
                    objML_Panels.SliderCode = ddlPanels.SelectedValue != "" ? ddlPanels.SelectedValue : null;
                    objML_Panels.SliderTitle = txtTitle.Text != "" ? txtTitle.Text : null;
                    objML_Panels.Sliderdesc = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_Panels.CreatedBy = Session["UserName"].ToString();
                    objML_Panels.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_Panels.BL_InsSlidersInfo(objML_Panels);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('User Saved');", true);
                        Reset();
                    }
                }
              
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Reset()
        {
            txtTitle.Text = "";
            txtDesc.Text = "";
            ddlPanels.SelectedIndex = 0;
            btnSave.Text = "Save";
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Panels.ID = ddlPanels.SelectedValue != "" ? ddlPanels.SelectedValue : null;
                dt = objBL_Panels.BL_SlidersInfo(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    txtTitle.Text = dt.Rows[0]["ShortName"].ToString();
                    txtDesc.Text = dt.Rows[0]["Description"].ToString();
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
    }
}