namespace AuthClient.Infrastructure.Configuration
{
    /// <summary>
    /// Mapeia a seção raiz de configuração.
    /// </summary>
    public class AppSettings
    {
        public JwtSettings JwtSettings { get; set; } = default!;
        public string AuthConnection { get; set; } = default!;
    }
}
