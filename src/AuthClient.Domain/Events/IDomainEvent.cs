using System;

namespace AuthClient.Domain.Events
{
    /// <summary>
    /// Marker interface para Domain Events.
    /// </summary>
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
