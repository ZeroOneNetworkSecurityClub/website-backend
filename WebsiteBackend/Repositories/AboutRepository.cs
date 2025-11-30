using Microsoft.EntityFrameworkCore;
using WebsiteBackend.Data;
using WebsiteBackend.Models;

namespace WebsiteBackend.Repositories
{
    public class AboutRepository : Repository<About>, IAboutRepository
    {
        public AboutRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<About?> GetAboutWithAllDetailsAsync()
        {
            return await _context.About
                .Include(a => a.Missions)
                .Include(a => a.History)
                .Include(a => a.Organization)
                .FirstOrDefaultAsync();
        }
        
        public async Task<string> GetBackgroundAsync()
        {
            var about = await _context.About.FirstOrDefaultAsync();
            return about?.Background ?? string.Empty;
        }
        
        public async Task<IEnumerable<Mission>> GetMissionsAsync()
        {
            var about = await _context.About.Include(a => a.Missions).FirstOrDefaultAsync();
            return about?.Missions ?? Enumerable.Empty<Mission>();
        }
        
        public async Task<IEnumerable<HistoryItem>> GetHistoryAsync()
        {
            var about = await _context.About.Include(a => a.History).FirstOrDefaultAsync();
            return about?.History ?? Enumerable.Empty<HistoryItem>();
        }
        
        public async Task<IEnumerable<OrganizationItem>> GetOrganizationAsync()
        {
            var about = await _context.About.Include(a => a.Organization).FirstOrDefaultAsync();
            return about?.Organization ?? Enumerable.Empty<OrganizationItem>();
        }
    }
}