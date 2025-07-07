using System.Text.RegularExpressions;
using AuthClient.Domain.Exceptions;

namespace AuthClient.Domain.ValueObjects
{
    /// <summary>
    /// Value Object para e-mail, garantindo formato padrão.
    /// </summary>
    public sealed class Email
    {
        public string Value { get; }

        public Email(string value)
        {
            // regex simples para e-mails do tipo "nome@dominio.ext"
            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new DomainException("E-mail inválido.");
            Value = value;
        }
    }
}
