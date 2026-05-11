using System.Security.Claims;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatform.DTOs;
using TutoringPlatform.Services;

namespace TutoringPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdsController : ControllerBase
{
    private readonly IAdsService _adsService;
    private readonly IValidator<CreateTutoringAdDto> _createValidator;

    public AdsController(IAdsService adsService, IValidator<CreateTutoringAdDto> createValidator)
    {
        _adsService = adsService;
        _createValidator = createValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? searchPhrase,
        [FromQuery] int? maxPrice,
        [FromQuery] bool? isOnline)
    {
        var ads = await _adsService.GetAllAsync(searchPhrase, maxPrice, isOnline);
        return Ok(ads);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ad = await _adsService.GetByIdAsync(id);
        if (ad == null)
        {
            return NotFound(new { error = "Nie znaleziono ogłoszenia" });
        }

        return Ok(ad);
    }

    [Authorize(Roles = "Tutor")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTutoringAdDto dto)
    {
        var validationResult = await _createValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select((e => new { e.PropertyName, e.ErrorMessage }));
            return BadRequest(new { errors });
        }

        var tutorIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(tutorIdString, out int tutorId))
            return Unauthorized(new { error = "Niewłaściwy token" });

        try
        {
            var createdAd = await _adsService.CreateAsync(dto, tutorId);
            return CreatedAtAction(nameof(GetById), new { id = createdAd.Id }, createdAd);
        }
        catch (Exception e)
        {
            return BadRequest(new { error = e.Message });
        }
    }

    [Authorize(Roles = "Tutor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTutoringAdDto dto)
    {
        var tutorIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(tutorIdString, out int tutorId)) return Unauthorized(new { error = "Niewłaściwy token" });

        try
        {
            var success = await _adsService.UpdateAsync(id, dto, tutorId);
            if (!success)
            {
                return NotFound(new { error = "Nie znaleziono ogłoszenia" });
            }

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(new { error = e.Message });
        }
    }

    [Authorize(Roles = "Tutor")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var tutorIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(tutorIdString, out int tutorId)) return Unauthorized(new { error = "Niewłaściwy token" });

        try
        {
            var success = await _adsService.DeleteAsync(id, tutorId);
            if (!success)
            {
                return NotFound(new { error = "Nie znaleziono ogłoszenia" });
            }

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
}