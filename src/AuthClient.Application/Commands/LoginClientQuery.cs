using MediatR;

namespace AuthClient.Application.Commands
{
    /// <summary>
    /// Query para login de cliente, retorna JWT.
    /// </summary>
    public record LoginClientQuery(
        string UserIdentifier, // pode ser e-mail ou CPF
        string Password        // texto puro
    ) : IRequest<string>;     // retorna token como string
}
