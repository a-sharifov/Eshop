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
        var email = Email.Create(request.Email);
        var user = await _userRepository.GetUserByEmailAsync(email.Value);

        if (user is null)
        {
            return Result.Failure<LoginCommanResponse>(
                UserErrors.UserDoesNotExist);
        }

        var passwordIsCorrect = _hashingService.Verify(
            request.Password, user.PasswordSalt.Value, user.PasswordHash.Value);

        var loginUser = User.Login(user, passwordIsCorrect);

        if (loginUser.IsFailure)
        {
            return Result.Failure<LoginCommanResponse>(
                loginUser.Error);
        }

        var refreshToken = _jwtProvider.CreateRefreshToken();

        loginUser.Value.UpdateRefreshToken(refreshToken.Value);
        var userToken = _jwtProvider.CreateTokenString(loginUser.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new LoginCommanResponse(userToken, refreshToken.Value.Token);
    }
}
