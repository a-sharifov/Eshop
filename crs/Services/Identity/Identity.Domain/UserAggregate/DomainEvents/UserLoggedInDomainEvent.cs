namespace Identity.Domain.UserAggregate.DomainEvents;

public record UserLoggedInDomainEvent(
    Guid Id,
    UserId UserId)
    : IDomainEvent;
