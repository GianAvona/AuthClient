using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthClient.Domain.Entities;
using AuthClient.Application.Interfaces;
using AuthClient.Infrastructure.Persistence.Contexts;

namespace AuthClient.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Repositório de clientes usando EF Core.
    /// </summary>
    public class ClientRepository : IClientRepository
    {
        private readonly AuthDbContext _ctx;

        public ClientRepository(AuthDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Client client, CancellationToken ct) =>
            await _ctx.Clients.AddAsync(client, ct);

        public async Task<Client?> GetByEmailOrCpfAsync(string identifier) =>
            await _ctx.Clients
                .FirstOrDefaultAsync(c => c.Email.Value == identifier || c.Cpf.Value == identifier);
    }
}
