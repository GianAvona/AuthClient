using System;

namespace AuthClient.Domain.Exceptions
{
    /// <summary>
    /// Disparada quando as credenciais fornecidas são inválidas.
    /// </summary>
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException()
            : base("Credenciais inválidas.") { }
    }
}
