using WebsiteBackend.Models;

namespace WebsiteBackend.Services
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken(User user);
        Task<User?> AuthenticateAsync(string username, string password);
        Task<User> RegisterAsync(string username, string email, string password, string role);
        bool VerifyPassword(string password, string passwordHash);
        string HashPassword(string password);
    }
}