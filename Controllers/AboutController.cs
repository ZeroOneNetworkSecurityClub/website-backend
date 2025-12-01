using Microsoft.AspNetCore.Mvc;
using website_backend.Models;
using website_backend.Services;
using website_backend.DTOs;

namespace website_backend.Controllers;

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
    public async Task<IActionResult> GetAbout()
    {
        var about = await _aboutService.GetAboutAsync();
        if (about == null)
        {
            return NotFound(ApiResponse<AboutDto>.ErrorResponse("About information not found."));
        }
        var aboutDto = about.ToDto();
        return Ok(ApiResponse<AboutDto>.SuccessResponse(aboutDto));
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
        return Ok(ApiResponse<List<string>>.SuccessResponse(missions));
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetHistory()
    {
        var history = await _aboutService.GetHistoryAsync();
        return Ok(ApiResponse<List<HistoryItem>>.SuccessResponse(history));
    }

    [HttpGet("organization")]
    public async Task<IActionResult> GetOrganization()
    {
        var organization = await _aboutService.GetOrganizationAsync();
        return Ok(ApiResponse<List<OrganizationItem>>.SuccessResponse(organization));
    }
}