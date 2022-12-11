using Application.DTOs.User;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public interface IUserService
{
    public Task<UserResponseDto> Get(string idOrName);
    public Task RegisterUser(UserRegistrationDto userForRegistration);
    public Task LoginUser(UserForAuthenticationDto userForAuthentication);
    public Task<string> UploadAvatar(IFormFile file, string userId, string? name);
    public Task DeleteAvatar(string userId, string? name);
    public Task<UserResponseDto> SetRole(string id, string role);
}
