using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // RegisterRoutes(RouteTable.Routes);
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 60;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception objErr = Server.GetLastError().GetBaseException();
            string err = "Error Caught in Application_Error event\n" +
            "Error in: " + Request.Url.ToString() +
            "\nError Message:" + objErr.Message.ToString() +
            "\nStack Trace:" + objErr.StackTrace.ToString();
            EventLog.WriteEntry("Sample_WebApp", err, EventLogEntryType.Error);
            //Server.ClearError();
            //additional actions...
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapPageRoute("index", "index", "~/index.aspx");
            // routes.MapPageRoute("CustomerDetails", "Customers/{CustomerId}", "~/CustomerDetails.aspx");
        }
    }
}