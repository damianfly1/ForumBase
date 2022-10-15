namespace Domain.Models.Entities;

public class CategoryModerator
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}
