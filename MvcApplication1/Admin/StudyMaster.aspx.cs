using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;
using FBNPC;
using System.Data.SqlClient;
using common;
using FBNPC.layers.DataLayers;

namespace MvcApplication1.Admin
{
    public partial class StudyMaster : System.Web.UI.Page
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
                BindCategory();
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtBookTitle.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Book Title')", true);
                }
                else if (txtShort.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Short Information')", true);
                }
                else if (txtShort.Text.Length > 698)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Length is greater then 700')", true);
                }
                else if (txtPrice.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Price')", true);
                }
                else if (ddlCategory.SelectedValue == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Categry')", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select max(BookID) as BookID from FBNPC_StudyBooks";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_StudyBooks.ID = dr["BookID"].ToString();
                    }
                    if (clsCommon.myLen(objML_StudyBooks.ID) <= 0)
                    {
                        objML_StudyBooks.ID = "BOOK00001";
                    }
                    else
                    {
                        objML_StudyBooks.ID = clsCommon.incval(objML_StudyBooks.ID);
                    }
                    con.Close();

                    objML_StudyBooks.BookTitle = txtBookTitle.Text != "" ? txtBookTitle.Text : null;
                    objML_StudyBooks.ShortDesc = txtShort.Text != "" ? txtShort.Text : null;
                    objML_StudyBooks.Desc = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_StudyBooks.Price = txtPrice.Text != "" ? txtPrice.Text : null;
                    objML_StudyBooks.Category = ddlCategory.SelectedValue != "" ? ddlCategory.SelectedValue : null;
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
                    int x = objBL_StudyBooks.BL_InsUpdStudyBooks(objML_StudyBooks);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved')", true);
                        Reset();
                        BindProgramsInfo();
                    }
                }
                else
                {
                    objML_StudyBooks.ID = lblID.Text != "" ? lblID.Text : null;
                    objML_StudyBooks.BookTitle = txtBookTitle.Text != "" ? txtBookTitle.Text : null;
                    objML_StudyBooks.ShortDesc = txtShort.Text != "" ? txtShort.Text : null;
                    objML_StudyBooks.Desc = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_StudyBooks.Price = txtPrice.Text != "" ? txtPrice.Text : null;
                    objML_StudyBooks.Category = ddlCategory.SelectedValue != "" ? ddlCategory.SelectedValue : null;
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
                    int x = objBL_StudyBooks.BL_InsUpdStudyBooks(objML_StudyBooks);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Update')", true);
                        Reset();
                        BindProgramsInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtBookTitle.Text = "";
            txtDesc.Text = "";
            txtPrice.Text = "";
            txtShort.Text = "";
            btnSave.Text = "Save";
            ddlCategory.SelectedIndex = 0;
        }
        protected void BindCategory()
        {
            DataTable dt = new DataTable();
            objML_StudyBooks.ID = "Study Materials";
            dt = objBL_StudyBooks.BL_BindCategory(objML_StudyBooks);
            if (dt.Rows.Count > 0)
            {
                ddlCategory.DataSource = dt;
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "Select");
            }
        }
        protected void BindProgramsInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_StudyBooks.BL_BindStudyBooks(objML_StudyBooks);
                if (dt.Rows.Count > 0)
                {
                    GrdStudyBooks.DataSource = dt;
                    GrdStudyBooks.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GrdStudyBooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdStudyBooks.PageIndex = e.NewPageIndex;
            BindProgramsInfo();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {               
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_StudyBooks.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_StudyBooks.BL_DeleteStudyBooks(objML_StudyBooks);
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
                    Label lblTitle = (Label)gvr.FindControl("lblTitleName");
                    Label lblActive = new Label();
                    DataTable dt = new DataTable();
                    objML_StudyBooks.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_StudyBooks.BL_UpdStudyBooks(objML_StudyBooks);
                    if (dt.Rows.Count > 0)
                    {
                        ddlCategory.SelectedValue = dt.Rows[0]["Category"].ToString();
                        txtBookTitle.Text = dt.Rows[0]["BookTitle"].ToString();
                        txtShort.Text = dt.Rows[0]["SortDesc"].ToString();
                        txtDesc.Text = dt.Rows[0]["Description"].ToString();
                        lblActive.Text = dt.Rows[0]["IsActive"].ToString();
                        txtPrice.Text = dt.Rows[0]["Price"].ToString();
                        lblID.Text = dt.Rows[0]["BookID"].ToString();
                        if (lblActive.Text == "1")
                        {
                            chkVisible.Checked = true;
                        }
                        else
                        {
                            chkVisible.Checked = false;
                        }
                        btnSave.Text = "Update";
                        // chkImageEdit.Visible = true;
                        //  imgEditFile.ImageUrl = "~/Handler1.ashx?ProgramEditID=" + lblProgramsID.Text;

                        //if (chkImageEdit.Checked == false)
                        //{
                        //    fileImage.Enabled = false;
                        //}
                        //else
                        //{
                        //    fileImage.Enabled = true;
                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
    }
}