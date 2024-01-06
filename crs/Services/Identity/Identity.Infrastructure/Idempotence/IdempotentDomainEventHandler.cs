namespace Identity.Infrastructure.Idempotence;

public sealed class IdempotentDomainEventHandler<TDomainEvent>
    (INotificationHandler<TDomainEvent> handler, IdentityDbContext dbContext)
    : IDomainEventHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    private readonly INotificationHandler<TDomainEvent> _handler = handler;
    private readonly IdentityDbContext _dbContext = dbContext;

    public async Task Handle(TDomainEvent notification, CancellationToken cancellationToken)
    {
        var isIdempotent = await IsIdempotentAsync(notification, cancellationToken);

        if (isIdempotent)
        {
            return;
        }

        await AddAsync(notification, cancellationToken);

        await _handler.Handle(notification, cancellationToken);
    }

    private async Task<bool> IsIdempotentAsync(TDomainEvent notification, CancellationToken cancellationToken)
    {
        var notificationName = notification.GetType().Name;

        return await _dbContext.Set<OutboxMessageConsumer>()
            .AnyAsync(x =>
            x.Id == notification.Id &&
            x.Name == notificationName, cancellationToken);
    }

    private async Task AddAsync(TDomainEvent notification, CancellationToken cancellationToken)
    {
        var notificationName = notification.GetType().Name;
        var outboxMessage = new OutboxMessageConsumer(notification.Id, notificationName);
        await _dbContext.Set<OutboxMessageConsumer>().AddAsync(outboxMessage, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
