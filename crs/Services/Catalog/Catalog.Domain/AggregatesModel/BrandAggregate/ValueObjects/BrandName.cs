using System.Runtime.CompilerServices;

namespace Catalog.Domain.AggregatesModel.BrandAggregate.ValueObjects;

/// <summary>
/// Represents the name of a brand.
/// </summary>
public sealed class BrandName : ValueObject
{
    /// <summary>
    /// Gets the value of the brand name.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// The maximum allowed length for a brand name.
    /// </summary>
    public const int MaxLength = 100;

    /// <summary>
    /// Initializes a new instance of the <see cref="BrandName"/> class.
    /// </summary>
    /// <param name="value">The name value.</param>
    private BrandName(string value) => Value = value;

    /// <summary>
    /// Creates a new instance of BrandName.
    /// </summary>
    /// <param name="value">The name value.</param>
    /// <returns>A Result containing the new BrandName instance if successful; otherwise, a failure result with an error message.</returns>
    public static Result<BrandName> Create(string value)
    {
        if (value.IsNullOrWhiteSpace())
        {
            return Result.Failure<BrandName>(
                BrandNameErrors.CannotBeEmpty);
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<BrandName>(
                BrandNameErrors.CannotBeLongerThan(MaxLength));
        }

        return new BrandName(value);
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
