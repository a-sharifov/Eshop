﻿namespace Catalog.Domain.Common.Errors;

public static class MoneyErrors
{
    public static Error CannotBeNegative =>
        new("Money.CannotBeNegative", "Money cannot be negative");

    public static Error CannotBeEmpty =>
        new("Money.CannotBeEmpty", "Money cannot be empty");
}