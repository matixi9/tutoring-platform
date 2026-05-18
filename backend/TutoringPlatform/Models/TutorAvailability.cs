namespace TutoringPlatform.Models;

public class TutorAvailability
{
    public int Id { get; set; }
    public required int TutoringAdId { get; set; }
    public TutoringAd? TutoringAd { get; set; }
    
    public required DayOfWeek DayOfWeek { get; set; }
    public required TimeSpan StartTime { get; set; }
    public required TimeSpan EndTime { get; set; }
    
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}