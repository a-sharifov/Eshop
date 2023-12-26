namespace Catalog.Domain.ProductAggregate.Errors;

public static class SkuErrors
{
    public static Error CannotBeEmpty =>
        new("Sku.Creator", "Sku cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("Sku.Creator", $"Sku cannot be longer than {maxLength} characters");
}