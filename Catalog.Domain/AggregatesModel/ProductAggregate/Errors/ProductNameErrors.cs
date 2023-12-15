namespace Catalog.Domain.AggregatesModel.ProductAggregate.Errors;

public static class ProductNameErrors
{
    public static Error CannotBeEmpty =>
        new Error("Product.Creator", "name cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new Error("Product.Creator", $"name cannot be longer than {maxLength}");
}