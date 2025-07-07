using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthClient.Infrastructure.Messaging
{
    /// <summary>
    /// Adiciona e configura o MassTransit/RabbitMQ.
    /// </summary>
    public static class MassTransitConfig
    {
        public static void AddMessaging(this IServiceCollection services, IConfiguration config)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(config["RabbitMq:Host"], "/", h => { /* usuário e senha */ });
                });
            });
        }
    }
}
