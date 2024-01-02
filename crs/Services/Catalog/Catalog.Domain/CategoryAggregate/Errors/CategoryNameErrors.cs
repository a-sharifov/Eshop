namespace Catalog.Domain.CategoryAggregate.Errors;

public static class CategoryNameErrors
{
    public static Error CannotBeEmpty =>
        new("Category.CannotBeEmpty", "name cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("Category.CannotBeLongerThan", $"name cannot be longer than {maxLength}");
}