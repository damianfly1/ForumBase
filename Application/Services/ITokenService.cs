using Domain.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Services;

public interface ITokenService
{
    public SigningCredentials GetSigningCredentials();
    public Task<List<Claim>> GetClaims(User user);
    public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims);
}