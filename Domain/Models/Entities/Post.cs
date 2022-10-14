namespace Domain.Models.Entities;

public class Post
{
    public Post(string text, User author)
    {
        Text = text;
        Author = author;
    }

    public Post()
    {
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastUpdatedAt { get; set; }
    public User? CreatedBy { get; set; }
    public User? LastUpdatedBy { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; } = 0;
    public bool IsEdited { get; set; } = false;

    public virtual User Author { get; set; }
}
