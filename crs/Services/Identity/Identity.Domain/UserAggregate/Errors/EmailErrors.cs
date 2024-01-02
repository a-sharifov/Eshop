namespace Identity.Domain.UserAggregate.Errors;

public static class EmailErrors
{
    public static Error CannotByEmpty =>
        new("Email.CannotByEmpty", "Email cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("Email.CannotBeLongerThan", $"Email cannot be longer than {maxLength} characters");

    public static Error IsInvalid =>
        new("Email.IsInvalid", "Email is invalid");
}
