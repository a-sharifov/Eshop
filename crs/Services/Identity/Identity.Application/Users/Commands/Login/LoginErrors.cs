namespace Identity.Application.Users.Commands.Login;

internal static class LoginErrors
{
    public static Error UserDoesNotExist => new Error(
        "LoginCommand.Handle",
        "User does not exist."
        );
}
