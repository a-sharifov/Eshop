namespace Catalog.Persistence.Repositories;

internal sealed class ProductRepository(
    CatalogDbContext dbContext, 
    ISqlConnectionFactory sqlConnectionFactory,
    ICachedCatalogService<Product, ProductId> cached) 
    : CatalogBaseRepository<Product, ProductId>(
        dbContext, 
        sqlConnectionFactory, 
        cached,
        expirationTime: TimeSpan.FromMinutes(20)), 
    IProductRepository
{
    public async Task<Product?> FindByNameAsync(ProductName name, CancellationToken cancellationToken = default)
    {
        using var sqlConnection = _sqlConnectionFactory.GetOpenConnection();

        string query =
            $"TOP 1" +
            $"SELECT * FROM {_entityName}" +
            $"WHERE [Name] = {name.Value}";

        var entity = await sqlConnection
            .QueryFirstOrDefaultAsync<Product>(query, cancellationToken);

        if (entity is null)
        {
            return null;
        }

        await _cached
            .SetAsync(entity, _expirationTime, cancellationToken);

        return entity;
    }
}
