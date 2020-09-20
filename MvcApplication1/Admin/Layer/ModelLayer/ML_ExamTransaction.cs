using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Admin.Layer.ModelLayer
{
    public class ML_ExamTransaction
    {
        public string ID { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string ExamName { get; set; }
        public string StudentName { get; set; }
        public string PaperID { get; set; }

    }
}