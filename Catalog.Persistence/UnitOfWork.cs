namespace Catalog.Persistence;

internal sealed class UnitOfWork(CatalogDbContext dbContext) : IUnitOfWork
{
    private readonly CatalogDbContext _dbContext = dbContext;

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
        var outboxMessages = _dbContext.ChangeTracker
            .Entries<IHasDomainEvents>()
            .Select(x => x.Entity)
            .SelectMany(aggregateRoot =>
            {
                var domainEvents = aggregateRoot.DomainEvents;
                aggregateRoot.ClearDomainEvents();
                return domainEvents;
            })
            .Select(domainEvents => new OutboxMessage(
                id: Guid.NewGuid(),
                createdAt: DateTime.Now,
                type: domainEvents.GetType().Name,
                message: JsonSerializer.SerializeObject(domainEvents))
            );

        await _dbContext
            .Set<OutboxMessage>()
            .AddRangeAsync(outboxMessages, cancellationToken);
    }
}
