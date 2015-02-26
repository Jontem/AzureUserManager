using System.Collections.Generic;

namespace AzureUserManager.Business
{
    public interface IUserStore
    {
        void AddUser(AzureUser azureUser);
        void DeleteUser(AzureUser azureUser);
        AzureUser Get(string userId);
        void UpdateUser(AzureUser azureUser);
        IEnumerable<AzureUser> SearchUser(string searchKey);
    }
}
