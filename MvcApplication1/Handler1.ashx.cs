using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MvcApplication1.Admin.Layer.Businesslayer;
using MvcApplication1.Admin.Layer.ModelLayer;
using System.Configuration;
using System.Data.SqlClient;
namespace MvcApplication1
{
  /// <summary>
  /// Image related Code
  /// </summary>
    public class Handler1 : IHttpHandler
    {
        string strcon = ConfigurationManager.AppSettings["FBNPC"].ToString();
        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.QueryString["ImgID"];
            string TestimonialID = context.Request.QueryString["TestimonialID"];
            string AchieverID = context.Request.QueryString["AchieverID"]; 
            SqlConnection connection = new SqlConnection(strcon);
            if (id != null)
            {

                connection.Open();
                SqlCommand command1 = new SqlCommand("select Filedata from FBNPC_Gallery_Master where GalleryID='" + id + "'", connection);
                SqlDataReader dr1 = command1.ExecuteReader();
                dr1.Read();
                context.Response.BinaryWrite((Byte[])dr1[0]);
                connection.Close();
                context.Response.End();
            }
            else if (TestimonialID != null)
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("select Filedata from FBNPC_Programs_Insert where ProgramsID='" + TestimonialID + "'", connection);
                SqlDataReader dr1 = command1.ExecuteReader();
                dr1.Read();
                if (dr1.HasRows)
                {
                    context.Response.BinaryWrite((Byte[])dr1[0]);
                }
                else
                {
                }               
                connection.Close();
                context.Response.End();
            }
            else if (AchieverID != null)
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("select Filedata from KSCN_Achiever_Master where AchieverID='" + AchieverID + "'", connection);
                SqlDataReader dr1 = command1.ExecuteReader();
                dr1.Read();
                if (dr1.HasRows)
                {
                    context.Response.BinaryWrite((Byte[])dr1[0]);
                }
                else
                {
                }
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