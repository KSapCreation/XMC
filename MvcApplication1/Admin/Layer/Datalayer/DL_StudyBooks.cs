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
    public class DL_StudyBooks
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public int DL_InsUpdStudyBooks(ML_StudyBooks objML_StudyBooks)
        {
            SqlParameter[] par ={new SqlParameter("@BookID",objML_StudyBooks.ID),
                                    new SqlParameter("@BookTitle",objML_StudyBooks.BookTitle),                                  
                                    new SqlParameter("@ShortTitle",objML_StudyBooks.ShortDesc),
                                    new SqlParameter("@Desc",objML_StudyBooks.Desc),
                                    new SqlParameter("@isActive",objML_StudyBooks.isactive),
                                    new SqlParameter("@Price",objML_StudyBooks.Price),                                  
                                    new SqlParameter("@CreatedBy",objML_StudyBooks.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_StudyBooks.ModifyBy),
                                      new SqlParameter("@Category",objML_StudyBooks.Category) 
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_StudyBooks_Insert", par);
        }
        public DataTable DL_Bindcategory(ML_StudyBooks objML_StudyBooks)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudyBooks.ID)
                                  
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Category_BindFORStudy", par).Tables[0];
        }
        public DataTable DL_BindStudyBooks(ML_StudyBooks objML_StudyBooks)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudyBooks.ID)
                                  
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Bind_StudyBook", par).Tables[0];
        }
        public DataTable DL_UpdStudyBooks(ML_StudyBooks objML_StudyBooks)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudyBooks.ID)
                                  
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_StudyBook_Edit", par).Tables[0];
        }
        public int DL_DeleteStudyBooks(ML_StudyBooks objML_StudyBooks)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudyBooks.ID),
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_StudyBook_Delete", par);
        }
        public int DL_InsUpdBatches(ML_StudyBooks objML_StudyBooks)
        {
            SqlParameter[] par ={new SqlParameter("@BatchID",objML_StudyBooks.ID),
                                    new SqlParameter("@BatchName",objML_StudyBooks.BatchName),   
                                    new SqlParameter("@BranchName",objML_StudyBooks.BranchName),   
                                    new SqlParameter("@Caurse",objML_StudyBooks.Caurse),
                                    new SqlParameter("@BatchDate",objML_StudyBooks.BatchDate),
                                    new SqlParameter("@StartTime",objML_StudyBooks.StartTime),
                                    new SqlParameter("@EndTime",objML_StudyBooks.EndTime),                                  
                                    new SqlParameter("@isactive",objML_StudyBooks.isactive),
                                    new SqlParameter("@CreatedBy",objML_StudyBooks.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_StudyBooks.ModifyBy)
                                      
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Batches_Insert", par);
        }
        public DataTable DL_BindBatch(ML_StudyBooks objML_StudyBooks)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudyBooks.ID)
                                  
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Bind_Batches", par).Tables[0];
        }
        public int DL_DeleteBatches(ML_StudyBooks objML_StudyBooks)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudyBooks.ID)
                                  
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Batches_Delete", par);
        }
        public DataTable DL_BindBatchesEdit(ML_StudyBooks objML_StudyBooks)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudyBooks.ID)
                                  
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_BindEdit_Batches", par).Tables[0];
        }
    }
}