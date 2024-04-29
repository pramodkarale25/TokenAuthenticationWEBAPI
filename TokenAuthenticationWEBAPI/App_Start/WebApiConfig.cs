using System.Web.Http;
using TokenAuthenticationWEBAPI.Models;

namespace TokenAuthenticationWEBAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.Filters.Add(new CacheFilter(100));// enable caching for application level
            //config.Filters.Add(new AuthorizeAttribute());// enable owin token based authentication across application
            //config.Filters.Add(new ExceptionFilter());//enable exception handling at app level
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
