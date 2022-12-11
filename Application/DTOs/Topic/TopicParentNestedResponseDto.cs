using Application.DTOs.Post;

namespace Application.DTOs.Topic;

public class TopicParentNestedResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsPinned { get; set; } 
    public bool IsClosed { get; set; } 
    public Domain.Models.Entities.User Author { get; set; }
    public ICollection<PostNestedResponseDto> Posts { get; set; } = new List<PostNestedResponseDto>();
}
