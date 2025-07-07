using System.Threading;
using System.Threading.Tasks;
using AuthClient.Domain.Entities;

namespace AuthClient.Application.Interfaces
{
    /// <summary>
    /// Contrato para repositório de clientes.
    /// </summary>
    public interface IClientRepository
    {
        Task AddAsync(Client client, CancellationToken ct);
        Task<Client?> GetByEmailOrCpfAsync(string identifier);
    }
}
