namespace Catalog.Domain.AggregatesModel.ProductAggregate.Repositories;

public interface IProductRepository : ICatalogRepository<Product, ProductId>
{
    public Task<Product?> FindByNameAsync(ProductName name, CancellationToken cancellationToken = default);
}