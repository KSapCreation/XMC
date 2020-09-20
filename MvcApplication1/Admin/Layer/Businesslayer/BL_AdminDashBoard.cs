using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Admin.Layer.ModelLayer;
using MvcApplication1.Admin.Layer.Datalayer;
using System.Data;

namespace MvcApplication1.Admin.Layer.Businesslayer
{
    public class BL_AdminDashBoard
    {
        DL_AdminDashBoard objDL_AdminDashBoard = new DL_AdminDashBoard();
        public DataTable BL_ExamListDashBoard(ML_AdminDashBoard objML_AdminDashBoard)
        {
            return objDL_AdminDashBoard.DL_ExamListDashBoard(objML_AdminDashBoard);
        }
        public DataTable BL_RegstraionExamProvideDashBoard(ML_AdminDashBoard objML_AdminDashBoard)
        {
            return objDL_AdminDashBoard.DL_RegistrationExamProvideDashBoard(objML_AdminDashBoard);
        }
        public DataTable BL_LatestUserDashBoard(ML_AdminDashBoard objML_AdminDashBoard)
        {
            return objDL_AdminDashBoard.DL_LatestUserDashBoard(objML_AdminDashBoard);
        }
        public DataTable BL_LatestRegDashBoard(ML_AdminDashBoard objML_AdminDashBoard)
        {
            return objDL_AdminDashBoard.DL_LatestRegDashBoard(objML_AdminDashBoard);
        }
        public DataTable BL_AudioVideoCountDashBoard(ML_AdminDashBoard objML_AdminDashBoard)
        {
            return objDL_AdminDashBoard.DL_AudioVideoCountDashBoard(objML_AdminDashBoard);
        }
    }

}