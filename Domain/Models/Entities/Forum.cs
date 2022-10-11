namespace Domain.Models.Entities;

public class Forum
{
    public Forum(string name, string? description = null, string? faq = null, string? rules = null)
    {
        Name = name;
        Description = description;
        Faq = faq;
        Rules = rules;
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastUpdatedAt { get; set; }
    public User? CreatedBy { get; set; }
    public User? LastUpdatedBy { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Faq { get; set; }
    public string? Rules { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    public virtual ICollection<User> Admins { get; set; } = new List<User>();
}
