namespace Basket.Domain.BasketAggregate.ValueObjects;

/// <summary>
/// Catalog product name value object.
/// </summary>
public class CatalogProductName : ValueObject
{
    /// <summary>
    /// Gets value of the catalog product name.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Catalog product name max length.
    /// </summary>
    public const int CatalogProductNameMaxLength = 100;

    private CatalogProductName(string value) => Value = value;

    /// <summary>
    /// Creates new instance of the <see cref="CatalogProductName"/> class.
    /// </summary>
    /// <param name="value">value of the product name.</param>
    /// <returns>
    /// if is valid returns <see cref="Result.Success{T}"/> with <see cref="CatalogProductName"/> value.
    /// else returns <see cref="Result.Failure{T}"/> with <see cref="ProductNameErrors"/> error.
    /// </returns>
    public static Result<CatalogProductName> Create(string value)
    {
        if (value.IsNullOrWhiteSpace())
        {
            return Result.Failure<CatalogProductName>(
                CatalogProductNameErrors.CannotBeEmpty);
        }

        if (value.Length > CatalogProductNameMaxLength)
        {
            return Result.Failure<CatalogProductName>(
                CatalogProductNameErrors.CannotBeLongerThan(CatalogProductNameMaxLength));
        }

        return new CatalogProductName(value);
    }

    /// <summary>Gets equality components.</summary>
    /// <returns></returns>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}