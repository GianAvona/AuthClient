using Microsoft.EntityFrameworkCore;
using AuthClient.Domain.Entities;

namespace AuthClient.Infrastructure.Persistence.Contexts
{
    /// <summary>
    /// Contexto do EF Core para o serviço de autenticação.
    /// </summary>
    public class AuthDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = default!;

        public AuthDbContext(DbContextOptions<AuthDbContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // aplica configurações de mapeamento automaticamente
            mb.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
        }
    }
}
