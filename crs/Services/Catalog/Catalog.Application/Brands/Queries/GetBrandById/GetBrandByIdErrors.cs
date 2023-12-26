namespace Catalog.Application.Brands.Queries.GetBrandById;

internal static class GetBrandByIdErrors
{
    public static Error BrandNotFound =>
        new Error(
            "GetBrandById.Handle",
            $"Brand not found.");
}