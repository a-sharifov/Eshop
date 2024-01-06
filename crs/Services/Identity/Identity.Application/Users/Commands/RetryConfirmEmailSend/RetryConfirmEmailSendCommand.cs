namespace Identity.Application.Users.Commands.RetryConfirmEmailSend;

public sealed record RetryConfirmEmailSendCommand(
    Guid UserId,
    string EmailConfirmPagePath,
    string ReturnUrl) : ICommand;
