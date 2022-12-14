using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.User;

public class UserRegistrationDto
{
    [Required(ErrorMessage = "Email jest wymagany")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Nick jest wymagany")]
    public string Nickname { get; set; }

    [Required(ErrorMessage = "Hasło jest wymagane")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "Hasła nie pasują do siebie")]
    public string ConfirmPassword { get; set; }
}

