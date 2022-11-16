namespace Domain.Models.Entities;

public class Post
{

    public Post()
    {
    }
    public Post(string text, Topic topic)
    {
        Text = text;
        Topic = topic;
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastUpdatedAt { get; set; }
    public string? LastUpdatedById { get; set; }
    public User? LastUpdatedBy { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; } = 0;
    public bool IsEdited { get; set; } = false;
    public string? AuthorId { get; set; }
    public User? Author { get; set; }
    public Guid? TopicId { get; set; }
    public Topic? Topic { get; set; }
}
