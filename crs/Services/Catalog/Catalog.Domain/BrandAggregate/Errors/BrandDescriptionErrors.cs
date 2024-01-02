namespace Catalog.Domain.BrandAggregate.Errors;

/// <summary>
/// Error messages related to brand descriptions.
/// </summary>
public static class BrandDescriptionErrors
{
    /// <summary>
    /// Creates an error indicating that a brand description cannot be longer than a specified maximum length.
    /// </summary>
    /// <param name="maxLength">The maximum allowed length for the brand description.</param>
    /// <returns>An error instance specifying the length constraint.</returns>
    public static Error CannotBeLongerThan(int maxLength) =>
        new("Brand.CannotBeLongerThan", $"name cannot be longer than {maxLength}");
}
