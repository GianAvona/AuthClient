namespace AuthClient.Infrastructure.Jwt
{
    /// <summary>
    /// Configurações de emissor/audience e chave do JWT.
    /// </summary>
    public class JwtSettings
    {
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public string SecretKey { get; set; } = default!;
        public int ExpiryHours { get; set; }
    }
}
