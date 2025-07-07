using System;

namespace AuthClient.Domain.Events
{
    /// <summary>
    /// Evento disparado após registro de cliente.
    /// </summary>
    public record ClientRegisteredEvent(Guid ClientId) : IDomainEvent
    {
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
