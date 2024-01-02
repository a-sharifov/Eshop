namespace Identity.Application.Users.Events;

internal sealed class UserCreatedDomainEventHandler
    : IDomainEventHandler<UserCreatedDomainEvent>
{

    public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
