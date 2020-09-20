using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Admin.Layer.ModelLayer
{
    public class ML_ExamMaster
    {
        public string ID { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public string SectionName { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public string Question { get; set; }
        public string OPtionOne { get; set; }
        public string OptionTwo { get; set; }
        public string OptionThree { get; set; }
        public string OptionFour { get; set; }
        public string CorrectAns { get; set; }
        public string TransType { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
        public string TearmsConditions { get; set; }
        public string StudentName { get; set; }        





    }
}