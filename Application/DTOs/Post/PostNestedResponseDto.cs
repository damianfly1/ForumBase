using Domain.Models.Entities;

namespace Application.DTOs.Post;

public class PostNestedResponseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public Guid? LastUpdatedById { get; set; }
    public User? LastUpdatedBy { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; } = 0;
    public bool IsEdited { get; set; } = false;

    public Guid AuthorId { get; set; }
    public User Author { get; set; }
}
