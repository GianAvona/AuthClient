using System.Security.Claims;

namespace AuthClient.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string userId, IEnumerable<Claim> claims);
    }
}
