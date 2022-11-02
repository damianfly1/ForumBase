using Domain.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Entities;

public class User : IdentityUser
{
    public User(string nickName, string email)
    {
        NickName = nickName;
        Email = email;
    }

    public User()
    {
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdatedAt { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Guid? AvatarId { get; set; }
    public Image? Avatar { get; set; } = null;
    public bool IsBanned { get; set; } = false;
    public int Reputation { get; set; } = 0;
    public string? Footer { get; set; } = null;
    public UserRole Role { get; set; } = UserRole.Normal;

    public ICollection<CategoryModerator> CategoryModerators { get; set; }
}
