using BCrypt.Net;

namespace AuthClient.Domain.ValueObjects
{
    /// <summary>
    /// Encapsula o hash seguro da senha gerada via BCrypt.
    /// </summary>
    public sealed class PasswordHash
    {
        private readonly string _hash; // valor interno do hash

        private PasswordHash(string hash) => _hash = hash;

        /// <summary>
        /// Gera o hash a partir da senha em texto puro.
        /// </summary>
        public static PasswordHash FromPlain(string plain)
        {
            // gera um salt único
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            // retorna instância com o hash gerado
            return new PasswordHash(BCrypt.Net.BCrypt.HashPassword(plain, salt));
        }

        /// <summary>
        /// Verifica se a senha em texto puro bate com o hash.
        /// </summary>
        public bool IsValid(string plain) =>
            BCrypt.Net.BCrypt.Verify(plain, _hash);
    }
}
