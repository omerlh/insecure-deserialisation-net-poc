using System;
using System.Web.Http;
using DeserializationPOC.Models;

namespace DeserializationPOC.Controllers
{
    [RoutePrefix("api/v1/hello")]
    public class HelloController : ApiController
    {
        [HttpGet]
        public String Get()
        {
            return "Hello";
        }

        [HttpPost]
        public void Post(HelloModel body)
        {
            Console.WriteLine(body.Body);
        }
    }
}
