using Basket.Persistence.DbContexts.Abstractions;

namespace Basket.Persistence;

public sealed class UnitOfWork(IMongoDbContext mongoDbContext) : IUnitOfWork
{
    private readonly IMongoDbContext _mongoDbContext = mongoDbContext;

    public int Commit() =>
        _mongoDbContext.CommitAsync().Result;

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default) =>
        await _mongoDbContext.CommitAsync(cancellationToken);
}
