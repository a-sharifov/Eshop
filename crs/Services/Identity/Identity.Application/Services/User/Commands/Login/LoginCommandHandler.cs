namespace Identity.Application.Services.User.Commands.Login;

internal sealed class LoginCommandHandler(
    IUserRepository userRepository, 
    IJwtProvider jwtProvider)
    : ICommandHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var email = Email.Create(request.Email);

        var user = await _userRepository.GetUserByEmailAsync(email.Value);

        var checkPassword = await _userRepository
            .CheckPasswordAsync(user, request.Password, cancellationToken);
        
        //if (!checkPassword)
        //{
        //    return Result.Failure<string>(
        //        LoginErrors.InvalidCredentials);
        //}

        //if (!user.IsEmailConfirmed)
        //{
        //    return Result.Failure<string>(
        //        LoginErrors.EmailNotConfirmed);
        //}

        string token = _jwtProvider.CreateToken(user);

        return token;
    }
}