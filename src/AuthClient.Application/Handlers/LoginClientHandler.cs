using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AuthClient.Application.Settings;
using AuthClient.Domain.Repositories;
using AuthClient.Application.Queries;
using AuthClient.Application.Dtos;
using MediatR;

namespace AuthClient.Application.Handlers
{
    public class LoginClientHandler : IRequestHandler<LoginClientQuery, TokenDto>
    {
        private readonly ITokenService _tokenService;
        private readonly IClientRepository _clientRepository;

        public LoginClientHandler(
            ITokenService tokenService,
            IClientRepository clientRepository)
        {
            _tokenService = tokenService;
            _clientRepository = clientRepository;
        }

        public async Task<TokenDto> Handle(LoginClientQuery request, CancellationToken cancellationToken)
        {
            // 1. Busca o cliente pelo e-mail
            var client = await _clientRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (client == null || !client.ValidatePassword(request.Password))
                throw new UnauthorizedAccessException("E-mail ou senha inválidos.");

            // 2. Define claims que irão no JWT
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
                new Claim(ClaimTypes.Email, client.Email)
                // você pode adicionar outros claims aqui…
            };

            // 3. Gera o token via ITokenService
            var tokenString = _tokenService.GenerateToken(client.Id.ToString(), claims);

            // 4. Retorna o DTO com token e expiração
            return new TokenDto
            {
                Token = tokenString,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(60) // ou use o valor vindo de JwtSettings
            };
        }
    }
}
