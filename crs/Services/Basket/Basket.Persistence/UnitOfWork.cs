namespace Basket.Persistence;

internal sealed class UnitOfWork(BasketDbContext dbContext) : IUnitOfWork
{
    private readonly BasketDbContext _dbContext = dbContext;

    public int Commit() => 
        _dbContext.SaveChanges();

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default) => 
        await _dbContext.SaveChangesAsync(cancellationToken);
}
