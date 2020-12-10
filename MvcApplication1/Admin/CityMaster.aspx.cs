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
    public partial class CityMaster : System.Web.UI.Page
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
                BindCountryInfo();
                
            }
        }

        protected void BindStateInfo(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Panels.ID = ddlCountry.SelectedValue != "" ? ddlCountry.SelectedValue : null;
                dt = objBL_Panels.BL_StateCountryWiseBind(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    ddlState.DataSource = dt;
                    ddlState.DataValueField = "StateID";
                    ddlState.DataTextField = "Name";
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, "Select State");
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void BindCountryInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Panels.BL_CountryBind(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    ddlCountry.DataSource = dt;
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataTextField = "Name";
                    ddlCountry.DataBind();
                    ddlCountry.Items.Insert(0, "Select Country");
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
                dt = objBL_Panels.BL_CityBind(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    GrdCity.DataSource = dt;
                    GrdCity.DataBind();
                    lblGrid.Text = "";
                }
                else
                {
                    lblGrid.Text = "No Data Found !";
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GrdCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCity.PageIndex = e.NewPageIndex;
            BindProgramsInfo();

        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (ddlCountry.SelectedValue == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Country Name.');", true);
                }
                else if (ddlState.SelectedValue == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select State Name.');", true);
                }
                else if (txtDesc.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill City Name.');", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select max(CityID) as CityID from KSCN_City_Master";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Panels.ID = dr["CityID"].ToString();
                    }
                    if (clsCommon.myLen(objML_Panels.ID) <= 0)
                    {
                        objML_Panels.ID = "CITY000001";
                    }
                    else
                    {
                        objML_Panels.ID = clsCommon.incval(objML_Panels.ID);
                    }
                    con.Close();
                    objML_Panels.Desc = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_Panels.CountryID = ddlCountry.SelectedValue != "" ? ddlCountry.SelectedValue : null;
                    objML_Panels.StateID = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                    int x = objBL_Panels.BL_InsCityInfo(objML_Panels);
                    if (x == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved.');", true);
                        BindProgramsInfo();
                        Reset();
                    }
                }
                else
                {
                    objML_Panels.Desc = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                    objML_Panels.CountryID = ddlCountry.SelectedValue != "" ? ddlCountry.SelectedValue : null;
                    objML_Panels.StateID = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                    int x = objBL_Panels.BL_InsCityInfo(objML_Panels);
                    if (x == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved.');", true);
                        BindProgramsInfo();
                        Reset();
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }

        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_Panels.BL_DeleteCity(objML_Panels);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindProgramsInfo();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    LinkButton imgEdit = (LinkButton)gvr.FindControl("lnkEdit");
                    Label lblProgramsID = (Label)gvr.FindControl("lblProgramsID");
                    DataTable dt = new DataTable();
                    objML_Panels.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Panels.BL_CityEdit(objML_Panels);
                    if (dt.Rows.Count > 0)
                    {
                        txtDesc.Text = dt.Rows[0]["Name"].ToString();
                        lblID.Text = dt.Rows[0]["CityID"].ToString();
                        ddlCountry.SelectedValue = dt.Rows[0]["CountryID"].ToString();
                        ddlState.SelectedValue = dt.Rows[0]["StateID"].ToString();
                        btnSave.Text = "Update";

                    }
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        private void Reset()
        {
            txtDesc.Text = "";
            ddlCountry.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            btnSave.Text = "Save";
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
    }
}