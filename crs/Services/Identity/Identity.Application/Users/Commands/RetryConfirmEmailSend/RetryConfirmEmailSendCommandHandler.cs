namespace Identity.Application.Users.Commands.RetryConfirmEmailSend;

public class RetryConfirmEmailSendCommandHandler(
    IUserRepository userRepository, 
    IIdentityEmailService emailService)
    : ICommandHandler<RetryConfirmEmailSendCommand>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IIdentityEmailService _emailService = emailService;

    public async Task<Result> Handle(RetryConfirmEmailSendCommand request, CancellationToken cancellationToken)
    {
        var emailResult = Email.Create(request.Email);
        var user = await _userRepository
            .GetUserByEmailAsync(emailResult.Value, cancellationToken);

        if (user is null)
        {
            return Result.Failure(
                UserErrors.UserDoesNotExist);
        }

        var confirmationEmailToken = _emailService.CreateConfirmationEmailToken();

        var RetryEmailConfirmationResult =
            user.RetryEmailConfirmation(confirmationEmailToken);

        if (RetryEmailConfirmationResult.IsFailure)
        {
            return Result.Failure(
                RetryEmailConfirmationResult.Error);
        }

        //await _emailService.SendConfirmationEmailAsync(
        //    user,
        //    request.EmailConfirmPagePath,
        //    request.ReturnUrl,
        //    cancellationToken);

        return Result.Success();
    }
}
