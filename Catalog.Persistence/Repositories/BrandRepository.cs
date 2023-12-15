namespace Catalog.Persistence.Repositories;

internal sealed class BrandRepository(
    CatalogDbContext dbContext, 
    ISqlConnectionFactory sqlConnectionFactory,
    ICachedCatalogService<Brand, BrandId> cached) 
    : CatalogBaseRepository<Brand, BrandId>(
        dbContext, 
        sqlConnectionFactory, 
        cached, 
        expirationTime: TimeSpan.FromMinutes(20)), 
    IBrandRepository
{
    public async Task<Brand?> GetBrandByNameAsync(BrandName name, CancellationToken cancellationToken = default)
    {
        using var sqlConnection = _sqlConnectionFactory.GetOpenConnection();

        string query =
            $"TOP 1" +
            $"SELECT * FROM {_entityName}" +
            $"WHERE [Name] = {name.Value}";

        var entity = await sqlConnection
            .QueryFirstOrDefaultAsync<Brand>(query, cancellationToken);

        if(entity is null)
        {
            return null;
        }

        await _cached
            .SetAsync(entity, _expirationTime, cancellationToken);

        return entity;
    }
}
