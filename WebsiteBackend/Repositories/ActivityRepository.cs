using Microsoft.EntityFrameworkCore;
using WebsiteBackend.Data;
using WebsiteBackend.Models;

namespace WebsiteBackend.Repositories
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Activity>> GetLatestActivitiesAsync(int limit = 3)
        {
            return await _context.Activities
                .OrderByDescending(a => a.Date)
                .Take(limit)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Activity>> GetActivitiesByTypeAsync(string type)
        {
            return await _context.Activities
                .Where(a => a.Status == type)
                .ToListAsync();
        }
    }
}