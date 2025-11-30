using WebsiteBackend.Models;

namespace WebsiteBackend.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<Contact?> GetContactWithAllDetailsAsync();
        Task<IEnumerable<ContactDetail>> GetContactDetailsAsync();
        Task<IEnumerable<SocialLink>> GetSocialLinksAsync();
        Task<JoinUsInfo?> GetJoinUsInfoAsync();
    }
}