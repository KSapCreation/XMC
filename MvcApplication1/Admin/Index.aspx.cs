using FBNPC;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcApplication1.Admin
{
    public partial class Index : System.Web.UI.Page
    {
        protected bool blAccess = false;
        CommonClass objCommanClass = new CommonClass();
        BL_AdminDashBoard objBL_AdminDashBoard = new BL_AdminDashBoard();
        ML_AdminDashBoard objML_AdminDashBoard = new ML_AdminDashBoard();

        protected void Page_Load(object sender, EventArgs e)
        {
            blAccess = objCommanClass.GetPageAccess(Convert.ToString(Session["UserId"]), "Account Type");
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx", true);
            }
            if (!IsPostBack)
            {
                BindUserMaster();
                BindResgitration();
            }
        }
        #region Admin Dashboard
        public class Data
        {
            public string ColumnName = "";
            public int Value = 0;
            public string studentName = "";
            public Data(string columnName, int value)
            {
                ColumnName = columnName;
                Value = value;

            }
        }
        [WebMethod]
        public static List<Data> GetData()
        {
            BL_AdminDashBoard objBL_AdminDashBoard = new BL_AdminDashBoard();
            ML_AdminDashBoard objML_AdminDashBoard = new ML_AdminDashBoard();

            DataTable dt = new DataTable();
            dt = objBL_AdminDashBoard.BL_ExamListDashBoard(objML_AdminDashBoard);
            List<Data> dataList = new List<Data>();
            string cat = "";
            int val = 0;
            foreach (DataRow dr in dt.Rows)
            {
                cat = dr[0].ToString();
                val = Convert.ToInt32(dr[1]);
                dataList.Add(new Data(cat, val));
            }
            return dataList;
        }

        [WebMethod]
        public static List<convertdetails> GetChartData()
        {
            BL_AdminDashBoard objBL_AdminDashBoard = new BL_AdminDashBoard();
            ML_AdminDashBoard objML_AdminDashBoard = new ML_AdminDashBoard();
            DataTable dt = new DataTable();

            dt = objBL_AdminDashBoard.BL_RegstraionExamProvideDashBoard(objML_AdminDashBoard);
            List<convertdetails> dataList = new List<convertdetails>();
            foreach (DataRow dtrow in dt.Rows)
            {
                convertdetails details = new convertdetails();
                details.Convertname = dtrow[0].ToString();
                details.Total = Convert.ToInt32(dtrow[1]);
                dataList.Add(details);
            }
            return dataList;
        }

        public class convertdetails
        {
            public string Convertname { get; set; }
            public int Total { get; set; }
        }
        [WebMethod]
        public static List<AudioVideo> GetChartAudioVideoCountData()
        {
            BL_AdminDashBoard objBL_AdminDashBoard = new BL_AdminDashBoard();
            ML_AdminDashBoard objML_AdminDashBoard = new ML_AdminDashBoard();
            DataTable dt = new DataTable();

            dt = objBL_AdminDashBoard.BL_AudioVideoCountDashBoard(objML_AdminDashBoard);
            List<AudioVideo> dataList = new List<AudioVideo>();
            foreach (DataRow dtrow in dt.Rows)
            {
                AudioVideo details = new AudioVideo();
                details.AudioVideoname = dtrow[0].ToString();
                details.AudioVideoTotal = Convert.ToInt32(dtrow[1]);
                dataList.Add(details);
            }
            return dataList;
        }

        public class AudioVideo
        {
            public string AudioVideoname { get; set; }
            public int AudioVideoTotal { get; set; }
        }


        #endregion

        private void BindUserMaster()
        {
            DataTable dt = new DataTable();
            dt = objBL_AdminDashBoard.BL_LatestUserDashBoard(objML_AdminDashBoard);
            if (dt.Rows.Count > 0)
            {
                GrdUserMaster.DataSource = dt;
                GrdUserMaster.DataBind();
            }
        }
        private void BindResgitration()
        {
            DataTable dt = new DataTable();
            dt = objBL_AdminDashBoard.BL_LatestRegDashBoard(objML_AdminDashBoard);
            if (dt.Rows.Count > 0)
            {
                GrdReg.DataSource = dt;
                GrdReg.DataBind();
            }
        }
    }
}