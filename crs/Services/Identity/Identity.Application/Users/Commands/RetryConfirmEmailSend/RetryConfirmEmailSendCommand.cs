namespace Identity.Application.Users.Commands.RetryConfirmEmailSend;

public sealed record RetryConfirmEmailSendCommand(
    string Email,
    string EmailConfirmPagePath,
    string ReturnUrl) : ICommand;
