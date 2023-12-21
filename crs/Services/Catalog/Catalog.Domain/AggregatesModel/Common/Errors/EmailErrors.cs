namespace Catalog.Domain.AggregatesModel.Common.Errors;

public static class EmailErrors
{
    public static Error CannotByEmpty =>
        new("Email.Creator", "Email cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("Email.Creator", $"Email cannot be longer than {maxLength} characters");

    public static Error IsInvalid =>
        new("Email.Creator", "Email is invalid");
}
