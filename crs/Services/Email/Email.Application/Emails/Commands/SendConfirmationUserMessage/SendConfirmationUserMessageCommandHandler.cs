namespace Email.Application.Emails.Commands.SendConfirmationUserMessage;

internal sealed class SendConfirmationUserMessageCommandHandler(IIdentityEmailService emailService)
    : ICommandHandler<SendConfirmationUserMessageCommand>
{
    private readonly IIdentityEmailService _emailService = emailService;
    private readonly I


    public Task<Result> Handle(SendConfirmationUserMessageCommand request, CancellationToken cancellationToken)
    {
        _emailService.SendConfirmationEmailAsync(
                       new SendConfirmationEmailRequest
                       {
                UserId = request.UserId,
                EmailConfirmationToken = request.EmailConfirmationToken,
                ReturnUrl = request.ReturnUrl,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            }, cancellationToken);
    }
}
