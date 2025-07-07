using AuthClient.Domain.ValueObjects;
using AuthClient.Domain.Exceptions;

namespace AuthClient.Domain.Entities
{
    /// <summary>
    /// Representa um cliente no domínio de autenticação.
    /// </summary>
    public class Client : BaseEntity
    {
        public Email Email { get; private set; } = default!;             // e-mail encapsulado
        public Cpf Cpf { get; private set; } = default!;                 // CPF encapsulado
        public PasswordHash PasswordHash { get; private set; } = default!; // hash de senha
        public string Name { get; private set; } = default!;             // nome completo
        public string Phone { get; private set; } = default!;            // telefone de contato

        // Construtor protegido para uso do EF Core
        protected Client() { }

        /// <summary>
        /// Fábrica que valida dados e gera o hash da senha.
        /// </summary>
        public static Client Create(string email, string cpf, string password, string name, string phone)
        {
            var e = new Email(email);                 // valida formato de e-mail
            var c = new Cpf(cpf);                     // valida algoritmo de CPF
            var ph = PasswordHash.FromPlain(password);// gera salt+hash via BCrypt

            return new Client
            {
                Email = e,                            // atribui e-mail validado
                Cpf = c,                              // atribui CPF validado
                PasswordHash = ph,                    // atribui hash seguro
                Name = name,                          // atribui nome
                Phone = phone                         // atribui telefone
            };
        }

        /// <summary>
        /// Verifica se a senha em texto bate com o hash armazenado.
        /// </summary>
        public void VerifyPassword(string plain)
        {
            // se inválida, lança exceção de credenciais
            if (!PasswordHash.IsValid(plain))
                throw new InvalidCredentialsException();
        }
    }
}
