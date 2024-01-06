namespace Catalog.Domain.SellerAggregate.Errors;

public static class SellerNameErrors
{
    public static Error CannotBeEmpty =>
        new("Seller.CannotBeEmpty", "name cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("Seller.CannotBeLongerThan", $"name cannot be longer than {maxLength}");
}