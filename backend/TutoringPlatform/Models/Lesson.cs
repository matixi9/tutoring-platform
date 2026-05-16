namespace TutoringPlatform.Models;

public class Lesson
{
    public int Id { get; set; }
    public required DateTime StartTime { get; set; }
    public required LessonStatus Status { get; set; } = LessonStatus.Pending;

    public required int StudentId { get; set; }
    public User? Student { get; set; }

    public required int TutoringAdId { get; set; }
    public TutoringAd? TutoringAd { get; set; }
}