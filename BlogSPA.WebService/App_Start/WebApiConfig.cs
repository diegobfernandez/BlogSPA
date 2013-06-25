using System.Web.Http;

namespace BlogSPA.WebService.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RegisterRoutes(config.Routes);
        }

        private static void RegisterRoutes(HttpRouteCollection httpRouteCollection)
        {
            var route = httpRouteCollection.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}