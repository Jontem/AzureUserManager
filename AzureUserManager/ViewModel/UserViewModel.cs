using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureUserManager.Business;

namespace AzureUserManager.ViewModel
{
    public class UserViewModel : IAzureUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string HsaId { get; set; }
        public bool? AccountEnabled { get; set; }
        public string Password { get; set; }
    }
}