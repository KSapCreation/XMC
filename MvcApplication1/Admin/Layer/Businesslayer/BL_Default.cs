using MvcApplication1.Admin.Layer.Datalayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcApplication1.Admin.Layer.Businesslayer
{
    public class BL_Default
    {
        DL_Default objDL_Default = new DL_Default();

        public DataTable BL_SlidersData(ML_Default objML_Default)
        {
            return objDL_Default.DL_SlidersData(objML_Default);
        }
        public DataTable BL_ProgramsData(ML_Default objML_Default)
        {
            return objDL_Default.DL_ProgramsData(objML_Default);
        }
        public DataTable BL_TestimonialsData(ML_Default objML_Default)
        {
            return objDL_Default.DL_TestimonialsData(objML_Default);
        }
        public DataTable BL_OtherData(ML_Default objML_Default)
        {
            return objDL_Default.DL_OthersData(objML_Default);
        }
        public DataTable BL_ShowSingleProgramsData(ML_Default objML_Default)
        {
            return objDL_Default.DL_ShowSingleProgramsData(objML_Default);
        }
        public DataTable BL_DLMenu(ML_Default objML_Default)
        {
            return objDL_Default.DL_DLMenu(objML_Default);
        }
        
    }
}