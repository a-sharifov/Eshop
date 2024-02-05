namespace Email.Application.Emails.Commands.SendConfirmationUserMessage;

public sealed record SendConfirmationUserMessageCommand(Guid UserId, string ReturnUrl) : ICommand;
