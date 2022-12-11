using Application.DTOs.SubForum;

namespace Application.DTOs.Category;

public class CategoryNestedResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsModerationOnly { get; set; }

    public ICollection<SubForumNestedResponseDto> Subforums { get; set; } = new List<SubForumNestedResponseDto>();
}