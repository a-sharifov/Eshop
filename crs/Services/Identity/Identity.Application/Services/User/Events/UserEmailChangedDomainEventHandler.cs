namespace Identity.Application.Services.User.Events;

internal sealed class UserEmailChangedDomainEventHandler
    : IDomainEventHandler<UserEmailChangedDomainEvent>
{
    public Task Handle(UserEmailChangedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
