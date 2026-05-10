namespace TutoringPlatform.DTOs;

public class TutoringAdDto
{
    public int Id { get; set; }
    public required string Subject { get; set; }
    public decimal Price { get; set; }
    public bool IsOnline { get; set; }
    public required string TutorName { get; set; }
    public int TutorId { get; set; }
}