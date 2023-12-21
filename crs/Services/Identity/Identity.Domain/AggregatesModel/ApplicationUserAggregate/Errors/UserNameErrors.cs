namespace Identity.Domain.AggregatesModel.UserAggregate.Errors;

public static class UserNameErrors
{
    public static Error CannotBeEmpty =>
        new("UserName.Creator", "User name cannot be empty.");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("UserName.Creator", $"User name cannot be longer than {maxLength} characters");
}
