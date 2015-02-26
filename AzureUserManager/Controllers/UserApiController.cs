using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AzureUserManager.Business;

namespace AzureUserManager.Controllers
{
    public class UserApiController : ApiController
    {
        private readonly IUserStore _userStore;

        public UserApiController(IUserStore userStore)
        {
            _userStore = userStore;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(string userId)
        {
            var user = _userStore.Get(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]AzureUser azureUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Missing required fields");
            }

            var user = new User
            {
                FirstName = azureUser.FirstName,
                LastName = azureUser.LastName,
                Email = azureUser.Email,
                UserId = azureUser.UserId,
                HsaId = azureUser.HsaId,
            };

            try
            {
                _userStore.AddUser(user);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put([FromBody]AzureUser azureUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Missing required fields");
            }

            return Ok();
        }

        // DELETE api/<controller>/5
        public void Delete([FromBody]AzureUser azureUser)
        {
        }
    }
}