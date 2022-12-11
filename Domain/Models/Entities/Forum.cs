using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities;

public class Forum
{
    public Forum()
    {
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Faq { get; set; }
    public string? Rules { get; set; }

    public ICollection<Category> Categories { get; set; } = new List<Category>();
}
