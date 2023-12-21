namespace Identity.Domain.AggregatesModel.UserAggregate.Errors;

public static class FirstNameErrors
{
    public static Error CannotBeEmpty => 
        new("FirstName.Creator", "First name cannot be empty.");

    public static Error CannotBeLongerThan(int maxLength) => 
        new("FirstName.Creator", $"First name cannot be longer than {maxLength} characters");
}