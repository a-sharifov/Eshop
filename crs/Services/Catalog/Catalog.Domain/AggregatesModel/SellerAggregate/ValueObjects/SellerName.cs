// -----------------------------------------------------------------------
// <copyright file="SellerName.cs" company="Akber">
// Copyright (c) Akber. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Catalog.Domain.AggregatesModel.SellerAggregate.ValueObjects;

/// <summary>
/// Seller name value object.
/// </summary>
public sealed class SellerName : ValueObject
{
    /// <summary>
    /// Gets value of the seller name.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Max length of the seller name.
    /// </summary>
    public const int MaxLength = 100;

    private SellerName(string value) => this.Value = value;


    /// <summary>
    /// Creates new instance of the <see cref="SellerName"/> class.
    /// </summary>
    /// <param name="value">value of the seller name.</param>
    /// <returns>
    /// if is valid returns <see cref="Result.Success{T}"/> with <see cref="SellerName"/> value.
    /// else returns <see cref="Result.Failure{T}"/> with <see cref="SellerNameErrors"/> error.
    /// </returns>
    public static Result<SellerName> Create(string value)
    {
        if (value.IsNullOrWhiteSpace())
        {
            return Result.Failure<SellerName>(
                SellerNameErrors.CannotBeEmpty);
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<SellerName>(
                SellerNameErrors.CannotBeLongerThan(MaxLength));
        }

        return new SellerName(value);
    }

    /// <summary>Gets equality components.</summary>
    /// <returns>
    /// returns value of the seller name.
    /// if value is null returns empty string.
    /// </returns>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}