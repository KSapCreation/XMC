using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;

namespace FBNPC.layers.DataLayers
{
    public class DL_Connection
    {
        public static string GetConnection
        {
            get
            {
                return ConfigurationManager.AppSettings["FBNPC"] ?? "";
            }
        }
    }
}