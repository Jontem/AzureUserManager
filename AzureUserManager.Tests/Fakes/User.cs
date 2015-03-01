using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.Azure.ActiveDirectory.GraphClient.Extensions;

namespace AzureUserManager.Tests.Fakes
{
    class User : IUser
    {
        public Task UpdateAsync(bool deferredSave = false)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(bool deferredSave = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> CheckMemberGroupsAsync(ICollection<string> groupIds)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetMemberGroupsAsync(bool? securityEnabledOnly)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetMemberObjectsAsync(bool? securityEnabledOnly)
        {
            throw new NotImplementedException();
        }

        public string ObjectType { get; set; }
        public string ObjectId { get; set; }
        public DateTime? DeletionTimestamp { get; set; }
        public IDirectoryObject CreatedOnBehalfOf { get; set; }
        public IPagedCollection<IDirectoryObject> CreatedObjects { get; private set; }
        public IDirectoryObject Manager { get; set; }
        public IPagedCollection<IDirectoryObject> DirectReports { get; private set; }
        public IPagedCollection<IDirectoryObject> Members { get; private set; }
        public IPagedCollection<IDirectoryObject> MemberOf { get; private set; }
        public IPagedCollection<IDirectoryObject> Owners { get; private set; }
        public IPagedCollection<IDirectoryObject> OwnedObjects { get; private set; }
        public Task<IUser> AssignLicenseAsync(ICollection<AssignedLicense> addLicenses, ICollection<Guid> removeLicenses)
        {
            throw new NotImplementedException();
        }

        public bool? AccountEnabled { get; set; }
        public IList<LogonIdentifier> AlternativeSignInNamesInfo { get; private set; }
        public IList<AssignedLicense> AssignedLicenses { get; private set; }
        public IList<AssignedPlan> AssignedPlans { get; private set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CreationType { get; set; }
        public string Department { get; set; }
        public bool? DirSyncEnabled { get; set; }
        public string DisplayName { get; set; }
        public string FacsimileTelephoneNumber { get; set; }
        public string GivenName { get; set; }
        public string ImmutableId { get; set; }
        public string JobTitle { get; set; }
        public DateTime? LastDirSyncTime { get; set; }
        public string Mail { get; set; }
        public string MailNickname { get; set; }
        public string Mobile { get; set; }
        public string OnPremisesSecurityIdentifier { get; set; }
        public IList<string> OtherMails { get; private set; }
        public string PasswordPolicies { get; set; }
        public PasswordProfile PasswordProfile { get; set; }
        public string PhysicalDeliveryOfficeName { get; set; }
        public string PostalCode { get; set; }
        public string PreferredLanguage { get; set; }
        public IList<ProvisionedPlan> ProvisionedPlans { get; private set; }
        public IList<ProvisioningError> ProvisioningErrors { get; private set; }
        public IList<string> ProxyAddresses { get; private set; }
        public string SipProxyAddress { get; set; }
        public string State { get; set; }
        public string StreetAddress { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }
        public IStreamFetcher ThumbnailPhoto { get; private set; }
        public string UsageLocation { get; set; }
        public string UserPrincipalName { get; set; }
        public string UserType { get; set; }
        public IPagedCollection<IAppRoleAssignment> AppRoleAssignments { get; private set; }
        public IPagedCollection<IOAuth2PermissionGrant> Oauth2PermissionGrants { get; private set; }
        public IPagedCollection<IDirectoryObject> OwnedDevices { get; private set; }
        public IPagedCollection<IDirectoryObject> RegisteredDevices { get; private set; }
    }
}
