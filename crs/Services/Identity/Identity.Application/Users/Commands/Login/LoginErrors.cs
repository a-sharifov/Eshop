namespace Identity.Application.Users.Commands.Login;

internal static class LoginErrors
{
    public static Error UserDoesNotExist => new Error(
        "LoginErrors.UserDoesNotExist",
        "User does not exist."
        );
}
