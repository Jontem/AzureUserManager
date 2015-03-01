using System;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureUserManager.External
{
    internal class AuthenticationHelper
    {

        /// <summary>
        /// Async task to acquire token for Application.
        /// </summary>
        /// <returns>Async Token for application.</returns>
        private static async Task<string> AcquireTokenAsyncForApplication()
        {
            return GetTokenForApplication();
        }

        /// <summary>
        /// Get Token for Application.
        /// </summary>
        /// <returns>Token for application.</returns>
        private static string GetTokenForApplication()
        {
            var authenticationContext = new AuthenticationContext(Constants.AuthString, false);
            // Config for OAuth client credentials 
            var clientCred = new ClientCredential(Constants.ClientId, Constants.ClientSecret);
            var authenticationResult = authenticationContext.AcquireToken(Constants.ResourceUrl,
                clientCred);
            string token = authenticationResult.AccessToken;
            return token;
        }

        /// <summary>
        /// Get Active Directory Client for Application.
        /// </summary>
        /// <returns>ActiveDirectoryClient for Application.</returns>
        public static ActiveDirectoryClient GetActiveDirectoryClientAsApplication()
        {
            var servicePointUri = new Uri(Constants.ResourceUrl);
            var serviceRoot = new Uri(servicePointUri, Constants.TenantId);
            var activeDirectoryClient = new ActiveDirectoryClient(serviceRoot,
                async () => await AcquireTokenAsyncForApplication());
            return activeDirectoryClient;
        }
    }
}
