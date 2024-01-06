namespace Services.Common.Domain.Primitives.Events;

/// <summary>
/// Interface for domain event.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets the id of the event.
    /// </summary>
    Guid Id { get; }
}
