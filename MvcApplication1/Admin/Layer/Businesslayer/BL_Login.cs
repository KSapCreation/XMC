using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Admin.Layer.Datalayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;

namespace MvcApplication1.Admin.Layer.Businesslayer
{
    public class BL_Login
    {
        DL_Login objDL_Login = new DL_Login();

        public int BL_InsUpdUserDetail(ML_Login objML_Login)
        {
            return objDL_Login.DL_InsUpdUserDetial(objML_Login);
        }
        public DataTable BL_FindLoginDetail(ML_Login objML_Login)
        {
            return objDL_Login.DL_FindLoginDetail(objML_Login);
        }
        public DataTable BL_LoginUser(ML_Login objML_Login)
        {
            return objDL_Login.DL_LoginUser(objML_Login);
        }
        public DataTable BL_UserList(ML_Login objML_Login)
        {
            return objDL_Login.DL_UserList(objML_Login);
        }
        public int BL_DeleteUser(ML_Login objML_Login)
        {
            return objDL_Login.DL_DeleteUser(objML_Login);
        }
        public DataTable BL_EditUser(ML_Login objML_Login)
        {
            return objDL_Login.DL_EditUser(objML_Login);
        }
        public DataTable BL_ForgetOTP(ML_Login objML_Login)
        {
            return objDL_Login.DL_ForgetOTP(objML_Login);
        }
        public int BL_ChangePassword(ML_Login objML_Login)
        {
            return objDL_Login.DL_ChangePassword(objML_Login);
        }
        public DataTable BL_BindExamList(ML_Login objML_Login)
        {
            return objDL_Login.DL_ExamList(objML_Login);
        }
        public DataTable BL_ExamLoginUser(ML_Login objML_Login)
        {
            return objDL_Login.DL_ExamLoginUser(objML_Login);
        }
        public int BL_InsIPAddressHistory(ML_Login objML_Login)
        {
            return objDL_Login.DL_InsIPAddressHistory(objML_Login);
        }
        public int BL_InsertHistory(ML_Login objML_Login)
        {
            return objDL_Login.DL_InsertHistory(objML_Login);
        }
        public DataTable BL_ProductValidation(ML_Login objML_Login)
        {
            return objDL_Login.DL_ProductValidation(objML_Login);
        }
        public int BL_ProductKeyInsert(ML_Login objML_Login)
        {
            return objDL_Login.DL_ProductkeyInsert(objML_Login);
        }
        public DataTable BL_ChecUser_UsedOrNot(ML_Login objML_Login)
        {
            return objDL_Login.DL_CheckUser_UsedOrNot(objML_Login);
        }
    }
}