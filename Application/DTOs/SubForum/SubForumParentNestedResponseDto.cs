using Application.DTOs.Topic;

namespace Application.DTOs.SubForum;

public class SubForumParentNestedResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? CategoryName { get; set; }

    public ICollection<TopicNestedResponseDto> Topics { get; set; } = new List<TopicNestedResponseDto>();
}
