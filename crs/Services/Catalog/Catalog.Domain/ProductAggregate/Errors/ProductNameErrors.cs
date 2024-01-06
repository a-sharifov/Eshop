namespace Catalog.Domain.ProductAggregate.Errors;

public static class ProductNameErrors
{
    public static Error CannotBeEmpty =>
        new("Product.CannotBeEmpty", "name cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("Product.CannotBeLongerThan", $"name cannot be longer than {maxLength}");
}