using FBNPC.layers.DataLayers;
using Microsoft.ApplicationBlocks.Data;
using MvcApplication1.Admin.Layer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication1.Admin.Layer.Datalayer
{
    public class DL_Default
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        public DataTable DL_SlidersData(ML_Default objML_Default)
        {
            return SqlHelper.ExecuteDataset(con, "FBNPC_Sliders_Info").Tables[0];
        }
        public DataTable DL_ProgramsData(ML_Default objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.SliderCode),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_OurPrograms_Bind",par).Tables[0];
        }
        public DataTable DL_TestimonialsData(ML_Default objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.SliderCode),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Testimonials_Bind", par).Tables[0];
        }
        public DataTable DL_OthersData(ML_Default objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.SliderCode),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_OthersData_Bind", par).Tables[0];
        }
        public DataTable DL_ShowSingleProgramsData(ML_Default objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_OurPrograms_Detail", par).Tables[0];
        }
        public DataTable DL_DLMenu(ML_Default objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.SliderCode),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_OurPrograms_Bind", par).Tables[0];
        }
    }
}