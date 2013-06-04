using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using BlogSPA.App_Start;

namespace BlogSPA
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }
    }
}