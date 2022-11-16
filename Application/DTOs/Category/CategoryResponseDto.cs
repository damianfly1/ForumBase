namespace Application.DTOs.Category;

public class CategoryResponseDto
{
    public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public Guid? CreatedById { get; set; }
    public Domain.Models.Entities.User? CreatedBy { get; set; }
    public Guid? LastUpdatedById { get; set; }
    public Domain.Models.Entities.User? LastUpdatedBy { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsModerationOnly { get; set; }

    public Guid ForumId { get; set; }
}
