namespace Identity.Domain.UserAggregate.DomainEvents;

public sealed record UserEmailChangedDomainEvent(
    Guid Id,
    UserId UserId)
    : IDomainEvent;
