using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FBNPC.layers.DataLayers;
using Microsoft.ApplicationBlocks.Data;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;
using System.Data.SqlClient;

namespace MvcApplication1.Admin.Layer.Datalayer
{
    public class DL_ExamTransaction
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public DataTable DL_BindQuestionSheet(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_QuestionSheet", par).Tables[0];
        }
        public DataTable DL_BindTearmsCondition(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Select_TearmsConditions", par).Tables[0];
        }
        public DataTable DL_BindSections(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@SectionID",objML_ExamTransaction.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Bind_Sections", par).Tables[0];
        }
        public DataTable DL_BindExamAudio(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_Audio_Sheet", par).Tables[0];
        }
        public DataTable DL_BindExamVideo(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_Video_Sheet", par).Tables[0];
        }
        public DataTable DL_BindExamComprehesion(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_Comprehension_Sheet", par).Tables[0];
        }
        public DataTable DL_BindCollection(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                 new SqlParameter("@StudentName",objML_ExamTransaction.StudentName)
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_Serial_Wise_Sheet", par).Tables[0];
        }
        public DataTable DL_BindSpeakingCollection(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                    new SqlParameter("@StudentName",objML_ExamTransaction.StudentName)
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_Serial_Wise_Sheet_Video", par).Tables[0];
        }
        public DataTable DL_BindReadingCollection(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                 new SqlParameter("@StudentName",objML_ExamTransaction.StudentName)
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Exam_Reading_Serial_Wise_Sheet", par).Tables[0];
        }
        public DataTable DL_ShowListening(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                    new SqlParameter("@ExamID",objML_ExamTransaction.ExamName)
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Show_Listening_Sheet", par).Tables[0];
        }
        public DataTable DL_ShowSpeaking(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                    new SqlParameter("@ExamID",objML_ExamTransaction.ExamName)
                                 
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Show_Speaking_Sheet_Video", par).Tables[0];
        }
        public int DL_InsSubmitExam(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@OptionA",objML_ExamTransaction.OptionA),
                                    new SqlParameter("@OptionB",objML_ExamTransaction.OptionB),
                                    new SqlParameter("@OptionC",objML_ExamTransaction.OptionC),
                                    new SqlParameter("@OptionD",objML_ExamTransaction.OptionD),
                                    new SqlParameter("@Question",objML_ExamTransaction.Question),
                                    new SqlParameter("@ExamName",objML_ExamTransaction.ExamName),
                                    new SqlParameter("@StudentName",objML_ExamTransaction.StudentName),
                                    new SqlParameter("@PaperID",objML_ExamTransaction.PaperID),
                                    new SqlParameter("@DocType",objML_ExamTransaction.DocType)

                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Submit_Exam_Insert", par);
        }
        public int DL_InsTempSaveExam(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@OptionA",objML_ExamTransaction.OptionA),
                                    new SqlParameter("@OptionB",objML_ExamTransaction.OptionB),
                                    new SqlParameter("@OptionC",objML_ExamTransaction.OptionC),
                                    new SqlParameter("@OptionD",objML_ExamTransaction.OptionD),
                                    new SqlParameter("@Question",objML_ExamTransaction.Question),
                                    new SqlParameter("@ExamName",objML_ExamTransaction.ExamName),
                                    new SqlParameter("@StudentName",objML_ExamTransaction.StudentName),
                                    new SqlParameter("@PaperID",objML_ExamTransaction.PaperID),
                                    new SqlParameter("@DocType",objML_ExamTransaction.DocType),
                                    new SqlParameter("@QusNo",objML_ExamTransaction.QusNo)

                               };
            return SqlHelper.ExecuteNonQuery(con, "KSCN_Temp_Exam_Insert", par);
        }
        public int DL_InsValidateQuestion(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={ new SqlParameter("@ExamName",objML_ExamTransaction.ExamName),
                                    new SqlParameter("@StudentName",objML_ExamTransaction.StudentName),
                                    new SqlParameter("@PaperID",objML_ExamTransaction.PaperID)                                 
                               };
            return SqlHelper.ExecuteNonQuery(con, "FBNPC_Exam_Validation_Insert", par);
        }
        public DataTable DL_ShowReading(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID), 
                                    new SqlParameter("@ExamID",objML_ExamTransaction.ExamName)
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Show_Reading_Sheet_Video", par).Tables[0];
        }
        public DataTable DL_BindIndividualCollection(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                 new SqlParameter("@StudentName",objML_ExamTransaction.StudentName)
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Show_Individual_Sheet", par).Tables[0];
        }
        public DataTable DL_ShowIndividualQuestion(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                    new SqlParameter("@ExamID",objML_ExamTransaction.ExamName)

                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Show_Individual_Sheet_Question", par).Tables[0];
        }
        public DataTable DL_GetSectionTime(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                    new SqlParameter("@ExamID",objML_ExamTransaction.ExamName)

                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_GetSectionWiseTime", par).Tables[0];
        }
        public DataTable DL_CurrentDateTime(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID)
            };
            return SqlHelper.ExecuteDataset(con, "CurrentDateTime", par).Tables[0];
        }
        public DataTable DL_TempIndividualPrevious(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                 new SqlParameter("@StudentName",objML_ExamTransaction.StudentName),
                                 new SqlParameter("@QusNo",objML_ExamTransaction.QusNo)
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Show_Individual_Sheet_Question_Previous", par).Tables[0];
        }
        public DataTable DL_TempIndividualNext(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ExamTransaction.ID),
                                 new SqlParameter("@StudentName",objML_ExamTransaction.StudentName),
                                 new SqlParameter("@QusNo",objML_ExamTransaction.QusNo)
                               };
            return SqlHelper.ExecuteDataset(con, "FBNPC_Show_Individual_Sheet_Question_Next", par).Tables[0];
        }
        public DataTable DL_ShowTempQuestionList(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={new SqlParameter("@ExamID",objML_ExamTransaction.ExamName),
                                    new SqlParameter("@StudentID",objML_ExamTransaction.StudentName)

                               };
            return SqlHelper.ExecuteDataset(con, "KSCN_Temp_To_Orignal_Show", par).Tables[0];
        }
        public int DL_DelTempExamStudent(ML_ExamTransaction objML_ExamTransaction)
        {
            SqlParameter[] par ={ new SqlParameter("@ExamID",objML_ExamTransaction.ExamName),
                                    new SqlParameter("@StudentID",objML_ExamTransaction.StudentName),
                                    new SqlParameter("@PaperID",objML_ExamTransaction.PaperID)
                               };
            return SqlHelper.ExecuteNonQuery(con, "KSCN_Temp_Delete", par);
        }
    }

}