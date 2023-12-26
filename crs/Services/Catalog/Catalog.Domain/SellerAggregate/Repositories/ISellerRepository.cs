using Catalog.Domain.Common.Repositories;
using Catalog.Domain.SellerAggregate;
using Catalog.Domain.SellerAggregate.Ids;
using Catalog.Domain.SellerAggregate.ValueObjects;

namespace Catalog.Domain.SellerAggregate.Repositories;

public interface ISellerRepository : ICatalogRepository<Seller, SellerId>
{
    public Task<Seller?> GetSellerByNameAsync(SellerName name, CancellationToken cancellationToken = default);
}