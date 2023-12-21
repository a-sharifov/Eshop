namespace Identity.Persistence;

public sealed class UnitOfWork(IdentityDbContext dbContext) : IUnitOfWork
{
    private readonly IdentityDbContext _dbContext = dbContext;

    public int SaveChanges()
    {
        SendDomainEventsToOutboxMessagesAsync().GetResult();
        return _dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await SendDomainEventsToOutboxMessagesAsync(cancellationToken);
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task SendDomainEventsToOutboxMessagesAsync(CancellationToken cancellationToken = default)
    {
        var entityEntryChange = _dbContext.ChangeTracker
            .Entries<IHasDomainEvents>().ToList();

        var outboxMessages = entityEntryChange
            .Select(x => x.Entity)
            .SelectMany(hasDomainEvents =>
            {
                var domainEvents = hasDomainEvents.DomainEvents;
                hasDomainEvents.ClearDomainEvents();
                return domainEvents;
            })
            .Select(domainEvent => new OutboxMessage(
                id: Guid.NewGuid(),
                createdAt: DateTime.Now,
                type: domainEvent.GetType().Name,
                message: JsonSerializer.SerializeObject(domainEvent))
            );

        await _dbContext
            .Set<OutboxMessage>()
            .AddRangeAsync(outboxMessages, cancellationToken);
    }
}
