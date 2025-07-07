using System.Threading;
using System.Threading.Tasks;
using AuthClient.Application.Commands;
using AuthClient.Domain.Entities;
using AuthClient.Application.Interfaces;
using MediatR;

namespace AuthClient.Application.Handlers
{
    /// <summary>
    /// Handler que cria e persiste o cliente no banco.
    /// </summary>
    public class RegisterClientHandler : IRequestHandler<RegisterClientCommand>
    {
        private readonly IClientRepository _repo;

        public RegisterClientHandler(IClientRepository repo) =>
            _repo = repo; // injeta repositório

        public async Task<Unit> Handle(RegisterClientCommand cmd, CancellationToken ct)
        {
            // cria entidade validada e com hash de senha
            var client = Client.Create(cmd.Email, cmd.Cpf, cmd.Password, cmd.Name, cmd.Phone);
            // persiste a entidade
            await _repo.AddAsync(client, ct);
            return Unit.Value; // unitário, sem payload
        }
    }
}
