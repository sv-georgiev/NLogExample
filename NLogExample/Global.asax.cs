using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace NLogExample
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //NLog configuration alternative to NLog.config >>>>
            var config = new NLog.Config.LoggingConfiguration();

            FileTarget logfileTarget1 = new NLog.Targets.FileTarget("NLogExample.Model.ClassSon") { FileName = "NLogExample.Model.ClassSon.log" };
            FileTarget logfileTarget2 = new NLog.Targets.FileTarget("NLogExample.Model.ClassDaughter") { FileName = "NLogExample.Model.ClassDaughter.log" };

            //Format the output lines
            logfileTarget1.Layout = new NLog.Layouts.SimpleLayout("${longdate}|${uppercase:${level}}|" +
                "${ callsite:className=true:methodName=true} | ${message} ");
            logfileTarget2.Layout = new NLog.Layouts.SimpleLayout("${longdate}|${uppercase:${level}}|" +
                "${ callsite:className=true:methodName=true} | ${message} ");

            //!!LoggerNamePattern parameter is important to split the log strema into the files depending on the class instance!!
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfileTarget1, "NLogExample.Model.ClassSon");
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfileTarget2, "NLogExample.Model.ClassDaughter");

            NLog.LogManager.Configuration = config;
            //<<<< NLog configuration
        }
    }
}