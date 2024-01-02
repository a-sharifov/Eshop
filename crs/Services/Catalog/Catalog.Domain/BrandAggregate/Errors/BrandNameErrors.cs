namespace Catalog.Domain.BrandAggregate.Errors;

/// <summary>
/// Error messages related to brand names.
/// </summary>
public static class BrandNameErrors
{
    /// <summary>
    /// Gets an error indicating that a brand name cannot be empty.
    /// </summary>
    public static Error CannotBeEmpty =>
        new("Brand.CannotBeEmpty", "Name cannot be empty.");

    /// <summary>
    /// Creates an error indicating that a brand name cannot be longer than a specified maximum length.
    /// </summary>
    /// <param name="maxLength">The maximum allowed length for the brand name.</param>
    /// <returns>An error instance specifying the length constraint.</returns>
    public static Error CannotBeLongerThan(int maxLength) =>
        new("Brand.CannotBeLongerThan", $"Name cannot be longer than {maxLength} characters.");
}
