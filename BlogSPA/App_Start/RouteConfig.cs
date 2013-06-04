using System.Web.Routing;

namespace BlogSPA.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new Route("", new PageRouteHandler("~/Home.aspx")));
        }
    }
}