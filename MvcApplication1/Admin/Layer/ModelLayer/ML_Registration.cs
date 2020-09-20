using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Admin.Layer.ModelLayer
{
    public class ML_Registration
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string EmailID { get; set; }
        public string PhoneNo { get; set; }
        public string SpecialRequest { get; set; }
        public string ExamDate { get; set; }
        public string ClassOption { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }

    }
}