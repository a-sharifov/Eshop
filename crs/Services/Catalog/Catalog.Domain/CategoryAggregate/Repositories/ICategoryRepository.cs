namespace Catalog.Domain.CategoryAggregate.Repositories;

public interface ICategoryRepository : ICatalogRepository<Category, CategoryId>
{
    Task<Category?> GetCategoryByNameAsync(CategoryName name, CancellationToken cancellationToken = default);
    Task<bool> IsCategoryNameUniqueAsync(CategoryName name, CancellationToken cancellationToken = default);
}