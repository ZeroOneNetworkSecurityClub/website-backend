using Microsoft.AspNetCore.Mvc;
using WebsiteBackend.Services;
using WebsiteBackend.Utils;

namespace WebsiteBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllMembers([FromQuery] string? type = null)
        {
            var members = await _memberService.GetAllMembersAsync(type);
            return Ok(ApiResponse<IEnumerable<object>>.SuccessResponse(members));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            if (member == null)
            {
                return NotFound(ApiResponse<object>.ErrorResponse("请求的资源不存在"));
            }
            return Ok(ApiResponse<object>.SuccessResponse(member));
        }
    }
}