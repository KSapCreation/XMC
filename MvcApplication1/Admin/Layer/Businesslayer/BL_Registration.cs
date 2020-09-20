using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Admin.Layer.Datalayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Data;

namespace MvcApplication1.Admin.Layer.Businesslayer
{
    public class BL_Registration
    {
        DL_Registration objDL_Registration = new DL_Registration();
        public int BL_InsUpdRegistration(ML_Registration objML_Registration)
        {
            return objDL_Registration.DL_InsUpdRegistration(objML_Registration);
        }
        public DataTable BL_RegistrationList(ML_Registration objML_Registration)
        {
            return objDL_Registration.DL_RegistrationList(objML_Registration);
        }
        public DataTable BL_SearchList(ML_Registration objML_Registration)
        {
            return objDL_Registration.DL_SearchList(objML_Registration);
        }
        public int BL_DeleteRegistration(ML_Registration objML_Registration)
        {
            return objDL_Registration.DL_DeleteRegistration(objML_Registration);
        }

    }
}