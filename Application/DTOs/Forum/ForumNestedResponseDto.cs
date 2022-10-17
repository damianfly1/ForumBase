using Application.DTOs.Category;

namespace Application.DTOs.Forum;

public class ForumNestedResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<CategoryNestedResponseDto> Categories { get; set; } = new List<CategoryNestedResponseDto>();
}