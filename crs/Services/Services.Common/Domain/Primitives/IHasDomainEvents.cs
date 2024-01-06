namespace Services.Common.Domain.Primitives;

/// <summary>
/// Interface for objects that have domain events.
/// </summary>
public interface IHasDomainEvents
{
    /// <summary>
    /// Gets the read only collection of domain events.
    /// </summary>
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Clear domain events collecion  
    /// </summary>
    void ClearDomainEvents();
}
