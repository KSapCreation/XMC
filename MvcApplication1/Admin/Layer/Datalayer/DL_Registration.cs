using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Admin.Layer.ModelLayer;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using FBNPC.layers.DataLayers;
using System.Data.SqlClient;

namespace MvcApplication1.Admin.Layer.Datalayer
{
    public class DL_Registration
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public int DL_InsUpdRegistration(ML_Registration objML_Registration)
        {
            SqlParameter[] par ={new SqlParameter("@RegisterID",objML_Registration.ID),
                                    new SqlParameter("@FirstName",objML_Registration.UserName),                                  
                                    new SqlParameter("@LastName",objML_Registration.LastName),
                                    new SqlParameter("@Address",objML_Registration.Address),
                                    new SqlParameter("@City",objML_Registration.City),
                                    new SqlParameter("@State",objML_Registration.State),
                                    new SqlParameter("@PostalCode",objML_Registration.PostalCode),
                                    new SqlParameter("@PhoneNo",objML_Registration.PhoneNo),
                                    new SqlParameter("@EmailID",objML_Registration.EmailID),
                                    new SqlParameter("@ClassOption",objML_Registration.ClassOption),  
                                    new SqlParameter("@ExamDate",objML_Registration.ExamDate), 
                                    new SqlParameter("@SpecialRequest",objML_Registration.SpecialRequest),
                                    new SqlParameter("@CreatedBy",objML_Registration.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_Registration.ModifyBy)                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Registration_Insert", par);
        }
        public DataTable DL_RegistrationList(ML_Registration objML_Registration)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Registration.ID)
                                                                   
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Register_Bind", par).Tables[0];
        }
        public DataTable DL_SearchList(ML_Registration objML_Registration)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Registration.UserCode)
                                                                   
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_SearchList", par).Tables[0];
        }
        public int DL_DeleteRegistration(ML_Registration objML_Registration)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Registration.ID)                                
                                             
                               };
            return SqlHelper.ExecuteNonQuery(con, "Registration_Delete", par);
        }

    }
}