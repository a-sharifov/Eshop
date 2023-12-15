namespace Catalog.Persistence.Services.Interfaces;

internal interface ICachedCatalogService<TEntity, TStrongestId>
    where TEntity : Entity<TStrongestId>
    where TStrongestId : class, IStrongestId
{
    public Task DeleteAsync(TStrongestId id, CancellationToken cancellationToken = default);
    public Task<TEntity?> GetAsync(TStrongestId id, CancellationToken cancellationToken = default);
    public Task RefreshAsync(TStrongestId id, CancellationToken cancellationToken = default);
    public Task SetAsync(TEntity entity, TimeSpan expirationDate = default, CancellationToken cancellationToken = default);
    public Task SetAsync(IEnumerable<TEntity> entities, TimeSpan expirationDate = default, CancellationToken cancellationToken = default);
}