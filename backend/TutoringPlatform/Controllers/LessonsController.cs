using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatform.DTOs;
using TutoringPlatform.Services;

namespace TutoringPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly ILessonsService _lessonsService;

    public LessonsController(ILessonsService lessonsService)
    {
        _lessonsService = lessonsService;
    }

    [Authorize(Roles = "Student")]
    [HttpPost("book")]
    public async Task<IActionResult> BookLesson([FromBody] BookLessonDto bookLessonDto)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdString, out int studentId))
        {
            return Unauthorized();
        }

        try
        {
            var lesson = await _lessonsService.BookLessonAsync(studentId, bookLessonDto);
            if (lesson == null)
            {
                return NotFound(new { error = "Nie znaleziono wybranego terminu" });
            }

            return Ok(new { message = "Pomyślnie wysłano prośbę o rezerwację terminu", lessonId = lesson.Id });
        }
        catch (InvalidOperationException e)
        {
            return Conflict(new { error = e.Message });
        }
    }

    [Authorize(Roles = "Tutor")]
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> ChangeStatus(int id, [FromBody] ChangeLessonStatusDto changeLessonStatusDto)
    {
        var tutorIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(tutorIdString, out int tutorId))
        {
            return Unauthorized();
        }

        try
        {
            var success = await _lessonsService.ChangeStatusByTutorAsync(tutorId, id, changeLessonStatusDto.Status);
            if (!success)
            {
                return NotFound(new { error = "Nie znaleziono lekcji" });
            }

            return Ok(new { message = "Status lekcji został zaktualizowany" });
        }
        catch (UnauthorizedAccessException e)
        {
            return Forbid(e.Message);
        }
    }

    [Authorize(Roles = "Student")]
    [HttpPatch("{id}/cancel")]
    public async Task<IActionResult> CancelLesson(int id)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdString, out int studentId))
        {
            return Unauthorized();
        }

        try
        {
            var success = await _lessonsService.CancelByStudentAsync(studentId, id);
            if (!success)
            {
                return NotFound(new { error = "Nie znaleziono lekcji" });
            }

            return Ok(new { message = "Zajęcia zostały pomyślnie anulowane" });
        }
        catch (UnauthorizedAccessException e)
        {
            return Forbid(e.Message);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
}