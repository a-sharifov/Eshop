using Identity.Domain.UserAggregate.DomainEvents;

namespace Identity.Application.Users.Events;

internal sealed class UserEmailChangedDomainEventHandler
    : IDomainEventHandler<UserEmailChangedDomainEvent>
{
    public Task Handle(UserEmailChangedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
