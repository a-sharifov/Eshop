namespace Catalog.Persistence.Services;

internal sealed class CachedCatalogService<TEntity, TStrongestId>(ICachedBaseService cachedBase)
    : ICachedCatalogService<TEntity, TStrongestId>
    where TEntity : Entity<TStrongestId>
    where TStrongestId : class, IStrongestId
{
    private readonly string _entityName = typeof(TEntity).Name;
    private readonly ICachedBaseService _cachedBase = cachedBase;

    private string GetKey(TStrongestId id) =>
        $"{_entityName} - {id.Value}";

    private string GetKey(TEntity entity) =>
       GetKey(entity.Id);

    public async Task<TEntity?> GetAsync(
        TStrongestId id,
        CancellationToken cancellationToken = default)
    {
        return await _cachedBase
            .GetAsync<TEntity>(GetKey(id));
    }

    public async Task SetAsync(
        TEntity entity,
        TimeSpan expirationDate = default,
        CancellationToken cancellationToken = default)
    {
        await _cachedBase.SetAsync(
            GetKey(entity),
            entity,
            expirationDate,
            cancellationToken);
    }

    public async Task RefreshAsync(
        TStrongestId id,
        CancellationToken cancellationToken = default)
    {
        await _cachedBase
            .RefreshAsync(GetKey(id), cancellationToken);
    }

    public async Task DeleteAsync(
        TStrongestId id,
        CancellationToken cancellationToken = default)
    {
        await _cachedBase
            .DeleteAsync(GetKey(id), cancellationToken);
    }

    public async Task SetAsync(
        IEnumerable<TEntity> entities, 
        TimeSpan expirationDate = default, 
        CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            await SetAsync(entity, expirationDate, cancellationToken);
        }
    }
}
