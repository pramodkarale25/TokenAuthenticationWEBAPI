using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TokenAuthenticationWEBAPI.Controllers
{
    public class ReturnTypeController : ApiController
    {
        [HttpGet]
        public void GetVoid(int id)
        {
            
        }

        [HttpGet]
        public int GetPrimitive(int id)
        {
            return id;
        }

        [HttpGet]
        public User GetComplex(int id)
        {
            return new User();

        }

        [HttpGet]
        public HttpResponseMessage GetHttpResponseMessage(int id)
        {
            switch (id)
            {
                case 1:
                    return Request.CreateResponse(HttpStatusCode.Accepted, id);

                case 2:
                    return Request.CreateResponse(HttpStatusCode.Ambiguous, id);

                case 3:
                    return Request.CreateResponse(HttpStatusCode.BadGateway, id);

                case 4:
                    return Request.CreateResponse(HttpStatusCode.BadRequest, id);

                case 5:
                    return Request.CreateResponse(HttpStatusCode.Conflict, id);

                case 6:
                    return Request.CreateResponse(HttpStatusCode.Continue, id);

                case 7:
                    return Request.CreateResponse(HttpStatusCode.Created, id);

                case 8:
                    return Request.CreateResponse(HttpStatusCode.ExpectationFailed, id);

                case 9:
                    return Request.CreateResponse(HttpStatusCode.Forbidden, id);

                case 10:
                    return Request.CreateResponse(HttpStatusCode.Found, id);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpGet]
        public IHttpActionResult GetIHttpActionResult(int id)
        {
            return Ok(new User());
        }

    }
}
