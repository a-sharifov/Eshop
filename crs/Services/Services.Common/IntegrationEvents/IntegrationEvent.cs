namespace Services.Common.IntegrationEvents;

/// <summary>
/// class for integration event.
/// </summary>
/// <param name="Id"> The id of the event.</param>
public abstract record IntegrationEvent(Guid Id) : IIntegrationEvent;
