namespace Catalog.Domain.AggregatesModel.Common.Errors;

public static class EmailErrors
{
    public static Error CannotByEmpty =>
        new Error("Email.Creator", "Email cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new Error("Email.Creator", $"Email cannot be longer than {maxLength} characters");

    public static Error IsInvalid =>
        new Error("Email.Creator", "Email is invalid");
}