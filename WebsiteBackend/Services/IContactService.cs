using WebsiteBackend.Models;

namespace WebsiteBackend.Services
{
    public interface IContactService
    {
        Task<Contact?> GetContactWithAllDetailsAsync();
        Task<IEnumerable<ContactDetail>> GetContactDetailsAsync();
        Task<IEnumerable<SocialLink>> GetSocialLinksAsync();
        Task<JoinUsInfo?> GetJoinUsInfoAsync();
    }
}