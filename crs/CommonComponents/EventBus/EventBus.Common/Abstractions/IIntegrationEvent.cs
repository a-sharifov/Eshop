namespace EventBus.Common.Abstractions;

/// <summary>
/// Inteface for integration event.
/// </summary>
public interface IIntegrationEvent: IEvent
{
    /// <summary>
    /// The id event.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// The creation date of the event.
    /// </summary>
    DateTime CreatedAt { get; }
}