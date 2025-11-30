using Microsoft.AspNetCore.Mvc;
using WebsiteBackend.Services;
using WebsiteBackend.Utils;

namespace WebsiteBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetContactWithAllDetails()
        {
            var contact = await _contactService.GetContactWithAllDetailsAsync();
            if (contact == null)
            {
                return Ok(ApiResponse<object>.SuccessResponse(new { }));
            }
            
            return Ok(ApiResponse<object>.SuccessResponse(contact));
        }
        
        [HttpGet("details")]
        public async Task<IActionResult> GetContactDetails()
        {
            var details = await _contactService.GetContactDetailsAsync();
            return Ok(ApiResponse<IEnumerable<object>>.SuccessResponse(details));
        }
        
        [HttpGet("social")]
        public async Task<IActionResult> GetSocialLinks()
        {
            var socialLinks = await _contactService.GetSocialLinksAsync();
            return Ok(ApiResponse<IEnumerable<object>>.SuccessResponse(socialLinks));
        }
        
        [HttpGet("join")]
        public async Task<IActionResult> GetJoinUsInfo()
        {
            var joinUsInfo = await _contactService.GetJoinUsInfoAsync();
            return Ok(ApiResponse<object>.SuccessResponse(joinUsInfo));
        }
    }
}