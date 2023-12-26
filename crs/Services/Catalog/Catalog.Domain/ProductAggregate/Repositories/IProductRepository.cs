using Catalog.Domain.Common.Repositories;
using Catalog.Domain.ProductAggregate;
using Catalog.Domain.ProductAggregate.Ids;
using Catalog.Domain.ProductAggregate.ValueObjects;

namespace Catalog.Domain.ProductAggregate.Repositories;

public interface IProductRepository : ICatalogRepository<Product, ProductId>
{
    public Task<Product?> FindByNameAsync(ProductName name, CancellationToken cancellationToken = default);
}