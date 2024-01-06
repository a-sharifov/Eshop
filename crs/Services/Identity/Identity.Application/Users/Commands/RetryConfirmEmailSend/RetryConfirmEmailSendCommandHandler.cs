namespace Identity.Application.Users.Commands.RetryConfirmEmailSend;

public class RetryConfirmEmailSendCommandHandler(
    IUserRepository userRepository, 
    IIdentityEmailService emailService, 
    IUnitOfWork unitOfWork)
    : ICommandHandler<RetryConfirmEmailSendCommand>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IIdentityEmailService _emailService = emailService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(RetryConfirmEmailSendCommand request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.UserId);
        var user = await _userRepository.GetUserByIdAsync(userId);

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

        await _emailService.SendConfirmationEmailAsync(
            user,
            request.EmailConfirmPagePath,
            request.ReturnUrl,
            cancellationToken);

        return Result.Success();
    }
}
