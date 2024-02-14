namespace Basket.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    public int Commit()
    {
        throw new NotImplementedException();
    }

    public Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
