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
using API.Session;
using Repository;
using Facade;
using Newtonsoft.Json;
using Core;
using System.Web;

namespace API.Controllers
{
    [RoutePrefix("api")]
    public class UserController : ApiController
    {
        Repositories repo = new Repositories();
        HttpResponse response;
        ForgotPasswordFacade forgotFacade = new ForgotPasswordFacade();
        
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

        // POST: api/Test;
        public IHttpActionResult UserLogin([FromBody]LoginRequest param)
        {
            ResultStatus rs = new ResultStatus();
            Identity identity = new Identity();
            rs = identity.Login(param);
            if (!rs.IsSuccess())
            {
                return Ok(rs);
            }
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult ForgotPassword([FromBody]string Email)
        {
            ResultStatus rs = new ResultStatus();
            string generatedCode = string.Empty;
            generatedCode = forgotFacade.getGeneratedCode(Email);
            if (repo.User.GetData().Any(x => x.Email.Equals(Email)))
            {
                rs = repo.ForgotPassword.InsertGeneratedCode(Email, generatedCode);
                if (rs.IsSuccess())
                {
                    rs = forgotFacade.SendEmail(repo.User.GetData().Where(x => x.Email.Equals(Email)).FirstOrDefault(), generatedCode);
                }
            }
            if (!rs.IsSuccess())
            {
                return NotFound();
            }
            return Ok();
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
            return Ok();
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
