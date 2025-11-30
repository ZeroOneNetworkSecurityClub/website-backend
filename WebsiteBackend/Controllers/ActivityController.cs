using Microsoft.AspNetCore.Mvc;
using WebsiteBackend.Services;
using WebsiteBackend.Utils;

namespace WebsiteBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllActivities([FromQuery] string? type = null)
        {
            var activities = await _activityService.GetAllActivitiesAsync(type);
            return Ok(ApiResponse<IEnumerable<object>>.SuccessResponse(activities));
        }
        
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestActivities([FromQuery] int limit = 3)
        {
            var activities = await _activityService.GetLatestActivitiesAsync(limit);
            return Ok(ApiResponse<IEnumerable<object>>.SuccessResponse(activities));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null)
            {
                return NotFound(ApiResponse<object>.ErrorResponse("请求的资源不存在"));
            }
            return Ok(ApiResponse<object>.SuccessResponse(activity));
        }
    }
}