namespace TutoringPlatform.Models;

public class TutoringAd
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int Price { get; set; }
    public required bool isOnline { get; set; }
    public required bool isAvailable { get; set; }
    
    public required int TutorId { get; set; }
    public User? Tutor { get; set; }
}