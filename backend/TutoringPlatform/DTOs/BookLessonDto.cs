namespace TutoringPlatform.DTOs;

public class BookLessonDto
{
    public required int TutorAvailabilityId { get; set; }
    public required DateTime StartDate { get; set; }
    
    public required bool IsRecurring { get; set; }
    public int? PackageCount { get; set; }
}