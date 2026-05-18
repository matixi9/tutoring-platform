namespace TutoringPlatform.Models;

public class TutoringAd
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int Price { get; set; }
    public required bool IsOnline { get; set; }
    public required bool IsAvailable { get; set; }

    public required int TutorId { get; set; }
    public User? Tutor { get; set; }
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    public ICollection<TutorAvailibility> TutorAvailabilities { get; set; } = new List<TutorAvailibility>();
}