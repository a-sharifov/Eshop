namespace Identity.Domain.UserAggregate.Errors;

public static class PasswordHashErrors
{
    public static Error CannotBeEmpty =>
        new("PasswordHash.CannotBeEmpty", "Password cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("PasswordHash.CannotBeLongerThan", $"Password cannot be longer than {maxLength} characters");

    public static Error CannotBeShorterThan(int minLength) =>
        new("PasswordHash.CannotBeShorterThan", $"Password cannot be shorter than {minLength} characters");
}
