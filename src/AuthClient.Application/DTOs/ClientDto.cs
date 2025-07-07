using System;

namespace AuthClient.Application.DTOs
{
    /// <summary>
    /// DTO contendo informações do cliente para claims.
    /// </summary>
    public record ClientDto(Guid Id, string Email, string Cpf);
}
