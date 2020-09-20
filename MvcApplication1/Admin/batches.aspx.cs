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
    public partial class batches : System.Web.UI.Page
    {
        BL_StudyBooks objBL_StudyBooks = new BL_StudyBooks();
        ML_StudyBooks objML_StudyBooks = new ML_StudyBooks();
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
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        protected void Save(object sender, EventArgs e)
        {
            try 
            {
                if (txtbatch.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Batch Name.');", true);
                }
                else if (txtCourse.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Caurse.');", true);
                }
                else if (txtDate.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Batch Date.');", true);
                }
                else if (txtStart.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Start Time.');", true);
                }
                else if (txtEnd.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill End Time.');", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select max(BatchID) as BatchID from FBNPC_Batches";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_StudyBooks.ID = dr["BatchID"].ToString();
                    }
                    if (clsCommon.myLen(objML_StudyBooks.ID) <= 0)
                    {
                        objML_StudyBooks.ID = "B00001";
                    }
                    else
                    {
                        objML_StudyBooks.ID = clsCommon.incval(objML_StudyBooks.ID);
                    }
                    con.Close();
                    objML_StudyBooks.BranchName = txtbranch.Text != "" ? txtbranch.Text : null;
                    objML_StudyBooks.BatchName = txtbatch.Text != "" ? txtbatch.Text : null;
                    objML_StudyBooks.Caurse = txtCourse.Text != "" ? txtCourse.Text : null;
                    objML_StudyBooks.BatchDate = txtDate.Text != "" ? txtDate.Text : null;
                    objML_StudyBooks.StartTime = txtStart.Text != "" ? txtStart.Text : null;
                    objML_StudyBooks.EndTime = txtEnd.Text != "" ? txtEnd.Text : null;
                    if (chkVisible.Checked == true)
                    {
                        objML_StudyBooks.isactive = "1";
                    }
                    else
                    {
                        objML_StudyBooks.isactive = "0";
                    }
                    objML_StudyBooks.CreatedBy = Session["UserName"].ToString();
                    objML_StudyBooks.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_StudyBooks.BL_InsUpdBatches(objML_StudyBooks);
                    if (x == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved.');", true);
                        BindProgramsInfo();
                        Reset();
                    }
                }
                else
                {
                    objML_StudyBooks.ID = lblID.Text != "" ? lblID.Text : null;
                    objML_StudyBooks.BranchName = txtbranch.Text != "" ? txtbranch.Text : null;
                    objML_StudyBooks.BatchName = txtbatch.Text != "" ? txtbatch.Text : null;
                    objML_StudyBooks.Caurse = txtCourse.Text != "" ? txtCourse.Text : null;
                    objML_StudyBooks.BatchDate = txtDate.Text != "" ? txtDate.Text : null;
                    objML_StudyBooks.StartTime = txtStart.Text != "" ? txtStart.Text : null;
                    objML_StudyBooks.EndTime = txtEnd.Text != "" ? txtEnd.Text : null;
                    if (chkVisible.Checked == true)
                    {
                        objML_StudyBooks.isactive = "1";
                    }
                    else
                    {
                        objML_StudyBooks.isactive = "0";
                    }
                    objML_StudyBooks.CreatedBy = Session["UserName"].ToString();
                    objML_StudyBooks.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_StudyBooks.BL_InsUpdBatches(objML_StudyBooks);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        private void Reset()
        {
            txtbatch.Text = "";
            txtbranch.Text = "";
            txtCourse.Text = "";
            txtDate.Text = "";
            txtEnd.Text = "";
            txtStart.Text = "";
            btnSave.Text = "Save";

        }
        protected void BindProgramsInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_StudyBooks.BL_Bindbatch(objML_StudyBooks);
                if (dt.Rows.Count > 0)
                {
                    GrdBatch.DataSource = dt;
                    GrdBatch.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GrdBatch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdBatch.PageIndex = e.NewPageIndex;
            BindProgramsInfo();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_StudyBooks.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_StudyBooks.BL_Deletebatches(objML_StudyBooks);
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

                    Label lblActive = new Label();
                    Label lblCategory = new Label();
                    DataTable dt = new DataTable();
                    objML_StudyBooks.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_StudyBooks.BL_BindBatchesEdit(objML_StudyBooks);
                    if (dt.Rows.Count > 0)
                    {
                        txtbatch.Text = dt.Rows[0]["BatchName"].ToString();
                        txtbranch.Text = dt.Rows[0]["BranchName"].ToString();
                        txtCourse.Text = dt.Rows[0]["Course"].ToString();
                        txtDate.Text = dt.Rows[0]["BatchDate"].ToString();
                        txtStart.Text = dt.Rows[0]["StartTime"].ToString();
                        txtEnd.Text = dt.Rows[0]["EndTime"].ToString();
                        lblActive.Text = dt.Rows[0]["IsActive"].ToString();
                        lblID.Text = dt.Rows[0]["BatchID"].ToString();
                        if (lblActive.Text == "1")
                        {
                            chkVisible.Checked = true;
                        }
                        else
                        {
                            chkVisible.Checked = false;
                        }                      
                        btnSave.Text = "Update";

                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
    }
}