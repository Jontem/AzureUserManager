using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;

namespace AzureUserManager.External
{
    public class ActiveDirectoryClientAdapter : IActiveDirectoryClientAdapter
    {
        public IActiveDirectoryClient GetActiveDirectoryClientAsApplication()
        {
            return AuthenticationHelper.GetActiveDirectoryClientAsApplication();
        }
    }
}
