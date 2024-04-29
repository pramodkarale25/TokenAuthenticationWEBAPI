using System.Web.Http;
using TokenAuthenticationWEBAPI.Models;

namespace TokenAuthenticationWEBAPI.Controllers
{
    [MyExceptionFilter]
    public class MyExceptionController : ApiController
    {
        public IHttpActionResult Get(int a)
        {
            int b = 10;
            return Ok(b/a);
        }
    }
}
