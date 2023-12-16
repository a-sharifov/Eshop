// -----------------------------------------------------------------------
// <copyright file="ProductName.cs" company="Akber">
// Copyright (c) Akber. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Catalog.Domain.AggregatesModel.ProductAggregate.ValueObjects;

/// <summary>
/// Product name value object.
/// </summary>
public class ProductName : ValueObject
{
    /// <summary>
    /// Gets value of the product name.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Product name max length.
    /// </summary>
    public const int ProductNameMaxLength = 100;

    private ProductName(string value) => this.Value = value;

    /// <summary>
    /// Creates new instance of the <see cref="ProductName"/> class.
    /// </summary>
    /// <param name="value">value of the product name.</param>
    /// <returns>
    /// if is valid returns <see cref="Result.Success{T}"/> with <see cref="ProductName"/> value.
    /// else returns <see cref="Result.Failure{T}"/> with <see cref="ProductNameErrors"/> error.
    /// </returns>
    public static Result<ProductName> Create(string value)
    {
        if (value.IsNullOrWhiteSpace())
        {
            return Result.Failure<ProductName>(
                ProductNameErrors.CannotBeEmpty);
        }

        if (value.Length > ProductNameMaxLength)
        {
            return Result.Failure<ProductName>(
                ProductNameErrors.CannotBeLongerThan(ProductNameMaxLength));
        }

        return new ProductName(value);
    }

    /// <summary>Gets equality components.</summary>
    /// <returns></returns>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}