namespace Application.DTOs.User;

public class UserRegistrationDto
{
    public string Email { get; set; }

    public string Nickname { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
}

