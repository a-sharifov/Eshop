namespace Basket.Domain.CatalogBasketAggregate.ValueObjects;

public static class CatalogProductNameErrors
{
    public static Error CannotBeEmpty =>
        new("CatalogProductName.CannotBeEmpty", "name cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("CatalogProductName.CannotBeLongerThan", $"name cannot be longer than {maxLength}");
}