namespace Domain.Models.Entities;

public class Topic
{
    public Topic(string name, User author)
    {
        Name = name;
        Author = author;
    }

    public Topic()
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
    public bool IsPinned { get; set; } = false;
    public bool IsClosed { get; set; } = false;

    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
