namespace Catalog.Domain.AggregatesModel.CategoryAggregate.Errors;

public static class CategoryNameErrors
{
    public static Error CannotBeEmpty =>
        new Error("Category.Creator", "name cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new Error("Category.Creator", $"name cannot be longer than {maxLength}");
}