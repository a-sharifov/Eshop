namespace Catalog.Domain.Common.Repositories;

public interface ICatalogRepository<TEntity, TStrongestId>
    : IRepository<TEntity, TStrongestId>
    where TEntity : Entity<TStrongestId>
    where TStrongestId : IStrongestId
{
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    public Task<IEnumerable<TEntity>> GetPagedAsync(int skip, int take, CancellationToken cancellationToken = default);
    public Task<int> CountAsync(CancellationToken cancellationToken = default);
    public Task<TEntity?> GetByIdAsync(TStrongestId id, CancellationToken cancellationToken = default);
    public Task<bool> ExistsAsync(TStrongestId id, CancellationToken cancellationToken = default);
    public Task DeleteByIdAsync(TStrongestId id, CancellationToken cancellationToken = default);
}
