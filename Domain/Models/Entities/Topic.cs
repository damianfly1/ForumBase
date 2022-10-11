namespace Domain.Models.Entities;

public class Topic
{
    public Topic(string name, User author)
    {
        Name = name;
        Author = author;
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdatedAt { get; set; }
    public User? CreatedBy { get; set; }
    public User? LastUpdatedBy { get; set; }
    public string Name { get; set; }
    public bool IsPinned { get; set; } = false;
    public bool IsClosed { get; set; } = false;

    public User Author { get; set; }
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
