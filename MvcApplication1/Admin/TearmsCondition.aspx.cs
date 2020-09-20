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
using System.IO;

namespace MvcApplication1.Admin
{
    public partial class TearmsCondition : System.Web.UI.Page
    {
        BL_ExamMaster objBL_ExamMaster = new BL_ExamMaster();
        ML_ExamMaster objML_ExamMaster = new ML_ExamMaster();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            if (!IsPostBack)
            {
                BindTearmsConditions();
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                string qry = "";
                qry = "select max(TearmsID) as TearmsID from FBNPC_TearmsConditions";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Transaction = trans;
                cmd.Clone();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objML_ExamMaster.ID = dr["TearmsID"].ToString();
                }
                if (clsCommon.myLen(objML_ExamMaster.ID) <= 0)
                {
                    objML_ExamMaster.ID = "TC0000001";
                }
                else
                {
                    objML_ExamMaster.ID = clsCommon.incval(objML_ExamMaster.ID);
                }
                con.Close();

                objML_ExamMaster.TearmsConditions = txtDesc.Text != "" ? txtDesc.Text : null;
                objML_ExamMaster.CreatedBy = Session["UserName"].ToString();
                objML_ExamMaster.ModifyBy = Session["UserName"].ToString();
            }
            else
            {
                objML_ExamMaster.ID = lblID.Text != "" ? lblID.Text : null;
                objML_ExamMaster.TearmsConditions = txtDesc.Text != "" ? txtDesc.Text : null;
                objML_ExamMaster.CreatedBy = Session["UserName"].ToString();
                objML_ExamMaster.ModifyBy = Session["UserName"].ToString();
            }

            int x = objBL_ExamMaster.BL_InsTeramsCondition(objML_ExamMaster);
            if (x == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved')", true);
            }
        }
        private void BindTearmsConditions()
        {
            DataTable dt = new DataTable();
            dt = objBL_ExamMaster.BL_BindTearms(objML_ExamMaster);
            if (dt.Rows.Count > 0)
            {
                txtDesc.Text = dt.Rows[0]["TearmsCondition"].ToString();
                lblID.Text = dt.Rows[0]["TearmsID"].ToString();
                btnSave.Text = "Update";

            }

        }
    }
}