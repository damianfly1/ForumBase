namespace Domain.Models.Entities;

public class Topic
{
    public Topic()
    {
    }
    public Topic(string name, SubForum subForum, bool isPinned, bool isClosed)
    {
        Name = name;
        IsPinned = isPinned;
        IsClosed = isClosed;
        SubForum = subForum;
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdatedAt { get; set; }
    public string? LastUpdatedById { get; set; }
    public User? LastUpdatedBy { get; set; }
    public string Name { get; set; }
    public bool IsPinned { get; set; } = false;
    public bool IsClosed { get; set; } = false;

    public string? AuthorId { get; set; }
    public User? Author { get; set; }
    public Guid? SubForumId { get; set; }
    public SubForum? SubForum { get; set; }
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
