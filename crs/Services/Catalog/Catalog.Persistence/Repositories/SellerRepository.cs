namespace Catalog.Persistence.Repositories;

internal sealed class SellerRepository(
    CatalogDbContext dbContext,
    ISqlConnectionFactory sqlConnectionFactory,
    ICachedCatalogService<Seller, SellerId> cached) 
    : CatalogBaseRepository<Seller, SellerId>(
        dbContext, 
        sqlConnectionFactory, 
        cached, 
        expirationTime: TimeSpan.FromMinutes(60)), 
    ISellerRepository
{
    public async Task<Seller?> GetSellerByNameAsync(SellerName name, CancellationToken cancellationToken = default)
    {
        using var sqlConnection = _sqlConnectionFactory.GetOpenConnection();

        string query =
            "TOP 1" +
            $"SELECT * FROM {_entityName}" +
            "WHERE [Name] = @SellerName";

        var parameters = new { SellerName = name.Value };

        var entity = await sqlConnection
          .QueryFirstOrDefaultAsync<Seller>(query, cancellationToken);

        if (entity is null)
        {
            return null;
        }

        await _cached
            .SetAsync(entity, _expirationTime, cancellationToken);

        return entity;
    }
}
