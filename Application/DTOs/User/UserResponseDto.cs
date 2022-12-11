namespace Application.DTOs.User;

public class UserResponseDto
{  
    public string Id { get; set; }
    public string UserName { get;set; }
    public string NickName { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsBanned { get; set; }
    public string Role { get; set; }
    public int PostCount { get; set; }
    public int Reputation { get; set; }
    public string AvatarUrl { get; set; }

}
