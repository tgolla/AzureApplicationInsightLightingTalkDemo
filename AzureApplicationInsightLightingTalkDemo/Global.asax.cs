using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AzureApplicationInsightLightingTalkDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var nHibernateProfilerActive = ConfigurationManager.AppSettings["NHibernateProfilerActive"];

            if (!string.IsNullOrWhiteSpace(nHibernateProfilerActive))
            {
                if (nHibernateProfilerActive.Equals("true"))
                    HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            }

            var instrumentationKey = ConfigurationManager.AppSettings["ApplicationInsightsInstrumentationKey"];

            if (string.IsNullOrWhiteSpace(instrumentationKey))
                TelemetryConfiguration.Active.DisableTelemetry = true;
            else
                TelemetryConfiguration.Active.InstrumentationKey = instrumentationKey;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
