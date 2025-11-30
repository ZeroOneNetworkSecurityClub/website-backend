using WebsiteBackend.Models;

namespace WebsiteBackend.Repositories
{
    public interface IAboutRepository : IRepository<About>
    {
        Task<About?> GetAboutWithAllDetailsAsync();
        Task<string> GetBackgroundAsync();
        Task<IEnumerable<Mission>> GetMissionsAsync();
        Task<IEnumerable<HistoryItem>> GetHistoryAsync();
        Task<IEnumerable<OrganizationItem>> GetOrganizationAsync();
    }
}