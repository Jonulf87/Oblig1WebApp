using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Oblig1Vy.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    var exception = Server.GetLastError();
            
        //    if (exception != null)
        //    {
        //        try
        //        {
        //            var logFile = Server.MapPath("~/App_Data/error.log");
        //            var sb = new StringBuilder();

        //            sb.AppendLine($"Timestamp: {DateTime.Now.ToString("yyyy-MM-dd HH:mm")}");
        //            sb.AppendLine($"Error message: {exception.Message}");
        //            sb.AppendLine("Stack trace:");
        //            sb.AppendLine(exception.StackTrace);
        //            sb.AppendLine("--------------------------------------------------------------------------------------------------------------------------");
        //            sb.AppendLine();

        //            File.AppendAllText(logFile, sb.ToString());
        //        }
        //        catch (Exception)
        //        {

        //        }
        //    }

        //    Server.ClearError();

        //    HttpContext.Current.Response.RedirectToRoute("Default", new { Controller = "Home", Action = "Error" });
        //}
    }
}
