using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using FBNPC.layers.DataLayers;
using Microsoft.ApplicationBlocks.Data;
using MvcApplication1.Admin.Layer.ModelLayer;
namespace MvcApplication1.Admin.Layer.Datalayer
{
    public class DL_StudentProfile
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public DataTable DL_Result(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),                                   
                                 //new SqlParameter("@ExamName",objML_StudentProfile.ExamName)   
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Results",par).Tables[0];
        }
        public DataTable DL_BindStudentInfo(ML_StudentProfile objML_StudentProfile)
        {
            
                SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),                                   
                                    
                               };
                return SqlHelper.ExecuteDataset(con, "FBNPC_UserMaster_Edit", par).Tables[0];
            
            
        }
        public int DL_UpdStudentInfo(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),
                                    new SqlParameter("@EmailID",objML_StudentProfile.EmailID),
                                    new SqlParameter("@PhoneNo",objML_StudentProfile.PhoneNo),
                                    new SqlParameter("@ModifyBy",objML_StudentProfile.ModifyBy)
                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_User_Update", par);
        }
        public DataTable DL_BindStudentCount(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_Student_Mapping_Count", par).Tables[0];
        }
        public DataTable DL_BindStudentExamList(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_Student_Mapping_Select", par).Tables[0];
        }

        public DataTable DL_BindStudentExamListIndividual(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),

                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_Student_Mapping_Select_Individual", par).Tables[0];
        }
        public DataTable DL_BindStudentScoreBoard(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Student_DashboardScore_Board", par).Tables[0];
        }
        public DataTable DL_SerachQuestionInfo(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),  
                                    new SqlParameter("@StudentName",objML_StudentProfile.StudentName),
                                    new SqlParameter("@ExamName",objML_StudentProfile.ExamName),
                                    new SqlParameter("@DocType",objML_StudentProfile.doctype)

                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Student_Search_Questions", par).Tables[0];
        }
        public DataTable DL_Re_loaderCountExam_StudentTotal(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),
                                    new SqlParameter("@ExamName",objML_StudentProfile.ExamName),                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Re_loader_CountExam_Student_Total", par).Tables[0];
        }
        public DataTable DL_Re_loaderCountExam_StudentAttempted(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),
                                    new SqlParameter("@ExamName",objML_StudentProfile.ExamName),                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Re_loader_CountExam_Student_Attempted", par).Tables[0];
        }
        public DataTable DL_ReloaderStudentSubmitSelect(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.StudentName),
                                    new SqlParameter("@ExamName",objML_StudentProfile.ExamName),                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Re_loader_Submit_Select", par).Tables[0];
        }
        public DataTable DL_ReloaderStudentValidationSelect(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.StudentName),
                                    new SqlParameter("@ExamName",objML_StudentProfile.ExamName),                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Re_loader_Validation_Select", par).Tables[0];
        }
        public int DL_InsReloaderStudentSubmitHistory(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@hist_By",objML_StudentProfile.Hist_By),
                                    new SqlParameter("@Hist_Version",objML_StudentProfile.HIst_Version),
                                    new SqlParameter("@OptionA",objML_StudentProfile.OPtionA),
                                    new SqlParameter("@OptionB",objML_StudentProfile.OPtionB),
                                    new SqlParameter("@OptionC",objML_StudentProfile.OPtionC),
                                    new SqlParameter("@OptionD",objML_StudentProfile.OPtionD),
                                    new SqlParameter("@QuestionID",objML_StudentProfile.QuestionID),
                                    new SqlParameter("@ExamName",objML_StudentProfile.ExamName),
                                    new SqlParameter("@StudentName",objML_StudentProfile.StudentName),
                                    new SqlParameter("@PaperID",objML_StudentProfile.PaperID),                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Submit_Exam_History_Insert", par);
        }
        public int DL_InsReloaderExamValidationHistory(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@hist_By",objML_StudentProfile.Hist_By),
                                    new SqlParameter("@Hist_Version",objML_StudentProfile.HIst_Version),
                                    new SqlParameter("@ExamName",objML_StudentProfile.ExamName),
                                    new SqlParameter("@StudentName",objML_StudentProfile.StudentName),
                                    new SqlParameter("@PaperID",objML_StudentProfile.PaperID),                                    
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Exam_Validation_History_Insert", par);
        }
        public int DL_InsReloaderStudentSubmitDelete(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.StudentName),
                                    new SqlParameter("@ExamName",objML_StudentProfile.ExamName),
                                                                      
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Submit_Exam_History_Delete", par);
        }
        public int DL_InsReloaderExamValidationDelete(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.StudentName),
                                    new SqlParameter("@ExamName",objML_StudentProfile.ExamName),
                                                                      
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Exam_Validation_History_Delete", par);
        }
        public DataTable DL_BindStudentUpdates(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Students_Updates_Bind", par).Tables[0];
        }
        public DataTable DL_BindExamList(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),                                   
                                    
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_Student_Mapping_Select", par).Tables[0];
        }
        public DataTable DL_BindStudentScoreBoardIndividual(ML_StudentProfile objML_StudentProfile)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_StudentProfile.ID),

                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Student_DashboardScore_Board_Individual", par).Tables[0];
        }
    }
}