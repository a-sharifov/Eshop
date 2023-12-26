namespace Catalog.Domain.SellerAggregate.Errors;

public static class SellerErrors
{
    public static Error SellerNameIsNotUnique(string sellerName) =>
        new("Seller.Creator", $"Seller name {sellerName} is not unique.");
}
