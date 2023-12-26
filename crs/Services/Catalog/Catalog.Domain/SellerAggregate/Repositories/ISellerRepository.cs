namespace Catalog.Domain.SellerAggregate.Repositories;

public interface ISellerRepository : ICatalogRepository<Seller, SellerId>
{
    public Task<Seller?> GetSellerByNameAsync(SellerName name, CancellationToken cancellationToken = default);
}