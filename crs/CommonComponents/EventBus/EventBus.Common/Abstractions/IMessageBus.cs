namespace EventBus.Common.Abstractions;

/// <summary>
/// Base interfase for event bus.
/// </summary>
public interface IMessageBus
{
    /// <summary>
    /// Publish event.
    /// </summary>
    /// <param name="event"> The event.</param>
    /// <param name="cancellationToken"> The cancellation token.</param>
    /// <returns> The <see cref="Task"/>.</returns>
    Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : IIntegrationEvent;

    /// <summary>
    /// Send command.
    /// </summary>
    /// <param name="command"> The command.</param>
    /// <param name="cancellationToken"> The cancellation token.</param>
    /// <returns> The <see cref="Task"/>.</returns>
    Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : IIntegrationCommand;
}
