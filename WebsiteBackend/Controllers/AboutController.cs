using Microsoft.AspNetCore.Mvc;
using WebsiteBackend.Services;
using WebsiteBackend.Utils;

namespace WebsiteBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAboutWithAllDetails()
        {
            var about = await _aboutService.GetAboutWithAllDetailsAsync();
            if (about == null)
            {
                return Ok(ApiResponse<object>.SuccessResponse(new { }));
            }
            
            var response = new
            {
                background = about.Background,
                missions = about.Missions.Select(m => m.Content),
                history = about.History,
                organization = about.Organization
            };
            
            return Ok(ApiResponse<object>.SuccessResponse(response));
        }
        
        [HttpGet("background")]
        public async Task<IActionResult> GetBackground()
        {
            var background = await _aboutService.GetBackgroundAsync();
            return Ok(ApiResponse<string>.SuccessResponse(background));
        }
        
        [HttpGet("mission")]
        public async Task<IActionResult> GetMissions()
        {
            var missions = await _aboutService.GetMissionsAsync();
            return Ok(ApiResponse<IEnumerable<string>>.SuccessResponse(missions));
        }
        
        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var history = await _aboutService.GetHistoryAsync();
            return Ok(ApiResponse<IEnumerable<object>>.SuccessResponse(history));
        }
        
        [HttpGet("organization")]
        public async Task<IActionResult> GetOrganization()
        {
            var organization = await _aboutService.GetOrganizationAsync();
            return Ok(ApiResponse<IEnumerable<object>>.SuccessResponse(organization));
        }
    }
}