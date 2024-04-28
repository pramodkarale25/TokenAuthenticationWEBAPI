using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using TokenAuthenticationWEBAPI.Models;

namespace TokenAuthenticationWEBAPI.Controllers
{
    public class CachingController : ApiController
    {
        [AllowAnonymous]
        [Route("GetData")]
        //[CacheFilter(time:100)]// apply caching on action method when constructor is available
        [CacheFilter(TimeDuration = 100)]// apply caching on action method when constructor is not available
        public IHttpActionResult getData()
        {
            Dictionary<object, object> obj = new Dictionary<object, object>();
            obj.Add("1", "Punjab");
            obj.Add("2", "Assam");
            obj.Add("3", "UP");
            obj.Add("4", "AP");
            obj.Add("5", "J&K");
            obj.Add("6", "Odisha");
            obj.Add("7", "Delhi");
            obj.Add("9", "Karnataka");
            obj.Add("10", "Bangalore");
            obj.Add("21", "Rajesthan");
            obj.Add("31", "Jharkhand");
            obj.Add("41", "chennai");
            obj.Add("51", "jammu");
            obj.Add("61", "Bhubaneshwar");
            obj.Add("71", "Delhi");
            obj.Add("19", "Karnataka");
            return Ok(obj);
        }

    }
}
