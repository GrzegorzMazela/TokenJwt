using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenJwt.Dto;

namespace TokenJwt.Api.Controllers
{
    [Authorize]
    public class ValuesController : Controller
    {
        public List<UserTxtDto> UserTxts { get; set; }

        protected string CurrentUserId
        {
            get
            {
                var currentUser = HttpContext.User;
                var userId = currentUser.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
                return userId;
            }
        }

        public ValuesController()
        {
            UserTxts = new List<UserTxtDto>();
            UserTxts.Add(new UserTxtDto
            {
                Text = "Test user 2",
                UserId = "2",
                UserTxtId = "1",
            });
            UserTxts.Add(new UserTxtDto
            {
                Text = "Test user 1",
                UserId = "1",
                UserTxtId = "2",
            });
        }

        [HttpGet]
        [Route("api/txt")]
        public UserTxtDto GetTxt()
        {
            var test = UserTxts.FirstOrDefault(x => x.UserId == CurrentUserId);
            return test;
        }

        // GET api/values
        [HttpGet]
        [Route("api/values")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Route("api/values/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("api/values")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [Route("api/values/{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("api/values/{id}")]
        public void Delete(int id)
        {
        }
    }
}
