﻿using System;
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
    public partial class Category : System.Web.UI.Page
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
        protected void BindProgramsInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Panels.BL_CategoryBind(objML_Panels);
                if (dt.Rows.Count > 0)
                {
                    GrdCategory.DataSource = dt;
                    GrdCategory.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GrdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCategory.PageIndex = e.NewPageIndex;
            BindProgramsInfo();

        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCategory.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Category Name.');", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select max(CategoryID) as GalleryID from FBNPC_Category_Master";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Panels.ID = dr["GalleryID"].ToString();
                    }
                    if (clsCommon.myLen(objML_Panels.ID) <= 0)
                    {
                        objML_Panels.ID = "C00001";
                    }
                    else
                    {
                        objML_Panels.ID = clsCommon.incval(objML_Panels.ID);
                    }
                    con.Close();
                    objML_Panels.Category = txtCategory.Text != "" ? txtCategory.Text : null;
                    objML_Panels.Desc = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_Panels.CreatedBy = Session["UserName"].ToString();
                    objML_Panels.ModifyBy = Session["UserName"].ToString();
                    objML_Panels.DocTypes = RbtnList.SelectedItem.Text != "" ? RbtnList.SelectedItem.Text : null;
                    if (chkVisible.Checked == true)
                    {
                        objML_Panels.ISActive = "1";
                    }
                    else
                    {
                        objML_Panels.ISActive = "0";
                    }
                    //                    objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                    int x = objBL_Panels.BL_InsCategoryInfo(objML_Panels);
                    if (x == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved.');", true);
                        BindProgramsInfo();
                        Reset();
                    }
                }
                else
                {                   
                    objML_Panels.Category = txtCategory.Text != "" ? txtCategory.Text : null;
                    objML_Panels.Desc = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_Panels.CreatedBy = Session["UserName"].ToString();
                    objML_Panels.ModifyBy = Session["UserName"].ToString();
                    objML_Panels.DocTypes = RbtnList.SelectedItem.Text != "" ? RbtnList.SelectedItem.Text : null;
                    if (chkVisible.Checked == true)
                    {
                        objML_Panels.ISActive = "1";
                    }
                    else
                    {
                        objML_Panels.ISActive = "0";
                    }
                    objML_Panels.ID = lblID.Text != "" ? lblID.Text : null;
                    int x = objBL_Panels.BL_InsCategoryInfo(objML_Panels);
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
                int x = objBL_Panels.BL_DeleteCategory(objML_Panels);
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
                RbtnList.Items[0].Selected = false;
                RbtnList.Items[1].Selected = false;
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    LinkButton imgEdit = (LinkButton)gvr.FindControl("lnkEdit");
                    Label lblProgramsID = (Label)gvr.FindControl("lblProgramsID");
                    
                    Label lblActive = new Label();
                    Label lblCategory = new Label();
                    DataTable dt = new DataTable();
                    objML_Panels.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Panels.BL_CategoryEdit(objML_Panels);
                    if (dt.Rows.Count > 0)
                    {
                        txtCategory.Text = dt.Rows[0]["Name"].ToString();
                        txtDesc.Text = dt.Rows[0]["Description"].ToString();
                        lblActive.Text = dt.Rows[0]["IsActive"].ToString();
                        lblID.Text = dt.Rows[0]["CategoryID"].ToString();
                        if (lblActive.Text == "1")
                        {
                            chkVisible.Checked = true;
                        }
                        else
                        {
                            chkVisible.Checked = false;
                        }
                        lblCategory.Text = dt.Rows[0]["DocType"].ToString();

                        if (lblCategory.Text == "Gallery Category")
                        {
                            RbtnList.Items[0].Selected = true;
                        }
                        else
                        {
                            RbtnList.Items[1].Selected = true;
                        }
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
            txtCategory.Text = ""; 
            txtDesc.Text = "";
            chkVisible.Visible = false;
            btnSave.Text = "Save";
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
    }
}