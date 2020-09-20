using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Configuration;
using System.Data.SqlClient;

namespace MvcApplication1.Exam
{
    /// <summary>
    /// Summary description for File
    /// </summary>
    public class File : IHttpHandler
    {
        string strcon = ConfigurationManager.AppSettings["FBNPC"].ToString();

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            //int id = int.Parse(context.Request.QueryString["id"]);

            SqlConnection connection = new SqlConnection(strcon);
            if (id != null)
            {
             
                connection.Open();
                SqlCommand command1 = new SqlCommand("select top 1 filedata,FileType,FileName from FBNPC_PAPER_SET_DETAIL left outer join FBNPC_AUDIO_VIDEO_MASTER on FBNPC_AUDIO_VIDEO_MASTER.AVID=FBNPC_PAPER_SET_DETAIL.AVID left outer join FBNPC_Sections on FBNPC_Sections.SectionID=FBNPC_PAPER_SET_DETAIL.section where FBNPC_PAPER_SET_DETAIL.AVID='" + id + "'", connection);
                SqlDataReader dr1 = command1.ExecuteReader();
                dr1.Read();
                context.Response.BinaryWrite((Byte[])dr1[0]);
                connection.Close();
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}