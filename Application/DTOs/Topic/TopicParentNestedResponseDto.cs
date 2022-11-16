using Application.DTOs.Post;
using Domain.Models.Entities;

namespace Application.DTOs.Topic;

public class TopicParentNestedResponseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime LastUpdatedAt { get; set; }
    public Guid? LastUpdatedById { get; set; }
    public Domain.Models.Entities.User? LastUpdatedBy { get; set; }
    public string Name { get; set; }
    public bool IsPinned { get; set; } 
    public bool IsClosed { get; set; } 

    public Guid AuthorId { get; set; }
    public Domain.Models.Entities.User Author { get; set; }
    public ICollection<PostNestedResponseDto> Posts { get; set; } = new List<PostNestedResponseDto>();
}
