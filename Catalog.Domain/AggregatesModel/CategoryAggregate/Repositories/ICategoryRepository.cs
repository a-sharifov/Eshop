﻿namespace Catalog.Domain.AggregatesModel.CategoryAggregate.Repositories;

public interface ICategoryRepository : ICatalogRepository<Category, CategoryId>
{
    public Task<Category?> GetCategoryByNameAsync(CategoryName name, CancellationToken cancellationToken = default);
}