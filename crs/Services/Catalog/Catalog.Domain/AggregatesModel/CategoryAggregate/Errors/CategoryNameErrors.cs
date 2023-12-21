namespace Catalog.Domain.AggregatesModel.CategoryAggregate.Errors;

public static class CategoryNameErrors
{
    public static Error CannotBeEmpty =>
        new("Category.Creator", "name cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("Category.Creator", $"name cannot be longer than {maxLength}");
}