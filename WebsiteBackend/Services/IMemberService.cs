using WebsiteBackend.Models;

namespace WebsiteBackend.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAllMembersAsync(string? type = null);
        Task<Member?> GetMemberByIdAsync(int id);
    }
}