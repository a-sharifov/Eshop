namespace Identity.IntegrationEvents;

public sealed record UserCreatedIntegrationEvent(Guid Id, int UserId) : IntegrationEvent(Id);
