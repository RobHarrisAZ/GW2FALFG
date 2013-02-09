using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http.Validation.Providers;
using GW2FALFG.Web.Data;
using System.Data.Entity.Migrations;

namespace GW2FALFG.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;
            var config = (CustomErrorsSection)
                ConfigurationManager.GetSection("system.web/customErrors");

            IncludeErrorDetailPolicy errorDetailPolicy;

            switch (config.Mode)
            {
                case CustomErrorsMode.RemoteOnly:
                    errorDetailPolicy
                        = IncludeErrorDetailPolicy.LocalOnly;
                    break;
                case CustomErrorsMode.On:
                    errorDetailPolicy
                        = IncludeErrorDetailPolicy.Never;
                    break;
                case CustomErrorsMode.Off:
                    errorDetailPolicy
                        = IncludeErrorDetailPolicy.Always;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = errorDetailPolicy;

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.Services.RemoveAll(
                typeof(System.Web.Http.Validation.ModelValidatorProvider),
                v => v is InvalidModelValidatorProvider);
            Database.SetInitializer(new GroupRequestContextInitializer());
            //new DbMigrator(new GroupContextConfiguration()); //migrations
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Get the error details
            var lastErrorWrapper = Server.GetLastError() as HttpException;

            if (lastErrorWrapper != null && lastErrorWrapper.GetHttpCode() == 404)
            {
                Response.Redirect("404.html");
            }
            else
            {
                Response.Redirect("500.html");
            }
        }
    }
}