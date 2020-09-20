using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Admin.Layer.Datalayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;

namespace MvcApplication1.Admin.Layer.Businesslayer
{
    public class BL_StudyBooks
    {
        DL_StudyBooks objDL_StudyBooks = new DL_StudyBooks();
        public int BL_InsUpdStudyBooks(ML_StudyBooks objML_StudyBooks)
        {
            return objDL_StudyBooks.DL_InsUpdStudyBooks(objML_StudyBooks);
        }
        public DataTable BL_BindCategory(ML_StudyBooks objML_StudyBooks)
        {
            return objDL_StudyBooks.DL_Bindcategory(objML_StudyBooks);
        }
        public DataTable BL_BindStudyBooks(ML_StudyBooks objML_StudyBooks)
        {
            return objDL_StudyBooks.DL_BindStudyBooks(objML_StudyBooks);
        }
        public DataTable BL_UpdStudyBooks(ML_StudyBooks objML_StudyBooks)
        {
            return objDL_StudyBooks.DL_UpdStudyBooks(objML_StudyBooks);
        }
        public int BL_DeleteStudyBooks(ML_StudyBooks objML_StudyBooks)
        {
            return objDL_StudyBooks.DL_DeleteStudyBooks(objML_StudyBooks);
        }
        public int BL_InsUpdBatches(ML_StudyBooks objML_StudyBooks)
        {
            return objDL_StudyBooks.DL_InsUpdBatches(objML_StudyBooks);
        }
        public DataTable BL_Bindbatch(ML_StudyBooks objML_StudyBooks)
        {
            return objDL_StudyBooks.DL_BindBatch(objML_StudyBooks);
        }
        public int BL_Deletebatches(ML_StudyBooks objML_StudyBooks)
        {
            return objDL_StudyBooks.DL_DeleteBatches(objML_StudyBooks);
        }
        public DataTable BL_BindBatchesEdit(ML_StudyBooks objML_StudyBooks)
        {
            return objDL_StudyBooks.DL_BindBatchesEdit(objML_StudyBooks);
        }

    }
}