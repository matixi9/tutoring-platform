using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatform.Services;

namespace TutoringPlatform.Controllers;

[ApiController]
[Route("api/me")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdString, out int userId))
        {
            return Unauthorized(new { error = "Niewłaściwy token" });
        }


        var profile = await _usersService.GetUserProfileAsync(userId);
        if (profile == null)
        {
            return NotFound(new { error = "Nie znaleziono użytkownika" });
        }

        return Ok(profile);
    }
}