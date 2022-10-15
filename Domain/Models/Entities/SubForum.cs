namespace Domain.Models.Entities;

public class Subforum
{
    public Subforum(string name, Category? category, Subforum? parent, string? description = null)
    {
        Name = name;
        Description = description;
        Category = category;
        Parent = parent;
    }

    public Subforum()
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
    public Subforum? Parent { get; set; }
    public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    
}
