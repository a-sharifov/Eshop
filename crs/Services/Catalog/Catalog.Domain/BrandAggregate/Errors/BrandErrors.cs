namespace Catalog.Domain.BrandAggregate.Errors;

public static class BrandErrors
{
    public static Error BrandNameIsNotUnique =>
        new("Brand.BrandNameIsNotUnique", "Brand name is not unique.");

    public static Error BrandNotFound =>
        new("Brand.BrandNotFound", "Brand not found.");
}
