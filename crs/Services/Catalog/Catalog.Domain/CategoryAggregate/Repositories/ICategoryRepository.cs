namespace Catalog.Domain.CategoryAggregate.Repositories;

public interface ICategoryRepository : ICatalogRepository<Category, CategoryId>
{
    public Task<Category?> GetCategoryByNameAsync(CategoryName name, CancellationToken cancellationToken = default);
    public Task<bool> IsCategoryNameUniqueAsync(CategoryName name, CancellationToken cancellationToken = default);
}