namespace Domain.Models.Entities;

public class Category
{
    public Category(string name, Forum forum, string? description = null, bool isModerationOnly = false)
    {
        Name = name;
        Description = description;
        IsModerationOnly = isModerationOnly;
        Forum = forum;
    }

    public Category()
    {
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
    public DateTime LastUpdatedAt { get; set; }
    public Guid? CreatedById { get; set; }
    public User? CreatedBy { get; set; }
    public Guid? LastUpdatedById { get; set; }
    public User? LastUpdatedBy { get; set; }
    public string Name { get; set; }   
    public string? Description { get; set; }
    public bool IsModerationOnly { get; set; }

    public Guid ForumId { get; set; }
    public Forum Forum { get; set; }
    public ICollection<Subforum> Subforums { get; set; } = new List<Subforum>();
    public ICollection<CategoryModerator> CategoryModerators { get; set; }
}
