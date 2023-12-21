namespace Identity.Domain.AggregatesModel.UserAggregate.DomainEvents;

public sealed record UserEmailChangedDomainEvent(
    Guid Id, 
    UserId UserId) 
    : IDomainEvent;
