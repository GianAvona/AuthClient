public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // registra MediatR para handlers de Commands/Queries
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        // registra serviços de domínio, token etc.
        services.AddScoped<ITokenService, JwtTokenService>();
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        // configura DbContext do EF Core para SQL Server
        services.AddDbContext<AuthDbContext>(opts =>
            opts.UseSqlServer(config.GetConnectionString("AuthConnection")));
        // registra repositório concreto
        services.AddScoped<IClientRepository, ClientRepository>();
        // configura opções de JWT via appsettings.json
        services.Configure<JwtSettings>(config.GetSection("JwtSettings"));
        return services;
    }
}
