namespace Catalog.Persistence.Repositories;

internal abstract class CatalogBaseRepository<TEntity, TStrongestId> 
    : ICatalogRepository<TEntity, TStrongestId>
    where TEntity : Entity<TStrongestId>
    where TStrongestId : class, IStrongestId
{
    protected readonly string _entityName;
    protected readonly CatalogDbContext _dbContext;
    protected readonly ISqlConnectionFactory _sqlConnectionFactory;
    protected readonly ICachedCatalogService<TEntity, TStrongestId> _cached;
    protected readonly TimeSpan _expirationTime;

    protected CatalogBaseRepository(
        CatalogDbContext dbContext,
        ISqlConnectionFactory sqlConnectionFactory,
        ICachedCatalogService<TEntity, TStrongestId> cached,
        TimeSpan expirationTime)
    {
        _entityName = typeof(TStrongestId).Name;
        _dbContext = dbContext;
        _sqlConnectionFactory = sqlConnectionFactory;
        _cached = cached;
        _expirationTime = expirationTime;
    }

    public async Task AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        await _cached.SetAsync(entity, _expirationTime, cancellationToken);

        await _dbContext
            .Set<TEntity>()
            .AddAsync(entity, cancellationToken);

    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _cached.DeleteAsync(entity.Id, cancellationToken);
        _dbContext.Remove(entity);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext
            .Set<TEntity>()
            .Update(entity);

        await _cached.RefreshAsync(entity.Id, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        using var sqlConnection = _sqlConnectionFactory.GetOpenConnection();

        var query = $"SELECT * FROM [{_entityName}]";

        var entities = await sqlConnection.QueryAsync<TEntity>(query, cancellationToken);

        return entities;
    }

    public async Task<IEnumerable<TEntity>> GetPagedAsync(int skip, int take, CancellationToken cancellationToken = default)
    {
        using var sqlConnection = _sqlConnectionFactory.GetOpenConnection();

        var query =
            $"SELECT * FROM [{_entityName}]" +
            "ORDER BY [Id]" +
            "OFFSET @Skip ROWS" +
            "FETCH NEXT @Take ROWS ONLY";

        var parameters = new
        {
            Skip = skip,
            Take = take
        };

        var entities = await sqlConnection
            .QueryAsync<TEntity>(query, parameters);

        await _cached
            .SetAsync(entities, _expirationTime, cancellationToken);

        return entities;
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        using var sqlConnection = _sqlConnectionFactory.GetOpenConnection();

        var query = $"SELECT COUNT(*) FROM {_entityName}";

        return await sqlConnection.ExecuteScalarAsync<int>(query, cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(TStrongestId id, CancellationToken cancellationToken = default)
    {
        var entity = await _cached.GetAsync(id, cancellationToken);

        if(entity is not null)
        {
            return entity;
        }

        using var sqlConnection = _sqlConnectionFactory.GetOpenConnection();

        var query = 
            $"SELECT * FROM {_entityName}" +
            "WHERE [Id] = @Id";

        var parameters = new { Id = id.Value };

        entity = await sqlConnection.QueryFirstAsync<TEntity>(query, cancellationToken);

        await _cached.SetAsync(entity, _expirationTime, cancellationToken);
        return entity;
    }

    public async Task<bool> ExistsAsync(TStrongestId id, CancellationToken cancellationToken = default)
    {
        return await GetByIdAsync(
            id, 
            cancellationToken) 
            is not null;
    }

    public async Task DeleteByIdAsync(TStrongestId id, CancellationToken cancellationToken = default)
    {
        await _dbContext
            .Set<TEntity>()
            .Where(entity => entity.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<TStrongestId> ids, CancellationToken cancellationToken = default)
    {
        return await _dbContext
            .Set<TEntity>()
            .AsNoTracking()
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }
}
