using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using TokenAuthenticationWEBAPI.Models;

namespace TokenAuthenticationInWebAPI.Controllers
{
    public class TokenAuthenticationController : ApiController
    {
        //This resource is For all types of role
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        [Route("api/resource1")]
        public IHttpActionResult GetResource1()
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello: " + identity.Name);
        }

        //This resource is only For Admin and SuperAdmin role
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet]
        [Route("api/resource2")]
        public IHttpActionResult GetResource2()
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var Email = identity.Claims
                      .FirstOrDefault(c => c.Type == "Email").Value;

            var UserName = identity.Name;

            return Ok("Hello " + UserName + ", Your Email ID is :" + Email);
        }

        //This resource is only For SuperAdmin role
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        [Route("api/resource3")]
        public IHttpActionResult GetResource3()
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + "Your Role(s) are: " + string.Join(",", roles.ToList()));
        }

        [HttpGet]
        public IHttpActionResult GetAllEmployee()
        {
            UsersBL bl = new UsersBL();
            return Ok(bl.GetUsers());
        }
    }
}