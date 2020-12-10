using MvcApplication1.Admin.Layer.Datalayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MvcApplication1.Admin.Layer.Businesslayer
{
    public class BL_Panels
    {
        DL_Panels objDL_Panels = new DL_Panels();

        public int BL_InsSlidersInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_InsUpdUserDetial(objML_Panels);
        }
        public DataTable BL_SlidersInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_SliderInfo(objML_Panels);
        }
        public int BL_InsProgramsInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_InsProgramsInfo(objML_Panels);
        }
       
        public DataTable BL_ProgramsInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_ProgramsInfo(objML_Panels);
        }
        public int BL_DeleteOtherInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_DeleteOtherInfo(objML_Panels);
        }
        public DataTable BL_UpdateInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_UpdateOtherInfo(objML_Panels);
        }
        public DataTable BL_UpdateCompanyBind(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_UpdateCompanyBindInfo(objML_Panels);
        }
        public int BL_InsUpdCompanyAbout(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_InsUpdCompanyAbout(objML_Panels);
        }
        public DataTable BL_AboutInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_AboutInfo(objML_Panels);
        }
        public int BL_DeleteCompanyInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_DeleteCompanyInfo(objML_Panels);
        }
        public int BL_InsGalleryInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_InsGalleryInfo(objML_Panels);
        }
        public int BL_InsGalleryImageInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_InsGalleryImageInfo(objML_Panels);
        }
        public DataTable BL_GalleryInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_GalleryInfo(objML_Panels);
        }
        public int BL_InsCategoryInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_InsCategoryInfo(objML_Panels);
        }
        public DataTable BL_CategoryBind(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_CategoryBind(objML_Panels);
        }
        public int BL_DeleteVideoImage(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_DeleteVideoImage(objML_Panels);
        }
        public DataTable BL_UpdateGalleryInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_UpdateGalleryInfo(objML_Panels);
        }
        public int BL_DeleteCategory(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_DeleteCategory(objML_Panels);
        }
        public DataTable BL_CategoryEdit(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_CategoryEdit(objML_Panels);
        }
        public int BL_InsUpdComprehension(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_InsUpdComprehension(objML_Panels);
        }
        public DataTable BL_EditComprehension(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_EditComprehension(objML_Panels);
        }
        public int BL_DeleteComprehension(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_DeleteComprehension(objML_Panels);
        }
        public DataTable BL_BindComprehension(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_BindComprehension(objML_Panels);
        }
        public DataTable BL_BindAchieverList(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_BindAchieverList(objML_Panels);
        }
        public int BL_InsCountryInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_InsCountryInfo(objML_Panels);
        }
        public int BL_DeleteCountry(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_DeleteCountry(objML_Panels);
        }
        public DataTable BL_CountryEdit(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_CountryEdit(objML_Panels);
        }
        public DataTable BL_CountryBind(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_CountryBind(objML_Panels);
        }

        public int BL_InsStateInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_InsStateInfo(objML_Panels);
        }
        public int BL_DeleteState(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_DeleteState(objML_Panels);
        }
        public DataTable BL_StateEdit(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_StateEdit(objML_Panels);
        }
        public DataTable BL_StateBind(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_StateBind(objML_Panels);
        }

        public DataTable BL_StateCountryWiseBind(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_StateCountryBind(objML_Panels);
        }

        public DataTable BL_CityStateWiseBind(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_CityStateBind(objML_Panels);
        }

        public int BL_InsCityInfo(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_InsCityInfo(objML_Panels);
        }
        public int BL_DeleteCity(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_DeleteCity(objML_Panels);
        }
        public DataTable BL_CityEdit(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_CityEdit(objML_Panels);
        }
        public DataTable BL_CityBind(ML_Panels objML_Panels)
        {
            return objDL_Panels.DL_CityBind(objML_Panels);
        }
    }
}