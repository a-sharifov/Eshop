using Email.Application.Emails.Commands.SendConfirmationUserMessage;

namespace Email.MessageBus.Handlers.Commands;

internal sealed class UserCreatedConfirmationEmailSendCommandHandler(ISender sender)
        : IntegrationCommandHandler<UserCreatedConfirmationEmailSendCommand>
{
    private readonly ISender _sender = sender;

    public override async Task Handle(ConsumeContext<UserCreatedConfirmationEmailSendCommand> context)
    {
        var request = new SendConfirmationUserMessageCommand(
            context.Message.UserId,
            context.Message.ReturnUrl);

        var result = await _sender.Send(request);

        if (result.IsFailure)
        {
            throw new Exception(result.Error);
        }
    }
}
