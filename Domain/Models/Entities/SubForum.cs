namespace Domain.Models.Entities;

public class SubForum
{
    public SubForum()
    {
    }
    public SubForum(string name, string? description, Category? category)
    {
        Name = name;
        Description = description;
        Category = category;
    }
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdatedAt { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public string? CreatedById { get; set; }
    public User? CreatedBy { get; set; }
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
    public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    
}
