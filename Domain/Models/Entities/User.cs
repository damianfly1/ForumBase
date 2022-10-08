using Domain.Bases;

namespace Domain.Models.Entities; 

public class User : EntityBase
{
    private User(string nickName, string email) 
    {
        NickName = nickName;
        Email = email;
    }

    public string NickName { get; set; }
    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

}
