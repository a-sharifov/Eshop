namespace Catalog.Domain.AggregatesModel.SellerAggregate.Errors;

public static class SellerNameErrors
{
    public static Error CannotBeEmpty =>
        new("Seller.Creator", "name cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("Seller.Creator", $"name cannot be longer than {maxLength}");
}