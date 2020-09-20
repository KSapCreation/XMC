using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Admin.Layer.ModelLayer
{
    public class ML_StudyBooks
    {
        public string ID { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public string BookTitle { get; set; }
        public string ShortDesc { get; set; }
        public string Desc { get; set; }
        public string Price { get; set; }
        public string isactive { get; set; }
        public string Category { get; set; }
        public string BranchName { get; set; }
        public string BatchName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string BatchDate { get; set; }
        public string Caurse { get; set; }


    }
}