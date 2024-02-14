namespace Identity.Application.Users.Commands.UpdateRefreshToken;

internal sealed class UpdateRefreshTokenCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IJwtProvider jwtProvider) :
    ICommandHandler<UpdateRefreshTokenCommand, UpdateRefreshTokenCommandResponse>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Result<UpdateRefreshTokenCommandResponse>> Handle(UpdateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var emailString = _jwtProvider.GetEmailFromToken(request.Token);
        var emailResult = Email.Create(emailString);

        var user = await _userRepository.GetUserByEmailAsync(emailResult.Value, cancellationToken);

        if (user is null ||
            user.RefreshToken?.Token != request.RefreshToken)
        {
            return Result.Failure<UpdateRefreshTokenCommandResponse>(
                UserErrors.RefreshTokenIsNotExists);
        }

        if(user.RefreshToken.IsExpired)
        {
            return Result.Failure<UpdateRefreshTokenCommandResponse>(
                UserErrors.RefreshTokenIsExpired);
        }

        var refreshToken = _jwtProvider.CreateRefreshToken();
        var userToken = _jwtProvider.CreateTokenString(user, request.Audience);

        user.UpdateRefreshToken(refreshToken);

        _userRepository.UpdateUser(user);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new UpdateRefreshTokenCommandResponse(userToken, refreshToken.Token);
    }
}
