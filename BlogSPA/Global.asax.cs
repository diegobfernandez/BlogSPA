using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using BlogSPA.App_Start;
using BlogSPA.WebService.App_Start;
using System.Web.Http;
using System.Data.Entity;
using BlogSPA.Data;

namespace BlogSPA
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //BundleTable.EnableOptimizations = true;
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }
    }
}