using Domain.Models.Enums;

namespace Domain.Models.Entities;

public class Message
{
    public Message(string title, string text, User author, User recipent, MessageStatus status = MessageStatus.New)
    {
        Title = title;
        Text = text;
        Status = status;
        Author = author;
        Recipent = recipent;
    }

    public Message()
    {
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastUpdatedAt { get; set; }
    public User? CreatedBy { get; set; }
    public User? LastUpdatedBy { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public MessageStatus Status { get; set; }

    public virtual User Author { get; set; }
    public virtual User Recipent { get;set; }
    
}
