namespace AzureUserManager.Business
{
    public interface IAzureUser
    {
        string FirstName { get; set; }
        
        string LastName { get; set; }

        string UserId { get; set; }
        
        string Email { get; set; }

        string HsaId { get; set; }

        bool? AccountEnabled { get; set; }

        string MobilePhone { get; set; }
    }
}