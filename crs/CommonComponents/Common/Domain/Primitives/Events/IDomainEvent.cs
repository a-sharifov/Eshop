namespace Common.Domain.Primitives.Events;

/// <summary>
/// Interface for domain event.
/// if you need class. because class can't inherit from record.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets the id of the event.
    /// </summary>
    Guid Id { get; }
}   
