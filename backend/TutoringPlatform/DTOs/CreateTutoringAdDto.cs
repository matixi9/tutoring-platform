namespace TutoringPlatform.DTOs;

public class CreateTutoringAdDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int Price { get; set; }
    public required bool isOnline { get; set; }
    public required bool isAvailable { get; set; }
}