namespace Catalog.Domain.AggregatesModel.SellerAggregate.Repositories;

public interface ISellerRepository : ICatalogRepository<Seller, SellerId>
{
    public Task<Seller?> GetSellerByNameAsync(SellerName name, CancellationToken cancellationToken = default);
}