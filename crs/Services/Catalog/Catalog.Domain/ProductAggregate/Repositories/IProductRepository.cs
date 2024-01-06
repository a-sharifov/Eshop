namespace Catalog.Domain.ProductAggregate.Repositories;

public interface IProductRepository : ICatalogRepository<Product, ProductId>
{
    Task<Product?> FindByNameAsync(ProductName name, CancellationToken cancellationToken = default);
}