using System.Web.Http;

namespace TokenAuthenticationWEBAPI.Controllers
{
    public class HttpVerbController : ApiController
    {
        //http://localhost:55291/api/HttpVerb
        public IHttpActionResult Get()
        {
            return Ok(new string[] { "value 1", "value 2" });
        }

        //http://localhost:55291/api/HttpVerb?id=1&id1=2
        public IHttpActionResult Get(int id, int id1)
        {
            return Ok(new int[] { id, id1 });
        }

        //http://localhost:55291/api/HttpVerb?id=1&id1=2
        //allowed as fetching these values from query string
        public IHttpActionResult Post(int id, int id1)
        {
            return Ok(new int[] { id, id1 });
        }

        //We can not declare method like this - error as already have method with same parameter
        //public IHttpActionResult Post([FromBody]int id, [FromBody]int id1)
        //{
        //    return Ok(new int[] { id, id1 });
        //}

        //Can't bind multiple parameters ('username' and 'password') to the request's content.
        //runtime error - while calling
        //public IHttpActionResult Post([FromBody]string username, [FromBody] string password)// we can only able to use [FromBody] on single parameter
        //{
        //    return Ok(new string[] { username });
        //}

        //POST call - http://localhost:55291/api/HttpVerb?id=1&id1=8 and inside body we pass username then it is giving preference to above method
        //where public IHttpActionResult Post(int id, int id1)
        //http://localhost:55291/api/HttpVerb?id=1 if we give call like this then runtime error as
        //call gets confused between Post(int id, int id1) & ([FromBody]string username)
        //http://localhost:55291/api/HttpVerb body - raw - "123" - content-type - json
        public IHttpActionResult Post([FromBody]string username)//[FromBody] - Read premitive type from request body
        {
            return Ok(new string[] { username });
        }

        //http://localhost:55291/api/HttpVerb?id=1&name=1235 - Conflicts with above method Post(int id, int id1) where we have 1 or 2 parametrs
        //We have to comment above post methods for this method to work.
        //If our model do not have setter properties then parameter values are not getting bind - getting default values for all members.
        public IHttpActionResult Post([FromUri] User usr)//[FromUri] - Read complex type from url
        {
            return Ok(new { usr.id, usr.name });
        }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
    }
}
