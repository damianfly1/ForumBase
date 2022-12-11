namespace Domain.Models.Entities;

public class Post
{

    public Post()
    {
    }
    public Post(string text, Topic topic, User? author)
    {
        Text = text;
        Topic = topic;
        Author = author;
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastUpdatedAt { get; set; }
    public string Text { get; set; }
    public int Points { get; set; } = 0;

    public string? AuthorId { get; set; }
    public User? Author { get; set; }
    public Guid? TopicId { get; set; }
    public Topic? Topic { get; set; }
    public List<LikedPosts> LikedBy { get; set; } = new List<LikedPosts>();
}
