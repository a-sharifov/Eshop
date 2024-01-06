namespace Catalog.Domain.Common.Repositories;

public interface ICatalogRepository<TEntity, TStrongestId>
    : IRepository<TEntity, TStrongestId>
    where TEntity : Entity<TStrongestId>
    where TStrongestId : IStrongestId
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetPagedAsync(int skip, int take, CancellationToken cancellationToken = default);
    Task<int> CountAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TStrongestId id, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(TStrongestId id, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(TStrongestId id, CancellationToken cancellationToken = default);
}
