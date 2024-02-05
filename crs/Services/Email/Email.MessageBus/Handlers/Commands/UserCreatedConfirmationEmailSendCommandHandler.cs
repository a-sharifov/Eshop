namespace Email.MessageBus.Handlers.Commands;

public sealed class UserCreatedConfirmationEmailSendCommandHandler
    : IntegrationCommandHandler<UserCreatedConfirmationEmailSendCommand>
{
    public override Task Handle(ConsumeContext<UserCreatedConfirmationEmailSendCommand> context)
    {
        throw new NotImplementedException();
    }
}
