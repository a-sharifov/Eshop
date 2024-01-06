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
        var claims = _jwtProvider.GetClaimsInToken(request.Token);

        var emailString = claims.First(x => 
        x.Type == JwtRegisteredClaimNames.Email).Value;

        var email = Email.Create(emailString);

        var user = await _userRepository.GetUserByEmailAsync(email.Value, cancellationToken);

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

        var refreshTokenResult = _jwtProvider.CreateRefreshToken();
        var userToken = _jwtProvider.CreateTokenString(user);

        user.UpdateRefreshToken(refreshTokenResult.Value);

        _userRepository.UpdateUser(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateRefreshTokenCommandResponse(userToken, refreshTokenResult.Value.Token);
    }
}
