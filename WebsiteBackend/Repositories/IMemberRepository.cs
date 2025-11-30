using WebsiteBackend.Models;

namespace WebsiteBackend.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        Task<IEnumerable<Member>> GetMembersByTypeAsync(string type);
    }
}