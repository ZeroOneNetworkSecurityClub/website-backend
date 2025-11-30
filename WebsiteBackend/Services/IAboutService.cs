using WebsiteBackend.Models;

namespace WebsiteBackend.Services
{
    public interface IAboutService
    {
        Task<About?> GetAboutWithAllDetailsAsync();
        Task<string> GetBackgroundAsync();
        Task<IEnumerable<string>> GetMissionsAsync();
        Task<IEnumerable<HistoryItem>> GetHistoryAsync();
        Task<IEnumerable<OrganizationItem>> GetOrganizationAsync();
    }
}