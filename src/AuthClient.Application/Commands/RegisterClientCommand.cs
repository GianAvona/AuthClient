using MediatR;

namespace AuthClient.Application.Commands
{
    /// <summary>
    /// Command para criar um novo cliente.
    /// </summary>
    public record RegisterClientCommand(
        string Email,
        string Cpf,
        string Password,
        string Name,
        string Phone
    ) : IRequest; // sem retorno específico
}
