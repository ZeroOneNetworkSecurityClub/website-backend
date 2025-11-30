using WebsiteBackend.Models;

namespace WebsiteBackend.Services
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetAllActivitiesAsync(string? type = null);
        Task<IEnumerable<Activity>> GetLatestActivitiesAsync(int limit = 3);
        Task<Activity?> GetActivityByIdAsync(int id);
    }
}