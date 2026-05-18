using TutoringPlatform.Models;

namespace TutoringPlatform.DTOs;

public class ChangeLessonStatusDto
{
    public required LessonStatus Status { get; set; }
}