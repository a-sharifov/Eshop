namespace Contracts.Services.Identity.Events;

public sealed record IdentityVerificationConfirmedEvent(
    Guid Id, 
    Guid UserId) : IntegrationEvent(Id);
