using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBContext.Model;
using DBContext;
using API.Models;
using Repository;
using Newtonsoft.Json;

namespace API.Controllers
{
    [RoutePrefix("api")]
    public class TestController : ApiController
    {
        Repositories repo = new Repositories();
        
        // GET: api/Test
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        [HttpPost]
        public IHttpActionResult CobaPost([FromBody]TestingRequest param)
        {
            List<Person> human = new List<Person>();
            human = repo.Test.GetData().ToList();
            if (human == null)
            {
                return NotFound();
            }
            return Ok(human);
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
