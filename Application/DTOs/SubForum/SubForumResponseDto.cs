using Domain.Models.Entities;

namespace Application.DTOs.SubForum;

public class SubForumResponseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public Guid? CreatedById { get; set; }
    public User? CreatedBy { get; set; }
    public Guid? LastUpdatedById { get; set; }
    public User? LastUpdatedBy { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public Guid? CategoryId { get; set; }
    public Guid? ParentId { get; set; }
}
