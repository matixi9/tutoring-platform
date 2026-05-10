namespace TutoringPlatform.DTOs;

public class TutoringAdDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public int Price { get; set; }
    public bool IsOnline { get; set; }
    public bool IsAvailable { get; set; }
    public required string TutorName { get; set; }
    public int TutorId { get; set; }
}