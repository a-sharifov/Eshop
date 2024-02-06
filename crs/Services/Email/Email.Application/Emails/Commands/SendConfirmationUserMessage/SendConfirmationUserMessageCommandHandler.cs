using Email.Infrastructure.Email.Models;
using Email.Infrastructure.Grpc.Idenitty;

namespace Email.Application.Emails.Commands.SendConfirmationUserMessage;

internal sealed class SendConfirmationUserMessageCommandHandler(
    IIdentityEmailService emailService,
    IIdentityGrpcService identityGrpcService)
    : ICommandHandler<SendConfirmationUserMessageCommand>
{
    private readonly IIdentityEmailService _emailService = emailService;
    private readonly IIdentityGrpcService _identityGrpcService = identityGrpcService;

    public async Task<Result> Handle(SendConfirmationUserMessageCommand request, CancellationToken cancellationToken)
    {
        var userInfo = await _identityGrpcService.GetUserInfoAsync(request.UserId, cancellationToken);

        var emailRequest = new SendConfirmationEmailRequest(
            userInfo.FirstName,
            userInfo.LastName,
            userInfo.UserId,
            userInfo.Email,
            request.ConfirmationEmailToken,
            request.ReturnUrl);

        await _emailService.SendConfirmationEmailAsync(emailRequest, cancellationToken);

        return Result.Success();
    }
}
