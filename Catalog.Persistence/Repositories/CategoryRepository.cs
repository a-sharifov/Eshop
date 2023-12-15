namespace Catalog.Persistence.Repositories;

internal sealed class CategoryRepository(
    CatalogDbContext dbContext, 
    ISqlConnectionFactory sqlConnectionFactory,
    ICachedCatalogService<Category, CategoryId> cached) 
    : CatalogBaseRepository<Category, CategoryId>(
        dbContext, 
        sqlConnectionFactory, 
        cached, 
        expirationTime: TimeSpan.FromMinutes(20)), 
    ICategoryRepository
{
    public async Task<Category?> GetCategoryByNameAsync(CategoryName name, CancellationToken cancellationToken = default)
    {
        using var sqlConnection = _sqlConnectionFactory.GetOpenConnection();

        string query =
            $"TOP 1" +
            $"SELECT * FROM {_entityName}" +
            $"WHERE [Name] = {name.Value}";

        var entity = await sqlConnection
           .QueryFirstOrDefaultAsync<Category>(query, cancellationToken);

        if (entity is null)
        {
            return null;
        }

        await _cached
            .SetAsync(entity, _expirationTime, cancellationToken);

        return entity;
    }
}
