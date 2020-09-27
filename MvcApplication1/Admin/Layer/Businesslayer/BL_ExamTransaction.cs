using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Admin.Layer.ModelLayer;
using MvcApplication1.Admin.Layer.Datalayer;
using System.Data;

namespace MvcApplication1.Admin.Layer.Businesslayer
{
    public class BL_ExamTransaction
    {
        DL_ExamTransaction objDL_ExamTransaction = new DL_ExamTransaction();
        public DataTable BL_BindQuestionSheet(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_BindQuestionSheet(objML_ExamTransaction);
        }
        public DataTable BL_BindTearmsCondition(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_BindTearmsCondition(objML_ExamTransaction);
        }
        public DataTable BL_BindSections(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_BindSections(objML_ExamTransaction);
        }
        public DataTable BL_BindExamAudio(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_BindExamAudio(objML_ExamTransaction);
        }
        public DataTable BL_BindExamVideo(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_BindExamVideo(objML_ExamTransaction);
        }
        public DataTable BL_BindExamCompreension(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_BindExamComprehesion(objML_ExamTransaction);
        }
        public DataTable BL_BindCollection(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_BindCollection(objML_ExamTransaction);
        }
        public DataTable BL_BindSpeakingCollection(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_BindSpeakingCollection(objML_ExamTransaction);
        }
        public DataTable BL_BindReadingCollection(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_BindReadingCollection(objML_ExamTransaction);
        }
        public DataTable BL_ShowListening(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_ShowListening(objML_ExamTransaction);
        }
        public DataTable BL_ShowSpeaking(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_ShowSpeaking(objML_ExamTransaction);
        }
        public int BL_InsSubmitExam(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_InsSubmitExam(objML_ExamTransaction);
        }
        public int BL_InsValidateQuestion(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_InsValidateQuestion(objML_ExamTransaction);
        }
        public DataTable BL_ShowReading(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_ShowReading(objML_ExamTransaction);
        }
        public DataTable BL_BindIndividualCollection(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_BindIndividualCollection(objML_ExamTransaction);
        }
        public DataTable BL_ShowIndividualQuestion(ML_ExamTransaction objML_ExamTransaction)
        {
            return objDL_ExamTransaction.DL_ShowIndividualQuestion(objML_ExamTransaction);
        }
    }
}