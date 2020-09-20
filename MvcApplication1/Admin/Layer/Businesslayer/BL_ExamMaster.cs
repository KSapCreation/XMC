using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Admin.Layer.ModelLayer;
using MvcApplication1.Admin.Layer.Datalayer;
using System.Data;

namespace MvcApplication1.Admin.Layer.Businesslayer
{
    public class BL_ExamMaster
    {
        DL_ExamMaster objDL_ExamMaster = new DL_ExamMaster();

        public int BL_InsSubject(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_InsSubject(objML_ExamMaster);
        }
        public int BL_InsSection(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_InsSection(objML_ExamMaster);
        }
        public DataTable BL_BindSubject(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_BindSubject(objML_ExamMaster);
        }
        public DataTable BL_EditSubject(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_EditSubject(objML_ExamMaster);
        }
        public int BL_DeleteSubject(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_DeleteSubject(objML_ExamMaster);
        }
        public DataTable BL_BindSection(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_BindSection(objML_ExamMaster);
        }
        public DataTable BL_EditSection(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_EditSection(objML_ExamMaster);
        }
        public int BL_DeleteSection(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_DeleteSection(objML_ExamMaster);
        }
        public int BL_DeleteExamListName(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_DeleteExamListName(objML_ExamMaster);
        }
        public int BL_InsUpdQuestion(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_InsUpdQuestion(objML_ExamMaster);
        }
        public DataTable BL_EditQuestion(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_EditQuestion(objML_ExamMaster);
        }
        public int BL_DeleteQuestion(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_DeleteQuestion(objML_ExamMaster);
        }
        public DataTable BL_BindQuestion(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_BindQuestion(objML_ExamMaster);
        }
        public int BL_InsUpdAV(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_InsUpdAV(objML_ExamMaster);
        }
        public DataTable BL_EditAVMaster(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_EditAVMaster(objML_ExamMaster);
        }
        public int BL_DeleteAVMaster(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_DeleteAVMaster(objML_ExamMaster);
        }
        public DataTable BL_BindAVMaster(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_BindAVMaster(objML_ExamMaster);
        }
      
        public DataTable BL_BindExamListName(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_BindExamListName(objML_ExamMaster);
        }
        public int BL_InsExamListName(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_InsExamListName(objML_ExamMaster);
        }
        public DataTable BL_EditExamListName(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_EditExamListName(objML_ExamMaster);
        }
        public int BL_InsTeramsCondition(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_InsTeramsCondition(objML_ExamMaster);
        }
        public DataTable BL_BindTearms(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_BindTearms(objML_ExamMaster);
        }
        public DataTable BL_BindVideoMaster(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_BindVideoMaster(objML_ExamMaster);
        }
        public int BL_InsUpdVideoMaster(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_InsUpdVideoMaster(objML_ExamMaster);
        }
        public DataTable BL_EditVideoMaster(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_EditVideoMaster(objML_ExamMaster);
        }
        public int BL_DeleteVideoMaster(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_DeleteVideoMaster(objML_ExamMaster);
        }
        public DataTable BL_SerachQuestion(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_SearchQuestion(objML_ExamMaster);
        }
        public DataTable BL_SelectStudentMaping(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_SelectStudentMapping(objML_ExamMaster);
        }
        public DataTable BL_BindUserMaster(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_BindUserMaster(objML_ExamMaster);
        }
        public int BL_InsUpdates(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_InsUpdates(objML_ExamMaster);
        }
        public DataTable BL_BindUpdates(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_BindUpdates(objML_ExamMaster);
        }
        public int BL_DeleteUpdates(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_DeleteUpdates(objML_ExamMaster);
        }
        public DataTable BL_EditUpdates(ML_ExamMaster objML_ExamMaster)
        {
            return objDL_ExamMaster.DL_EditUpdates(objML_ExamMaster);
        }
    }
}