using Microsoft.AspNetCore.Mvc;
using WebsiteBackend.Services;
using WebsiteBackend.Utils;

namespace WebsiteBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _authService.AuthenticateAsync(request.Username, request.Password);
            
            if (user == null)
            {
                return Unauthorized(ApiResponse<object>.ErrorResponse("用户名或密码错误"));
            }
            
            var token = await _authService.GenerateJwtToken(user);
            
            return Ok(ApiResponse<object>.SuccessResponse(new { token, user }));
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var user = await _authService.RegisterAsync(
                    request.Username,
                    request.Email,
                    request.Password,
                    request.Role ?? "User");
                
                var token = await _authService.GenerateJwtToken(user);
                
                return Ok(ApiResponse<object>.SuccessResponse(new { token, user }));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
        }
    }
    
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}