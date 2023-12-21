namespace Catalog.Domain.AggregatesModel.ProductAggregate.Errors;

public static class ProductDescriptionErrors
{
    public static Error CannotBeLongerThan(int maxLength) =>
        new("Product.Creator", $"name cannot be longer than {maxLength}");
}