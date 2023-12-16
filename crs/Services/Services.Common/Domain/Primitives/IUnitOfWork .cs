namespace Services.Common.Domain.Primitives;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public int SaveChanges();
}
