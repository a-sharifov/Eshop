namespace Identity.Domain.AggregatesModel.UserAggregate.DomainEvents;

public sealed record UserCreatedDomainEvent(Guid Id, UserId UserId): DomainEvent(Id);
