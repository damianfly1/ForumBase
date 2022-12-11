using Domain.Models.Entities;

namespace Application.DTOs.Post;

public class PostNestedResponseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public string Text { get; set; }
    public int Points { get; set; }
    public Domain.Models.Entities.User Author { get; set; }
    public List<LikedByDto> LikedBy { get; set; }
}
