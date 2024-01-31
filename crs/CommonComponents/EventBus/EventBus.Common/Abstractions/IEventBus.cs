namespace EventBus.Common.Abstractions;

/// <summary>
/// Base interfase for event bus.
/// </summary>
public interface IEventBus
{
    /// <summary>
    /// Publish event.
    /// </summary>
    /// <param name="event"> The event.</param>
    /// <param name="cancellationToken"> The cancellation token.</param>
    /// <returns> The <see cref="Task"/>.</returns>
    Task Publish<TIntegrationEvent>(TIntegrationEvent @event, CancellationToken cancellationToken = default)
        where TIntegrationEvent : IIntegrationEvent;
}
