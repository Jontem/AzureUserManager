using AzureUserManager.Business;

namespace AzureUserManager.Tests
{
    public class FakeUser : IAzureUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string HsaId { get; set; }
        public bool? AccountEnabled { get; set; }
        public string MobilePhone { get; set; }
    }
}
