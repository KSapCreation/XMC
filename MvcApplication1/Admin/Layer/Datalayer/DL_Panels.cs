using FBNPC.layers.DataLayers;
using Microsoft.ApplicationBlocks.Data;
using MvcApplication1.Admin.Layer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace MvcApplication1.Admin.Layer.Datalayer
{
    public class DL_Panels
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        public int DL_InsUpdUserDetial(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@SliderCode",objML_Panels.SliderCode),
                                    new SqlParameter("@SliderTitle",objML_Panels.SliderTitle),
                                    new SqlParameter("@Sliderdesc",objML_Panels.Sliderdesc),
                                    new SqlParameter("@CreatedBy",objML_Panels.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_Panels.ModifyBy)
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Sliders_Insert", par);
        }

        public DataTable DL_SliderInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Sliders_Bind", par).Tables[0];
        }
        public DataTable DL_UpdateOtherInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_OurPrograms_Detail", par).Tables[0];
        }
        public DataTable DL_UpdateCompanyBindInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Company_Detail", par).Tables[0];
        }
        public int DL_InsProgramsInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@Title",objML_Panels.Title),
                                    new SqlParameter("@Desc",objML_Panels.Desc),
                                    new SqlParameter("@ISActive",objML_Panels.ISActive),
                                    new SqlParameter("@PicType",objML_Panels.PicType),
                                    new SqlParameter("@PicData",objML_Panels.PicData),
                                    new SqlParameter("@PicName",objML_Panels.PicName),                                    
                                    new SqlParameter("@CreatedBy",objML_Panels.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_Panels.ModifyBy),
                                      new SqlParameter("@DocType",objML_Panels.DocType),
                                      new SqlParameter("@ID",objML_Panels.ID),
                                      new SqlParameter("@ImageID",objML_Panels.ImageID),
                                      new SqlParameter("@Country",objML_Panels.CountryID),
                                      new SqlParameter("@State",objML_Panels.StateID),
                                      new SqlParameter("@City",objML_Panels.CityID),
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Our_Programs_Insert", par);
        }
        public int DL_InsUpdCompanyAbout(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@CompanyName",objML_Panels.CompanyName),
                                    new SqlParameter("@Desc",objML_Panels.CompanyDesc),
                                    new SqlParameter("@ID",objML_Panels.ID),
                                    new SqlParameter("@Category",objML_Panels.Category),
                                    new SqlParameter("@ModifyBy",objML_Panels.ModifyBy),
                                    new SqlParameter("@CreatedBy",objML_Panels.CreatedBy)
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Company_Insert", par);
        }
       
        public int DL_DeleteOtherInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),
                                                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Programs_Delete", par);
        }
        public int DL_DeleteCompanyInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),
                                                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Company_Delete", par);
        }
        public DataTable DL_ProgramsInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_OurPrograms_All", par).Tables[0];
        }
        public DataTable DL_AboutInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Company_Bind", par).Tables[0];
        }
        public int DL_InsGalleryInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@GalleryID",objML_Panels.ID),
                                    new SqlParameter("@CompanyName",objML_Panels.CompanyName),
                                    new SqlParameter("@category",objML_Panels.Category),
                                    new SqlParameter("@GalleryType",objML_Panels.GalleryType),
                                    new SqlParameter("@Name",objML_Panels.CompanyDesc),
                                    new SqlParameter("@VideoLink",objML_Panels.Link),
                                    new SqlParameter("@Desc",objML_Panels.Desc),                                    
                                    new SqlParameter("@CreatedBy",objML_Panels.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_Panels.ModifyBy),
                                      new SqlParameter("@ISActive",objML_Panels.ISActive)                                      
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Gallery_Insert", par);
        }
        public int DL_InsGalleryImageInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@GalleryID",objML_Panels.ID),
                                    new SqlParameter("@CompanyName",objML_Panels.CompanyName),
                                    new SqlParameter("@category",objML_Panels.Category),
                                    new SqlParameter("@GalleryType",objML_Panels.GalleryType),
                                    new SqlParameter("@Name",objML_Panels.CompanyDesc),
                                    new SqlParameter("@Desc",objML_Panels.Desc),                                                       
                                      new SqlParameter("@FileName",objML_Panels.PicName),
                                      new SqlParameter("@FileType",objML_Panels.PicType),
                                      new SqlParameter("@FileData",objML_Panels.PicData),
                                         new SqlParameter("@CreatedBy",objML_Panels.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_Panels.ModifyBy),
                                      new SqlParameter("@ISActive",objML_Panels.ISActive),
                                      new SqlParameter("@ImageID",objML_Panels.ImageID)
                                                                          
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_GalleryImage_Insert", par);
        }
        public int DL_InsCategoryInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@CategoryID",objML_Panels.ID),
                                    new SqlParameter("@CategoryName",objML_Panels.Category),                                 
                                    new SqlParameter("@ISActive",objML_Panels.ISActive),  
                                       new SqlParameter("@Desc",objML_Panels.Desc),                            
                                    new SqlParameter("@CreatedBy",objML_Panels.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_Panels.ModifyBy),                                    
                                      new SqlParameter("@DocTypes",objML_Panels.DocTypes)                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Category_Insert", par);
        }
        public DataTable DL_GalleryInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Gallery_Bind", par).Tables[0];
        }
        public DataTable DL_CategoryBind(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Category_Bind", par).Tables[0];
        }
        public int DL_DeleteVideoImage(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),
                                                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_VideoAndPicture_Delete", par);
        }
        public DataTable DL_UpdateGalleryInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_GalleryUpdate_Bind", par).Tables[0];
        }
        public int DL_DeleteCategory(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),
                                                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Category_Delete", par);
        }
        public DataTable DL_CategoryEdit(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Category_Edit", par).Tables[0];
        }
        public int DL_InsUpdComprehension(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ReadingID",objML_Panels.ReadingID),
                                    new SqlParameter("@ComprehensionName",objML_Panels.ComprehensionName),                                 
                                    new SqlParameter("@ComprehensionDesc",objML_Panels.ComprehensionDesc),  
                                    new SqlParameter("@CreatedBy",objML_Panels.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_Panels.ModifyBy)                                                                  
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Comprehension_Insert", par);
        }
        public DataTable DL_EditComprehension(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Comprehension_Edit", par).Tables[0];
        }
        public int DL_DeleteComprehension(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),
                                                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Comprehension_Delete", par);
        }
        public DataTable DL_BindComprehension(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Comprehension_Select", par).Tables[0];
        }
        public DataTable DL_BindAchieverList(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID)
                               };
            return SqlHelper.ExecuteDataset(con, "KSCN_Achiever_Bind", par).Tables[0];
        }
        public int DL_InsCountryInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@CountryID",objML_Panels.ID),
                                    new SqlParameter("@Name",objML_Panels.Desc)                                  
                               };
            return SqlHelper.ExecuteNonQuery(con, "KSCN_Country_Insert", par);
        }
        public int DL_DeleteCountry(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),

                               };
            return SqlHelper.ExecuteNonQuery(con, "KSCN_Country_Delete", par);
        }
        public DataTable DL_CountryEdit(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),

                               };
            return SqlHelper.ExecuteDataset(con, "KSCN_Country_Select", par).Tables[0];
        }
        public DataTable DL_CountryBind(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),

                               };
            return SqlHelper.ExecuteDataset(con, "KSCN_Country_Bind", par).Tables[0];
        }

        public int DL_InsStateInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@CountryID",objML_Panels.CountryID),
                                    new SqlParameter("@Name",objML_Panels.Desc),
                                    new SqlParameter("@StateID",objML_Panels.ID),
                               };
            return SqlHelper.ExecuteNonQuery(con, "KSCN_State_Insert", par);
        }
        public int DL_DeleteState(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),

                               };
            return SqlHelper.ExecuteNonQuery(con, "KSCN_State_Delete", par);
        }
        public DataTable DL_StateEdit(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),

                               };
            return SqlHelper.ExecuteDataset(con, "KSCN_State_Select", par).Tables[0];
        }
        public DataTable DL_StateBind(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),

                               };
            return SqlHelper.ExecuteDataset(con, "KSCN_State_Bind", par).Tables[0];
        }

        public DataTable DL_StateCountryBind(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),
                               };
            return SqlHelper.ExecuteDataset(con, "KSCN_State_Country_Wise", par).Tables[0];
        }

        public DataTable DL_CityStateBind(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),
                               };
            return SqlHelper.ExecuteDataset(con, "KSCN_City_State_Wise", par).Tables[0];
        }

        public int DL_InsCityInfo(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@CityID",objML_Panels.ID),                                    
                                    new SqlParameter("@CountryID",objML_Panels.CountryID),
                                    new SqlParameter("@Name",objML_Panels.Desc),
                                    new SqlParameter("@StateID",objML_Panels.StateID)
                               };
            return SqlHelper.ExecuteNonQuery(con, "KSCN_City_Insert", par);
        }
        public int DL_DeleteCity(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),

                               };
            return SqlHelper.ExecuteNonQuery(con, "KSCN_City_Delete", par);
        }
        public DataTable DL_CityEdit(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),

                               };
            return SqlHelper.ExecuteDataset(con, "KSCN_City_Select", par).Tables[0];
        }
        public DataTable DL_CityBind(ML_Panels objML_Panels)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Panels.ID),

                               };
            return SqlHelper.ExecuteDataset(con, "KSCN_City_Bind", par).Tables[0];
        }
    }
}