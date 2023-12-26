namespace Identity.Domain.UserAggregate.DomainEvents;

public sealed record UserCreatedDomainEvent(Guid Id, UserId UserId) : DomainEvent(Id);
