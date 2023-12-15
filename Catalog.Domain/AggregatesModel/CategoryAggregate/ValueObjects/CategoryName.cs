namespace Catalog.Domain.AggregatesModel.CategoryAggregate.ValueObjects;

public sealed class CategoryName : ValueObject
{
    public string Value { get; private set; }
    public const int MaxLength = 100;

    private CategoryName(string value) => Value = value;

    public static Result<CategoryName> Create(string value)
    {
        if (value.IsNullOrWhiteSpace())
        {
            return Result.Failure<CategoryName>(
                CategoryNameErrors.CannotBeEmpty);
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<CategoryName>(
                CategoryNameErrors.CannotBeLongerThan(MaxLength));
        }

        return new CategoryName(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}