namespace Identity.Domain.UserAggregate.Errors;

public static class PasswordHashErrors
{
    public static Error CannotBeEmpty =>
        new("PasswordHash.Creator", "Password cannot be empty");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("PasswordHash.Creator", $"Password cannot be longer than {maxLength} characters");

    public static Error CannotBeShorterThan(int minLength) =>
        new("PasswordHash.Creator", $"Password cannot be shorter than {minLength} characters");
}
