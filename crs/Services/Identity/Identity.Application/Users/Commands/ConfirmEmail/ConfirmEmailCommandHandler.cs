namespace Identity.Application.Users.Commands.ConfirmEmail;

internal sealed class ConfirmEmailCommandHandler(
    IUnitOfWork unitOfWork, 
    IUserRepository userRepository,
    IMessageBus messageBus) 
    : ICommandHandler<ConfirmEmailCommand>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMessageBus _messageBus = messageBus;

    public async Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await GetUserByIdAsync(request.UserId);

        if (user is null)
        {
            return Result.Failure(
                UserErrors.UserDoesNotExist);
        }

        var requestEmailConfirmationTokenResult =
            EmailConfirmationToken.Create(request.EmailConfirmationToken);

        var confirmEmailResult = user.ConfirmEmail(
            requestEmailConfirmationTokenResult.Value);

        if (confirmEmailResult.IsFailure)
        {
            return Result.Failure(
                confirmEmailResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _messageBus.Publish(
            new IdentityVerificationConfirmedEvent(Guid.NewGuid(), user.Id.Value));

        return Result.Success();
    }

    private async Task<User?> GetUserByIdAsync(Guid id)
    {
        var userId = new UserId(id);
        return await _userRepository.GetUserByIdAsync(userId);
    }
}
