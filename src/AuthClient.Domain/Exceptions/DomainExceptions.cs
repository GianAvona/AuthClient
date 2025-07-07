using System;

namespace AuthClient.Domain.Exceptions
{
    /// <summary>
    /// Exceção genérica para erros de regras de negócio.
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
