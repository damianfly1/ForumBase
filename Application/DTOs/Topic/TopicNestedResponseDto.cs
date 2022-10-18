using Domain.Models.Entities;

namespace Application.DTOs.Topic;

public class TopicNestedResponseDto
{
    public Guid Id { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public User? LastUpdatedBy { get; set; }
    public string Name { get; set; }
    public bool IsPinned { get; set; } 
    public bool IsClosed { get; set; } 
    public User Author { get; set; }
    //public int ResponseCount { get; set; }
}
