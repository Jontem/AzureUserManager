using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.UI;
using AzureUserManager.External;
using AzureUserManager.ViewModel;
using Microsoft.Azure.ActiveDirectory.GraphClient;

namespace AzureUserManager.Business
{
    public class UserStore : IUserStore
    {
        //private const string DefaultDomainName = "ljl.onmicrosoft.com";
        private const string DefaultDomainName = "mourtada.se";
        private readonly IActiveDirectoryClient _activeDirectoryClient;

        public UserStore(IActiveDirectoryClientAdapter activeDirectoryClientAdapter)
        {
            _activeDirectoryClient = activeDirectoryClientAdapter.GetActiveDirectoryClientAsApplication();
        }

        public Task 
            AddUser(IAzureUser azureUser)
        {
            IUser newUser = new User();
            newUser.DisplayName = string.Format("{0} {1}", azureUser.FirstName, azureUser.LastName);
            newUser.UserPrincipalName = string.Format("{0}@{1}", azureUser.UserId, DefaultDomainName);
            newUser.AccountEnabled = true;
            newUser.MailNickname = azureUser.UserId;
            newUser.State = azureUser.HsaId;
            newUser.PasswordProfile = newUser.PasswordProfile = new PasswordProfile
            {
                //Password = "TempP@ssw0rd!",
                Password = "123",
                ForceChangePasswordNextLogin = true
            };

            return _activeDirectoryClient.Users.AddUserAsync(newUser);
        }

        public Task DeleteUser(IAzureUser azureUser)
        {
            throw new NotImplementedException();
        }

        public async Task<IAzureUser> Get(string userId)
        {
            var users = await FindUsers(x => x.UserPrincipalName.Equals(userId, StringComparison.OrdinalIgnoreCase));
            var user = users.FirstOrDefault();

            return (user != null ) ? CreateUserViewModel(user) : null;
        }

        public Task UpdateUser(IAzureUser azureUser)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IAzureUser>> SearchUser(string searchKey)
        {
            var users = GetAllUsers();
            var filteredUsers = users.Where(x => x.UserPrincipalName.Contains(searchKey.ToLower())).ToList();
            return filteredUsers.Select(CreateUserViewModel);
        }

        private async Task<IEnumerable<IUser>> FindUsers(Expression<Func<IUser, bool>> predicate)
        {
            var collection = await _activeDirectoryClient.Users.Where(predicate).ExecuteAsync();
            var users = collection.CurrentPage.ToList();

            return users;
        }

        private IEnumerable<IUser> GetAllUsers()
        {
            var allUsers = Task.Run(async () => await _activeDirectoryClient.Users.ExecuteAsync()).Result.CurrentPage.ToList();
            return allUsers;
        } 

        private IAzureUser CreateUserViewModel(IUser user)
        {
            return new UserViewModel
            {
                AccountEnabled = user.AccountEnabled,
                Email = user.OtherMails.FirstOrDefault(),
                FirstName = user.GivenName,
                LastName = user.Surname,
                HsaId = user.State,
                UserId = user.UserPrincipalName
            };
        }
    }
}