using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Admin.Layer.Datalayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;

namespace MvcApplication1.Admin.Layer.Businesslayer
{
    public class BL_StudentProfile
    {
        DL_StudentProfile objDL_StudentProfile = new DL_StudentProfile();

        public DataTable BL_Result(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_Result(objML_StudentProfile);
        }
        public DataTable BL_BindStudentInfo(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_BindStudentInfo(objML_StudentProfile);
        }
        public int BL_UpdStudentInfo(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_UpdStudentInfo(objML_StudentProfile);
        }
        public DataTable BL_BindStudentExam(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_BindStudentCount(objML_StudentProfile);
        }
        public DataTable BL_BindStudentExamList(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_BindStudentExamList(objML_StudentProfile);
        }
        public DataTable BL_BindStudentScoreBoard(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_BindStudentScoreBoard(objML_StudentProfile);
        }
        public DataTable BL_SerachQuestionInfo(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_SerachQuestionInfo(objML_StudentProfile);
        }
        public DataTable BL_Re_loaderCountExam_StudentTotal(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_Re_loaderCountExam_StudentTotal(objML_StudentProfile);
        }
        public DataTable BL_Re_loaderCountExam_StudentAttempted(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_Re_loaderCountExam_StudentAttempted(objML_StudentProfile);
        }
        public DataTable BL_ReloaderStudentSubmitSelect(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_ReloaderStudentSubmitSelect(objML_StudentProfile);
        }
        public DataTable BL_ReloaderStudentValidationSelect(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_ReloaderStudentValidationSelect(objML_StudentProfile);
        }
        public int BL_InsReloaderStudentSubmitHistory(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_InsReloaderStudentSubmitHistory(objML_StudentProfile);
        }
        public int BL_InsReloaderStudentSubmitDelete(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_InsReloaderStudentSubmitDelete(objML_StudentProfile);
        }
        public int BL_InsReloaderExamValidationHistory(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_InsReloaderExamValidationHistory(objML_StudentProfile);
        }
        public int BL_InsReloaderExamValidationDelete(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_InsReloaderExamValidationDelete(objML_StudentProfile);
        }
        public DataTable BL_BindStudentUpdates(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_BindStudentUpdates(objML_StudentProfile);
        }
        public DataTable BL_BindExamList(ML_StudentProfile objML_StudentProfile)
        {
            return objDL_StudentProfile.DL_BindExamList(objML_StudentProfile);
        }
    }
}