namespace Catalog.Domain.AggregatesModel.ProductAggregate.Errors;

public static class SkuErrors
{
    public static Error CannotBeEmpty =>
        new Error("Sku.Creator", "Sku cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new Error("Sku.Creator", $"Sku cannot be longer than {maxLength} characters");
}