using Microsoft.AspNetCore.Mvc;
using website_backend.Models;
using website_backend.Services;

namespace website_backend.Controllers;

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
    public async Task<IActionResult> GetContact()
    {
        var contact = await _contactService.GetContactAsync();
        return Ok(ApiResponse<Contact>.SuccessResponse(contact));
    }

    [HttpGet("details")]
    public async Task<IActionResult> GetContactDetails()
    {
        var details = await _contactService.GetContactDetailsAsync();
        return Ok(ApiResponse<List<ContactDetail>>.SuccessResponse(details));
    }

    [HttpGet("social")]
    public async Task<IActionResult> GetSocialLinks()
    {
        var socialLinks = await _contactService.GetSocialLinksAsync();
        return Ok(ApiResponse<List<SocialLink>>.SuccessResponse(socialLinks));
    }

    [HttpGet("join")]
    public async Task<IActionResult> GetJoinUsInfo()
    {
        var joinUsInfo = await _contactService.GetJoinUsInfoAsync();
        if (joinUsInfo == null)
        {
            return Ok(ApiResponse<object>.SuccessResponse(new { description = string.Empty, conditions = new List<string>(), steps = new List<string>(), applicationUrl = string.Empty }));
        }
        return Ok(ApiResponse<JoinUsInfo>.SuccessResponse(joinUsInfo));
    }
}