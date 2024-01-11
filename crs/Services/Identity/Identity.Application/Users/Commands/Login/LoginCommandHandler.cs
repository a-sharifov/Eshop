namespace Identity.Application.Users.Commands.Login;

internal sealed class LoginCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IHashingService hashingService,
    IJwtProvider jwtProvider)
    : ICommandHandler<LoginCommand, LoginCommanResponse>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHashingService _hashingService = hashingService;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Result<LoginCommanResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await GetUserByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<LoginCommanResponse>(
                UserErrors.UserDoesNotExist);
        }

        var loginResult = Login(user, request.Password);

        if (loginResult.IsFailure)
        {
            return Result.Failure<LoginCommanResponse>(
                loginResult.Error);
        }

        var refreshToken = _jwtProvider.CreateRefreshToken().Value;

        user.UpdateRefreshToken(refreshToken);
        var userToken = _jwtProvider.CreateTokenString(user, request.Audience);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new LoginCommanResponse(userToken, refreshToken.Token);
    }

    private async Task<User?> GetUserByEmailAsync(string emailString, CancellationToken cancellationToken = default)
    {
        var emailResult = Email.Create(emailString);
        return await _userRepository.GetUserByEmailAsync(emailResult.Value, cancellationToken);
    }

    private Result Login(User user ,string password)
    {
        var passwordIsCorrect = _hashingService.Verify(
            password, user.PasswordSalt.Value, user.PasswordHash.Value);

        return User.Login(user, passwordIsCorrect);
    }
}
