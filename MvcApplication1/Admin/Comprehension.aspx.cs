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
using FBNPC.layers.DataLayers;


namespace MvcApplication1.Admin
{
    public partial class Comprehension : System.Web.UI.Page
    {
        BL_Panels objBL_Panels = new BL_Panels();
        ML_Panels objML_Panels = new ML_Panels();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            if (!IsPostBack)
            {
                BindProgramsInfo();
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {

                if (txtCategory.Text == "")
                {
                    txtCategory.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Fill Comprehension Name');", true);
                }
                else if (txtDesc.Text == "")
                {
                    txtDesc.Focus();
                    ScriptManager.RegisterStartupScript(this,this.GetType(), "alert", "alert('Fill Comprehension');", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select max(ReadingID) as ReadingID from FBNPC_Comprehension_Master";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Panels.ReadingID = dr["ReadingID"].ToString();
                    }
                    if (clsCommon.myLen(objML_Panels.ReadingID) <= 0)
                    {
                        objML_Panels.ReadingID = "RD000000001";
                    }
                    else
                    {
                        objML_Panels.ReadingID = clsCommon.incval(objML_Panels.ReadingID);
                    }
                    con.Close();
                    objML_Panels.ComprehensionName = txtCategory.Text != "" ? txtCategory.Text : null;
                    objML_Panels.ComprehensionDesc = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_Panels.CreatedBy = Session["UserName"].ToString();
                    objML_Panels.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_Panels.BL_InsUpdComprehension(objML_Panels);
                    if (x == 1)
                    {
                        BindProgramsInfo();
                        Reset();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved')", true);
                    }
                }
                else
                {
                    objML_Panels.ReadingID = lblID.Text != "" ? lblID.Text : null;
                    objML_Panels.ComprehensionName = txtCategory.Text != "" ? txtCategory.Text : null;
                    objML_Panels.ComprehensionDesc = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_Panels.CreatedBy = Session["UserName"].ToString();
                    objML_Panels.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_Panels.BL_InsUpdComprehension(objML_Panels);
                    if (x == 1)
                    {
                        BindProgramsInfo();
                        Reset();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved')", true);
                    }
                }



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this,this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            txtCategory.Text = "";
            txtDesc.Text = "";
        }
        private void Reset()
        {
            txtCategory.Text = "";
            txtDesc.Text = "";
            btnSave.Text = "Save";
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_Panels.BL_DeleteComprehension(objML_Panels);
                if (x == 1)
                {
                    BindProgramsInfo();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);                    
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {             
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblProgramsID");
                    DataTable dt = new DataTable();
                    objML_Panels.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Panels.BL_EditComprehension(objML_Panels);
                    if (dt.Rows.Count > 0)
                    {
                        lblID.Text = dt.Rows[0]["ReadingID"].ToString();
                        txtCategory.Text = dt.Rows[0]["ComprehensionName"].ToString();
                        txtDesc.Text = dt.Rows[0]["ComprehensionDesc"].ToString();                       
                        btnSave.Text = "Update";
                    }
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void BindProgramsInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Panels.BL_BindComprehension(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    GrdComprehension.DataSource = dt;
                    GrdComprehension.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GrdComprehension_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdComprehension.PageIndex = e.NewPageIndex;
            BindProgramsInfo();

        }
    }
}