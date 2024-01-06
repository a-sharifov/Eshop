namespace Catalog.Domain.CategoryAggregate.Errors;

public static class CategoryErrors
{
    public static Error CategoryNameIsNotUnique =>
        new("Category.CategoryNameIsNotUnique", "Category name is not unique.");
}