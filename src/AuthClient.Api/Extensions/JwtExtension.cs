public static class JwtExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, JwtSettings settings)
    {
        // configura esquema de autenticação JWT Bearer
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // esquema padrão
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    // desafio padrão
        })
        .AddJwtBearer(opts =>
        {
            opts.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,                        // valida emissor
                ValidateAudience = true,                      // valida público
                ValidIssuer = settings.Issuer,                // emissor esperado
                ValidAudience = settings.Audience,            // público esperado
                IssuerSigningKey = new SymmetricSecurityKey(  // chave para validar assinatura
                    Encoding.UTF8.GetBytes(settings.SecretKey))
            };
        });

        return services;
    }
}
