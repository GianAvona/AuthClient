using AuthClient.Application.Settings;
using AuthClient.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;

public class TokenService : ITokenService
{
    private readonly JwtSettings _settings;
    public TokenService(IOptions<JwtSettings> options)
    {
        _settings = options.Value;
    }
    public string GenerateToken(string userId, IEnumerable<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
