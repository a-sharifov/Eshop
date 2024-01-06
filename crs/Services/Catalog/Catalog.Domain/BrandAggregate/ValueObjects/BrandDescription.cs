namespace Catalog.Domain.BrandAggregate.ValueObjects;

/// <summary>
/// Represents the description of a brand.
/// </summary>
public sealed class BrandDescription : ValueObject
{
    /// <summary>
    /// Gets the value of the brand description.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// The maximum allowed length for a brand description.
    /// </summary>
    public const int MaxLength = 1000;

    /// <summary>
    /// Initializes a new instance of the <see cref="BrandDescription"/> class.
    /// </summary>
    /// <param name="value">The description value.</param>
    private BrandDescription(string value) => Value = value;

    /// <summary>
    /// Creates a new instance of BrandDescription.
    /// </summary>
    /// <param name="value">The description value.</param>
    /// <returns>A Result containing the new BrandDescription instance if successful; otherwise, a failure result with an error message.</returns>
    public static Result<BrandDescription> Create(string value)
    {
        if (value.Length > MaxLength)
        {
            return Result.Failure<BrandDescription>(
                BrandDescriptionErrors.CannotBeLongerThan(MaxLength));
        }

        return new BrandDescription(value);
    }

    /// <summary>
    /// Returns the value for equality comparison.
    /// </summary>
    /// <returns>An enumerable containing the value for equality comparison.</returns>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
