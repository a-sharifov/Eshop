namespace Identity.Application.Users.Commands.RetryConfirmEmailSend;

public class RetryConfirmEmailSendCommandHandler(
    IUserRepository userRepository,
    IMessageBus messageBus,
    IHashingService hashingService)
    : ICommandHandler<RetryConfirmEmailSendCommand>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IHashingService _hashingService = hashingService;
    private readonly IMessageBus _messageBus = messageBus;

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

        var confirmationEmailToken = _hashingService.GenerateToken();

        var RetryEmailConfirmationResult =
            user.RetryEmailConfirmation(confirmationEmailToken);

        if (RetryEmailConfirmationResult.IsFailure)
        {
            return Result.Failure(
                RetryEmailConfirmationResult.Error);
        }

        await _messageBus.Send(new UserCreatedConfirmationEmailSendCommand(
            Guid.NewGuid(),
            user.Id.Value,
            confirmationEmailToken,
            request.ReturnUrl),
            cancellationToken);

        return Result.Success();
    }
}
