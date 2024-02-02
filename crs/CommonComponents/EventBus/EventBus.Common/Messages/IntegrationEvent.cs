namespace EventBus.Common.Messages;

/// <summary>
/// The integration event.
/// </summary>
/// <param name="Id">The identifier event.</param>
public abstract record IntegrationEvent(Guid Id) : IIntegrationEvent
{
    /// <summary>
    /// The creation date of the event.
    /// </summary>
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
