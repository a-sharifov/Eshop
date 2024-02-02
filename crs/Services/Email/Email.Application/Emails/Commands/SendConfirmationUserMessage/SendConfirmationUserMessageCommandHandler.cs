namespace Email.Application.Emails.Commands.SendConfirmationUserMessage;

internal sealed class SendConfirmationUserMessageCommandHandler(IEmailService emailService)
    : ICommandHandler<SendConfirmationUserMessageCommand>
{
    private readonly IEmailService _emailService = emailService;

    public Task<Result> Handle(SendConfirmationUserMessageCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
