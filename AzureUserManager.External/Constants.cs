using System.Configuration;

namespace AzureUserManager.External
{
    internal class Constants
    {
        public static readonly string TenantName = ConfigurationManager.AppSettings["TenantName"];
        public static readonly string TenantId = ConfigurationManager.AppSettings["TenantId"];
        public static readonly string ClientId = ConfigurationManager.AppSettings["ClientId"];
        public static readonly string ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];

        public static readonly string AuthString = "https://login.windows.net/" + TenantName;
        public const string ResourceUrl = "https://graph.windows.net";
    }
}
