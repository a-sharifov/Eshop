namespace Catalog.Domain.SellerAggregate.Repositories;

public interface ISellerRepository : ICatalogRepository<Seller, SellerId>
{
    Task<Seller?> GetSellerByNameAsync(SellerName name, CancellationToken cancellationToken = default);
}