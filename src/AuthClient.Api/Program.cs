using AuthClient.Infrastructure.Configuration;
using AuthClient.Infrastructure.Jwt;
using AuthClient.Infrastructure.Persistence.Contexts;
using AuthClient.Infrastructure.Persistence.Repositories;
using AuthClient.Infrastructure.Messaging;
using AuthClient.Application.Services;
using AuthClient.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Carrega appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Mapeia configurações
builder.Services.Configure<AppSettings>(builder.Configuration);

// Registra DbContext (SQL Server)
builder.Services.AddDbContext<AuthDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));

// Registra repositórios e serviços
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();

// Configura MassTransit/RabbitMQ
builder.Services.AddMessaging(builder.Configuration);

// Configura MediatR
builder.Services.AddMediatR(typeof(Program).Assembly);

// Adiciona controllers
builder.Services.AddControllers();

// Configura Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Digite 'Bearer {token}'"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            new string[]{ }
        }
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthClient API V1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();
app.Run();
