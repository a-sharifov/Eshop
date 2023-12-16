namespace Catalog.Domain.AggregatesModel.Common.Errors;

public static class MoneyErrors
{
    public static Error CannotBeNegative =>
        new Error("Money.Creator", "Money cannot be negative");

    public static Error CannotBeEmpty =>
        new Error("Money.Creator", "Money cannot be empty");
}