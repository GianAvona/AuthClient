using System;

namespace AuthClient.Domain.Entities
{
    /// <summary>
    /// Base para todas as entidades, fornecendo um Id único.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Identificador único da entidade.
        /// </summary>
        public Guid Id { get; protected set; }

        protected BaseEntity()
        {
            // Gera um novo GUID ao instanciar a entidade
            Id = Guid.NewGuid();
        }
    }
}
