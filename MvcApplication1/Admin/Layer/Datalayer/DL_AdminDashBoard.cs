using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using FBNPC.layers.DataLayers;
using Microsoft.ApplicationBlocks.Data;
using MvcApplication1.Admin.Layer.ModelLayer;

namespace MvcApplication1.Admin.Layer.Datalayer
{
    public class DL_AdminDashBoard
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public DataTable DL_ExamListDashBoard(ML_AdminDashBoard objML_AdminDashBoard)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_AdminDashBoard.ID)
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exams_Count_Question_Dashboard",par).Tables[0];
        }
        public DataTable DL_LatestUserDashBoard(ML_AdminDashBoard objML_AdminDashBoard)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_AdminDashBoard.ID)
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_User_list_Dashboard", par).Tables[0];
        }
        public DataTable DL_RegistrationExamProvideDashBoard(ML_AdminDashBoard objML_AdminDashBoard)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_AdminDashBoard.ID)
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Registrations_Exam_Dashboard", par).Tables[0];
        }
        public DataTable DL_LatestRegDashBoard(ML_AdminDashBoard objML_AdminDashBoard)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_AdminDashBoard.ID)
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Registration_list_Dashboard", par).Tables[0];
        }
        public DataTable DL_AudioVideoCountDashBoard(ML_AdminDashBoard objML_AdminDashBoard)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_AdminDashBoard.ID)
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_No_Of_Audio_Video_Dashboard", par).Tables[0];
        }
    }
}