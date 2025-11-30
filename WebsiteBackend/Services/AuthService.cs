using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebsiteBackend.Models;
using WebsiteBackend.Repositories;

namespace WebsiteBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        
        public AuthService(IRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        
        public async Task<string> GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var users = await _userRepository.GetAllAsync(u => u.Username == username);
            var user = users.FirstOrDefault();
            
            if (user == null || !VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }
            
            return user;
        }
        
        public async Task<User> RegisterAsync(string username, string email, string password, string role)
        {
            var passwordHash = HashPassword(password);
            
            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                Role = role
            };
            
            return await _userRepository.AddAsync(user);
        }
        
        public bool VerifyPassword(string password, string passwordHash)
        {
            // Simple password verification for demonstration purposes
            // In production, use a secure hashing algorithm like BCrypt
            return passwordHash == HashPassword(password);
        }
        
        public string HashPassword(string password)
        {
            // Simple password hashing for demonstration purposes
            // In production, use a secure hashing algorithm like BCrypt
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(password)));
        }
    }
}