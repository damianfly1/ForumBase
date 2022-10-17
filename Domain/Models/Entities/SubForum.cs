namespace Domain.Models.Entities;

public class SubForum
{
    public SubForum(string name, Category? category, SubForum? parent, string? description = null)
    {
        Name = name;
        Description = description;
        Category = category;
        Parent = parent;
    }

    public SubForum()
    {
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdatedAt { get; set; }
    public Guid? CreatedById { get; set; }
    public User? CreatedBy { get; set; }
    public Guid? LastUpdatedById { get; set; }
    public User? LastUpdatedBy { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
    public Guid? ParentId { get; set; }
    public SubForum? Parent { get; set; }
    public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    
}
