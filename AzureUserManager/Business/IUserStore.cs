using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureUserManager.Business
{
    public interface IUserStore
    {
        Task AddUser(IAzureUser azureUser);
        Task DeleteUser(IAzureUser azureUser);
        Task<IEnumerable<IAzureUser>> GetAll();
        Task<IAzureUser> Get(string userId);
        Task UpdateUser(IAzureUser azureUser);
        Task<IEnumerable<IAzureUser>> SearchUser(string searchKey);
    }
}
