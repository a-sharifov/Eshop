namespace Identity.Domain.UserAggregate.Errors;

public static class PasswordSaltError
{
    public static Error PasswordSaltIsInvalid(string passwordSalt) =>
        new Error("PasswordSalt.PasswordSaltIsInvalid", $"Password salt '{passwordSalt}' is invalid.");

    public static Error CannotBeEmpty =>
        new Error("PasswordSalt.CannotBeEmpty", "Password salt cannot be empty.");

    public static Error TooShort =>
        new Error("PasswordSalt.TooShort", "Password salt is too short.");
}
