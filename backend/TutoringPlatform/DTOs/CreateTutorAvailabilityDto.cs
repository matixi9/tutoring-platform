namespace TutoringPlatform.DTOs;

public class CreateTutorAvailabilityDto
{
    public required DayOfWeek DayOfWeek { get; set; }
    public required TimeSpan StartTime { get; set; }
}