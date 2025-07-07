using MediatR;
using AuthClient.Application.Dtos;

namespace AuthClient.Application.Queries
{
    public class LoginClientQuery : IRequest<TokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
