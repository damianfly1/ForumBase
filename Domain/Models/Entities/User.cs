using Domain.Bases;
using Domain.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities; 

public class User
{
    public User(string nickName, string email)
    {
        NickName = nickName;
        Email = email;
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdatedAt { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Image? Avatar { get; set; } = null;
    public bool IsBanned { get; set; } = false;
    public int Reputation { get; set; } = 0;
    public string? Footer { get; set; } = null;
    public UserRole Role { get; set; } = UserRole.Normal;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
