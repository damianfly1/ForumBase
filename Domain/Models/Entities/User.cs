using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Entities;

public class User : IdentityUser
{
    public User()
    {
    }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string NickName { get; set; }
    public string? AvatarUrl { get; set; } = null;
    public bool IsBanned { get; set; } = false;

    public List<LikedPosts> LikedPosts { get; set; } = new List<LikedPosts>();
}
