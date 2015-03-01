using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AzureUserManager.Business;
using AzureUserManager.ViewModel;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Ninject.Infrastructure.Language;

namespace AzureUserManager.Controllers
{
    public class UserApiController : ApiController
    {
        private readonly IUserStore _userStore;

        public UserApiController(IUserStore userStore)
        {
            _userStore = userStore;
        }

        // GET
        [HttpGet]
        public async Task<IHttpActionResult> Find(string searchKey)
        {
            List<UserViewModel> users;

            try
            {
                var res = await _userStore.SearchUser(searchKey);
                users = res.Cast<UserViewModel>().ToList();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok(users);
        }

        // GET
        [ActionName("Default")]
        public async Task<IHttpActionResult> Get(string userId)
        {
            IAzureUser user;

            try
            {
                user = await _userStore.Get(userId);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            
            if (user == null)
            {
                return NotFound();
            }

            return Ok((UserViewModel)user);
        }

        // POST
        [ActionName("Default")]
        public IHttpActionResult Post([FromBody]UserViewModel azureUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Missing required fields");
            }

            try
            {
                _userStore.AddUser(azureUser);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok();
        }

        // PUT
        [ActionName("Default")]
        public async Task<IHttpActionResult> Put([FromBody]UserViewModel azureUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Missing required fields");
            }

            IAzureUser user;
            try
            {
                user = await _userStore.Get(azureUser.UserId);
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                _userStore.UpdateUser(azureUser);
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }

            return Ok();
        }

        // DELETE
        [ActionName("Default")]
        public async Task<IHttpActionResult> Delete([FromBody]IAzureUser azureUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Missing Required fields");
            }

            IAzureUser userFromStore;
            try
            {
                userFromStore = await _userStore.Get(azureUser.UserId);
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }

            if (userFromStore == null)
            {
                return NotFound();
            }

            try
            {
                _userStore.DeleteUser(userFromStore);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok();
        }
    }
}