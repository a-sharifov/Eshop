namespace Identity.Application.Users.Commands.DeleteUser;

internal sealed class DeleteUserCommandHandler(
    IUserRepository userRepository) 
    : ICommandHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.UserId);

        var isExists = await _userRepository.IsUserExistsAsync(userId, cancellationToken);

        if (!isExists)
        {
            return Result.Failure(
                UserErrors.UserDoesNotExist);
        }

        await _userRepository.DeleteUserAsync(userId, cancellationToken);

        return Result.Success();
    }
}
