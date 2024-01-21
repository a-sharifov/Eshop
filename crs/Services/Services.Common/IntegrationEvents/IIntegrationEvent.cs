namespace Services.Common.IntegrationEvents;

/// <summary>
/// Interface for integration event.
/// </summary>
public interface IIntegrationEvent
{
    /// <summary>
    /// Gets the id of the event.
    /// </summary>
    public Guid Id { get; }
}
