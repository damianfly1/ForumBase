using Application.DTOs.User;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Headers;

namespace Application.Services;
public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IPostService _postsService;

    public UserService(UserManager<User> userManager, IPostService postService)
    {
        _userManager = userManager;
        _postsService = postService;
    }

    public async Task DeleteAvatar(string id, string? name)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user.UserName != name) throw new ApplicationException("NOT AUTHORIZED");
        bool fileExists = File.Exists(user.AvatarUrl);
        if (fileExists) File.Delete(user.AvatarUrl);
        user.AvatarUrl = null;
        await _userManager.UpdateAsync(user);
    }

    public async Task<UserResponseDto> Get(string idOrName)
    {
        var user = await _userManager.FindByIdAsync(idOrName);
        if (user == null) user = await _userManager.FindByNameAsync(idOrName);
        if (user == null) throw new ApplicationException("NOT FOUND");
        var role = await _userManager.GetRolesAsync(user);
        if (role.Count() == 0) role.Add("BANNED");
        return new UserResponseDto
        {
            Id = user.Id,
            NickName = user.NickName,
            UserName = user.UserName,
            CreatedAt = user.CreatedAt,
            IsBanned = user.IsBanned,
            AvatarUrl = user.AvatarUrl,
            PostCount = await _postsService.GetUserPostCount(user.Id),
            Reputation = await _postsService.GetUserReputation(user.Id),
            Role = role.First()
        };
    }

    public Task LoginUser(UserForAuthenticationDto userForAuthentication)
    {
        throw new NotImplementedException();
    }

    public async Task RegisterUser(UserRegistrationDto userForRegistration)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResponseDto> SetRole(string id, string role)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) throw new ApplicationException("NOT FOUND");
        var userRole = await _userManager.GetRolesAsync(user);
        if (role != "Ban" && role != "Unban") await _userManager.RemoveFromRoleAsync(user, userRole.First());
        if (role == "Administrator") await _userManager.AddToRoleAsync(user, "Administrator");
        else if (role == "Moderator") await _userManager.AddToRoleAsync(user, "Moderator");
        else if (role == "User") await _userManager.AddToRoleAsync(user, "User");
        else if (role == "Ban")
        {
            user.IsBanned = true;
            role = "Zbanowany";
        }
        else if (role == "Unban")
        {
            user.IsBanned = false;
            await _userManager.AddToRoleAsync(user, "User");
            role = "Użytkownik";
        }
        await _userManager.UpdateAsync(user);
        return new UserResponseDto
        {
            Id = user.Id,
            UserName = user.UserName,
            CreatedAt = user.CreatedAt,
            IsBanned = user.IsBanned,
            AvatarUrl = user.AvatarUrl,
            PostCount = await _postsService.GetUserPostCount(user.Id),
            Reputation = await _postsService.GetUserReputation(user.Id),
            Role = role,
        };
    }

    public async Task<string> UploadAvatar(IFormFile file, string userId, string? name)
    {
        var folderName = Path.Combine("Resources", "Images");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        if (file.Length > 0)
        {
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user.UserName != name) throw new ApplicationException("NOT AUTHORIZED"); 
            user.AvatarUrl = dbPath;
            await _userManager.UpdateAsync(user);
            return dbPath;
        }
        else
        {
            throw new ApplicationException("BAD REQUEST");
        }
    }
}
