using FBNPC.layers.DataLayers;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MvcApplication1.Admin.Layer.ModelLayer;

namespace MvcApplication1.Admin.Layer.Datalayer
{
    public class DL_SiteDetail
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public DataTable DL_SliderInfo(ML_SiteDetail objML_SiteDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_SiteDetail.ID)                        
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_OurPrograms", par).Tables[0];
        }
        public DataTable DL_TestimlonalsInfo(ML_SiteDetail objML_SiteDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_SiteDetail.ID)                        
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Testimonials", par).Tables[0];
        }
        public DataTable DL_OthersInfo(ML_SiteDetail objML_SiteDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_SiteDetail.ID)                        
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_OurPrograms_All", par).Tables[0];
        }
        public DataTable DL_AboutCategory(ML_SiteDetail objML_SiteDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_SiteDetail.ID)                        
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Company_Bind", par).Tables[0];
        }
        public DataTable DL_BindVideo(ML_SiteDetail objML_SiteDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_SiteDetail.ID)                        
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Video_Bind", par).Tables[0];
        }
        public DataTable DL_BindPicture(ML_SiteDetail objML_SiteDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_SiteDetail.ID)                        
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Picture_Bind", par).Tables[0];
        }
        public DataTable DL_BindStudyBooks(ML_SiteDetail objML_SiteDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_SiteDetail.ID)                        
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_StudyBooks_Web", par).Tables[0];
        }
        public DataTable DL_BindCategry(ML_SiteDetail objML_SiteDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_SiteDetail.ID)                        
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Category_BindFORStudy", par).Tables[0];
        }
        public DataTable DL_BindBatches(ML_SiteDetail objML_SiteDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_SiteDetail.ID)                        
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Bind_Batches_Web", par).Tables[0];
        }
        public DataTable DL_SearchBatches(ML_SiteDetail objML_SiteDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_SiteDetail.ID)                        
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_BindEdit_Batches", par).Tables[0];
        }
        public DataTable DL_DLMenu(ML_SiteDetail objML_SiteDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_SiteDetail.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_OurPrograms_Bind", par).Tables[0];
        }
       
    }
}