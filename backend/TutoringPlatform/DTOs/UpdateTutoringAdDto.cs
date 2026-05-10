namespace TutoringPlatform.DTOs;

public class UpdateTutoringAdDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int Price { get; set; }
    public required bool IsOnline { get; set; }
    public required bool IsAvailable { get; set; }
}