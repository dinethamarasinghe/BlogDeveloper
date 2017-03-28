using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnzoBlogDeveloper.Service.Controllers
{
    public class SampleServiceController : ApiController
    {
        // GET: api/SampleService
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SampleService/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SampleService
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SampleService/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SampleService/5
        public void Delete(int id)
        {
        }
    }
}
