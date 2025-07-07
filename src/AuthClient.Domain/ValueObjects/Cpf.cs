using System.Text.RegularExpressions;
using AuthClient.Domain.Exceptions;

namespace AuthClient.Domain.ValueObjects
{
    /// <summary>
    /// Value Object para CPF, garantindo 11 dígitos numéricos.
    /// </summary>
    public sealed class Cpf
    {
        public string Value { get; }

        public Cpf(string value)
        {
            // remove qualquer coisa que não seja dígito
            var digits = Regex.Replace(value, @"\D", "");
            // exige exatamente 11 dígitos
            if (digits.Length != 11)
                throw new DomainException("CPF inválido.");
            Value = digits;
        }
    }
}
