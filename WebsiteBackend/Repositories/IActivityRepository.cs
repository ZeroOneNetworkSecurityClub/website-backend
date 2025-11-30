using WebsiteBackend.Models;

namespace WebsiteBackend.Repositories
{
    public interface IActivityRepository : IRepository<Activity>
    {
        Task<IEnumerable<Activity>> GetLatestActivitiesAsync(int limit = 3);
        Task<IEnumerable<Activity>> GetActivitiesByTypeAsync(string type);
    }
}