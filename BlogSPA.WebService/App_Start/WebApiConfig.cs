using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace BlogSPA.WebService.App_Start
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			RegisterRoutes(config.Routes);
			ConfigFormatters(config.Formatters);
		}

		private static void ConfigFormatters(MediaTypeFormatterCollection formatters)
		{
			formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
			formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			formatters.Remove(formatters.XmlFormatter);
		}

		private static void RegisterRoutes(HttpRouteCollection httpRouteCollection)
		{
			var route = httpRouteCollection.MapHttpRoute("Default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
		}
	}
}