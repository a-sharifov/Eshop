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
            context.Message.ReturnUrl,
            context.Message.ConfirmationEmailToken);

        await _sender.Send(request);
    }
}
