namespace EventBus.Common.Events;

/// <summary>
/// class for integration event.
/// </summary>
public abstract record IntegrationEvent(Guid Id) : IIntegrationEvent
{
    /// <summary>
    /// The id event.
    /// </summary>
    public Guid Id { get; private set; } = Id;

    /// <summary>
    /// The creation date of the event.
    /// </summary>
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
