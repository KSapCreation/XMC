using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Admin.Layer.Datalayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;

namespace MvcApplication1.Admin.Layer.Businesslayer
{
    public class BL_SiteDetail
    {
        DL_SiteDetail ObjDL_SiteDetail = new DL_SiteDetail();
        public DataTable BL_OurProgramInfo(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_SliderInfo(objML_SiteDetail);
        }
        public DataTable BL_TestimonialsInfo(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_TestimlonalsInfo(objML_SiteDetail);
        }
        public DataTable BL_OthersInfo(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_OthersInfo(objML_SiteDetail);
        }
        public DataTable BL_AboutCategory(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_AboutCategory(objML_SiteDetail);
        }
        public DataTable BL_BindVideo(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_BindVideo(objML_SiteDetail);
        }
        public DataTable BL_BindPicture(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_BindPicture(objML_SiteDetail);
        }
        public DataTable BL_BindStudyBooks(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_BindStudyBooks(objML_SiteDetail);
        }
        public DataTable BL_BindCategory(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_BindCategry(objML_SiteDetail);
        }
        public DataTable BL_BindBatches(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_BindBatches(objML_SiteDetail);
        }
        public DataTable BL_SearchBatches(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_SearchBatches(objML_SiteDetail);
        }
        public DataTable BL_DLMenu(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_DLMenu(objML_SiteDetail);
        }
        public DataTable BL_ProgramsData(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_AboutCategory(objML_SiteDetail);
        }
        public DataTable BL_BindAchieverList(ML_SiteDetail objML_SiteDetail)
        {
            return ObjDL_SiteDetail.DL_BindAchieverList(objML_SiteDetail);
        }
    }
}