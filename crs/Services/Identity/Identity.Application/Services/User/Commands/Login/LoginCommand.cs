namespace Identity.Application.Services.User.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password)
    : ICommand<string>;
