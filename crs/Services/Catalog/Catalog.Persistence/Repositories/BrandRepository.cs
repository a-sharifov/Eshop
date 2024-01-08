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
            "TOP 1" +
            $"SELECT * FROM {_entityName}" +
            "WHERE [Name] = @BrandName";

        var parameters = new { BrandName = name.Value };

        var entity = await sqlConnection
            .QueryFirstOrDefaultAsync<Brand>(query, parameters);

        if(entity is null)
        {
            return null;
        }

        await _cached
            .SetAsync(entity, _expirationTime, cancellationToken);

        return entity;
    }

    public async Task<bool> IsBrandNameUniqueAsync(BrandName name, CancellationToken cancellationToken = default)
    {
        using var sqlConnection = _sqlConnectionFactory.GetOpenConnection();

        for (int i = 0; i < 100; i++)
        {
            await Console.Out.WriteLineAsync(_entityName);
        }

        string query =
            $"""
            SELECT COUNT(*) 
            FROM {_entityName} 
            WHERE [Name] = @BrandName
            """;

        var parameters = new { BrandName = name.Value };

        var isUnigue = !await sqlConnection
            .ExecuteScalarAsync<bool>(query, parameters);

        return isUnigue;
    }
}
