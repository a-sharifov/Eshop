namespace Catalog.Domain.Common.Errors;

public static class MoneyErrors
{
    public static Error CannotBeNegative =>
        new Error("Money.CannotBeNegative", "Money cannot be negative");

    public static Error CannotBeEmpty =>
        new Error("Money.CannotBeEmpty", "Money cannot be empty");
}