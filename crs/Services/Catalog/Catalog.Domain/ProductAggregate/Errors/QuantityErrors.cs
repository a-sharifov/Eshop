namespace Catalog.Domain.ProductAggregate.Errors;

public static class QuantityErrors
{
    public static Error QuantityMustBeGreaterThanZero =>
        new("Product.QuantityMustBeGreaterThanZero", "Quantity must be greater than zero");
}
