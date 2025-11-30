using Microsoft.EntityFrameworkCore;
using WebsiteBackend.Data;
using WebsiteBackend.Models;

namespace WebsiteBackend.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Member>> GetMembersByTypeAsync(string type)
        {
            return await _context.Members
                .Where(m => m.Type == type)
                .ToListAsync();
        }
    }
}