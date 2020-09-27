using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FBNPC.layers.DataLayers;
using Microsoft.ApplicationBlocks.Data;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;

namespace MvcApplication1.Admin.Layer.Datalayer
{
    public class DL_ExamMaster
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        public int DL_InsSubject(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@SubjectID",objML_ExamMaster.ID),
                                    new SqlParameter("@SubjectName",objML_ExamMaster.SubjectName),
                                    new SqlParameter("@SubjectDesc",objML_ExamMaster.Description),                                                                                            
                                    new SqlParameter("@CreatedBy",objML_ExamMaster.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_ExamMaster.ModifyBy)                                 
                                      
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Subjects_Insert", par);
        }
        public int DL_InsSection(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@SectionID",objML_ExamMaster.ID),
                                    new SqlParameter("@SectionName",objML_ExamMaster.SectionName),
                                    new SqlParameter("@SectionDesc",objML_ExamMaster.Description),
                                    new SqlParameter("@CreatedBy",objML_ExamMaster.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_ExamMaster.ModifyBy),                      new SqlParameter("@DocType",objML_ExamMaster.DocType)


                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Sections_Insert", par);
        }
        public DataTable DL_BindSubject(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@SubjectID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Bind_Subjects", par).Tables[0];
        }
        public DataTable DL_EditSubject(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@SubjectID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Edit_Subjects", par).Tables[0];
        }
        public int DL_DeleteSubject(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@SubjectID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Delete_Subjects", par);
        }
        public DataTable DL_BindSection(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@SectionID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Bind_Sections", par).Tables[0];
        }
        public DataTable DL_EditSection(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@SectionID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Edit_Sections", par).Tables[0];
        }
        public int DL_DeleteSection(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@SectionID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Delete_Sections", par);
        }
        public int DL_InsUpdQuestion(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@QuesionID",objML_ExamMaster.ID),
                                    new SqlParameter("@Question",objML_ExamMaster.Question),
                                    new SqlParameter("@OptionA",objML_ExamMaster.OPtionOne),                                                                                      
                                    new SqlParameter("@OptionB",objML_ExamMaster.OptionTwo),                                                                                      
                                    new SqlParameter("@OptionC",objML_ExamMaster.OptionThree),                                                                                
                                    new SqlParameter("@OptionD",objML_ExamMaster.OptionFour),    
                                    new SqlParameter("@CorrectAns",objML_ExamMaster.CorrectAns),                                                  
                                    new SqlParameter("@CreatedBy",objML_ExamMaster.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_ExamMaster.ModifyBy)                           
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Questions_Insert", par);
        }
        public DataTable DL_EditQuestion(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@QustionID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Edit_Questions", par).Tables[0];
        }
        public int DL_DeleteQuestion(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@QuestionID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Delete_QuestionSheet", par);
        }
        public DataTable DL_BindQuestion(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Bind_QuestionSheet", par).Tables[0];
        }
        public int DL_InsUpdAV(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@AVID",objML_ExamMaster.ID),
                                    new SqlParameter("@SubjectName",objML_ExamMaster.SubjectName),
                                    new SqlParameter("@TransType",objML_ExamMaster.TransType),                                                                                    
                                    new SqlParameter("@FileName",objML_ExamMaster.FileName),                                                                                
                                    new SqlParameter("@FileData",objML_ExamMaster.FileData), 
                                    new SqlParameter("@FileType",objML_ExamMaster.FileType),                                                                                    
                                    new SqlParameter("@CreatedBy",objML_ExamMaster.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_ExamMaster.ModifyBy)                           
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Audio_Video_Insert", par);
        }
        public DataTable DL_EditAVMaster(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Edit_Audio_Video_Master", par).Tables[0];
        }
        public int DL_DeleteAVMaster(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Delete_Audio_Video_Master", par);
        }
        public DataTable DL_BindAVMaster(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Bind_Audio_Video_Master", par).Tables[0];
        }
        public DataTable DL_BindExamListName(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ExamID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Bind_ExamListName", par).Tables[0];
        }
        public int DL_InsExamListName(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ExamID",objML_ExamMaster.ID),
                                    new SqlParameter("@ExamName",objML_ExamMaster.SectionName),
                                    new SqlParameter("@ExamDesc",objML_ExamMaster.Description),                                                                                   
                                    new SqlParameter("@CreatedBy",objML_ExamMaster.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_ExamMaster.ModifyBy)                               
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_ExamListName_Insert", par);
        }
        public int DL_DeleteExamListName(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ExamID",objML_ExamMaster.ID),
                                 
                               };
                return SqlHelper.ExecuteNonQuery(con, "FBNPC_Delete_ExamListName", par);
          
        }
        public DataTable DL_EditExamListName(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ExamID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Edit_ExamListName", par).Tables[0];
        }
        public int DL_InsTeramsCondition(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@TearmsID",objML_ExamMaster.ID),
                                    new SqlParameter("@TeramsCondition",objML_ExamMaster.TearmsConditions),                                                                                   
                                    new SqlParameter("@CreatedBy",objML_ExamMaster.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_ExamMaster.ModifyBy)                                 
                                      
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_TearmsCondition_Insert", par);
        }
        public DataTable DL_BindTearms(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Select_TearmsConditions", par).Tables[0];
        }
        public DataTable DL_BindVideoMaster(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Bind_Video", par).Tables[0];
        }
        public int DL_InsUpdVideoMaster(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                      new SqlParameter("@SubjectName",objML_ExamMaster.SubjectName),
                                    new SqlParameter("@TransType",objML_ExamMaster.TransType),                                                                                    
                                    new SqlParameter("@FileName",objML_ExamMaster.Description),        
                                  new SqlParameter("@CreatedBy",objML_ExamMaster.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_ExamMaster.ModifyBy)
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Video_Insert", par);
        }
        public DataTable DL_EditVideoMaster(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Edit_Video", par).Tables[0];
        }
        public int DL_DeleteVideoMaster(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Delete_Video", par);
        }
        public DataTable DL_SearchQuestion(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Search_Questions", par).Tables[0];
        }
        public DataTable DL_SelectStudentMapping(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ExamID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Student_Mapping_Select", par).Tables[0];
        }
        public DataTable DL_BindUserMaster(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_User_Master_Bind", par).Tables[0];
        }
        public int DL_InsUpdates(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@UpdatesID",objML_ExamMaster.ID),
                                    new SqlParameter("@StudentName",objML_ExamMaster.StudentName),
                                    new SqlParameter("@Desc",objML_ExamMaster.Description),                                                                                                                                new SqlParameter("@CreatedBy",objML_ExamMaster.CreatedBy),
                                      new SqlParameter("@ModifyBy",objML_ExamMaster.ModifyBy)                             
                                                                          
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Updates_Insert", par);
        }
        public DataTable DL_BindUpdates(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Updates_Bind", par).Tables[0];
        }
        public int DL_DeleteUpdates(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Updates_Delete", par);
        }
        public DataTable DL_EditUpdates(ML_ExamMaster objML_ExamMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamMaster.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Updates_Select", par).Tables[0];
        }
    }
}