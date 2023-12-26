namespace Identity.Domain.UserAggregate.Errors;

public static class PasswordSaltError
{
    public static Error PasswordSaltIsInvalid(string passwordSalt) =>
        new Error("PasswordSalt.Creator",
            $"Password salt '{passwordSalt}' is invalid.");

    public static Error CannotBeEmpty =>
        new Error("PasswordSalt.Creator",
            "Password salt cannot be empty.");

    public static Error TooShort =>
        new Error("PasswordSalt.Creator",
            "Password salt is too short.");
}
