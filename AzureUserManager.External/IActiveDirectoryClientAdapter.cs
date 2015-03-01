using System.Collections.Generic;
using Microsoft.Azure.ActiveDirectory.GraphClient;

namespace AzureUserManager.External
{
    public interface IActiveDirectoryClientAdapter
    {
        IActiveDirectoryClient GetActiveDirectoryClientAsApplication();
    }
}
