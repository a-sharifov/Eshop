namespace Catalog.Domain.BrandAggregate.Errors;

public static class BrandErrors
{
    public static Error BrandNameIsNotUnique =>
        new("Brand.Creator", "Brand name is not unique.");
}
