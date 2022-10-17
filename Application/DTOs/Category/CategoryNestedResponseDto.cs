using Application.DTOs.SubForum;

namespace Application.DTOs.Category;

public class CategoryNestedResponseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsModerationOnly { get; set; }

    public ICollection<SubforumNestedResponseDto> Subforums { get; set; } = new List<SubforumNestedResponseDto>();
}