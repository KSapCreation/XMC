using FBNPC.layers.DataLayers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MvcApplication1.Admin.Layer.ModelLayer;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace MvcApplication1.Admin.Layer.Datalayer
{
    public class DL_Login
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        public int DL_InsUpdUserDetial(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@FirstName",objML_Login.UserName),
                                    new SqlParameter("@LastName",objML_Login.LastName),
                                    new SqlParameter("@Gender",objML_Login.Gender),
                                    new SqlParameter("@DOB",objML_Login.DOB),
                                    new SqlParameter("@Password",objML_Login.Password),
                                    new SqlParameter("@CPwd",objML_Login.CPwd),
                                    new SqlParameter("@EmailID",objML_Login.EmailID),
                                    new SqlParameter("@PhoneNo",objML_Login.PhoneNo),                                                                
                                    new SqlParameter("@CreatedBy",objML_Login.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_Login.ModifyBy),
                                      new SqlParameter("@IPAddress",objML_Login.IPAddress),
                                      new SqlParameter("@ID",objML_Login.ID),
                                      new SqlParameter("@ExamName",objML_Login.ExamName),
                                      new SqlParameter("@Practice",objML_Login.Practice),
                                      new SqlParameter("@AdminGroup",objML_Login.AdminGroup)
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_User_Master_Insert", par);
        }
        public DataTable DL_FindLoginDetail(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Login.UserName),                                    
                                };
            return SqlHelper.ExecuteDataset(con, "FBNPC_LoginDetail_Find", par).Tables[0];

        }
        public DataTable DL_LoginUser(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@UserName",objML_Login.UserName),
                                    new SqlParameter("@Pwd",objML_Login.Password)
                                };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Login", par).Tables[0];

        }
        public DataTable DL_UserList(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Login.ID),
                                    
                                };
            return SqlHelper.ExecuteDataset(con, "FBNPC_User_Master_Bind", par).Tables[0];

        }
        public DataTable DL_ForgetOTP(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Login.ID),
                                    new SqlParameter("@Email",objML_Login.EmailID),
                                };
            return SqlHelper.ExecuteDataset(con, "FBNPC_ForgetPwd_OTP", par).Tables[0];

        }
        public int DL_DeleteUser(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Login.ID)                                 
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_User_Delete", par);
        }
        public DataTable DL_EditUser(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Login.ID)                                 
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_UserMaster_Edit", par).Tables[0];
        }
        public int DL_ChangePassword(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Login.UserName),
                                    new SqlParameter("@Password",objML_Login.Password),                                   
                                      new SqlParameter("@Conform",objML_Login.CPwd)
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Change_Password", par);
        }
        public DataTable DL_ExamList(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Login.ID),
                                    
                                };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Bind_ExamListName", par).Tables[0];

        }
        public DataTable DL_ExamLoginUser(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@UserName",objML_Login.UserName),
                                    new SqlParameter("@Pwd",objML_Login.Password)
                                };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_LoginUser", par).Tables[0];

        }
        public int DL_InsIPAddressHistory(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@IPAddress",objML_Login.IPAddress),
                                    new SqlParameter("@MachineName",objML_Login.MachineName),  
                                    new SqlParameter("@ID",objML_Login.ID),
                                      new SqlParameter("@LoginDate",objML_Login.LoginDate),
                                    
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Login_Current_History", par);
        }
        public int DL_InsertHistory(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@IPAddress",objML_Login.IPAddress),
                                    new SqlParameter("@MachineName",objML_Login.MachineName),  
                                    new SqlParameter("@ID",objML_Login.ID),
                                      new SqlParameter("@LoginDate",objML_Login.LoginDate), 
                                      new SqlParameter("@MacAddress",objML_Login.MacAddress),
                                      new SqlParameter("@UserName",objML_Login.UserCode)
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Maintain_Login_History", par);
        }
        public DataTable DL_ProductValidation(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Login.ID),
                                    
                                };
            return SqlHelper.ExecuteDataset(con, "Licence_Master_Select", par).Tables[0];

        }
        public int DL_ProductkeyInsert(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@Licence_ExpiredDate_Description_A",objML_Login.ProductKey2),
                                    new SqlParameter("@Licence_ExpiredDate_Specification_B",objML_Login.ProductKey1),  
                                    new SqlParameter("@CompanyName",objML_Login.ProductKey1),                                     
                               };
            return SqlHelper.ExecuteNonQuery(con, "Licence_Master_Insert", par);
        }
        public DataTable DL_CheckUser_UsedOrNot(ML_Login objML_Login)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Login.ID)                                 
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_CheckUser_for_furtherUseOrNot", par).Tables[0];
        }

    }
}