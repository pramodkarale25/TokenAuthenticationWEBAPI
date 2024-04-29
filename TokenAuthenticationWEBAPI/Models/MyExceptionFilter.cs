using System.Net.Http;
using System.Web.Http.Filters;

namespace TokenAuthenticationWEBAPI.Models
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            response.Content = new StringContent("An unhandled exception was thrown by service.");

            actionExecutedContext.Response = response;
        }
    }
}