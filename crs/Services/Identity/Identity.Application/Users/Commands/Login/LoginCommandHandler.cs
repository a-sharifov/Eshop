using Identity.Domain.UserAggregate;
using Identity.Domain.UserAggregate.Repositories;
using Identity.Domain.UserAggregate.ValueObjects;

namespace Identity.Application.Users.Commands.Login;

internal sealed class LoginCommandHandler(
    IUserRepository userRepository,
    IHashingService hashingService,
    IJwtProvider jwtProvider)
    : ICommandHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IHashingService _hashingService = hashingService;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var email = Email.Create(request.Email);
        var userExists = await _userRepository.IsUserExistsAsync(email.Value);

        if (!userExists)
        {
            return Result.Failure<string>(
                LoginErrors.UserDoesNotExist);
        }

        var user = await _userRepository.GetUserByEmailAsync(email.Value);
        var passwordIsCorrect = _hashingService.Verify(
            request.Password, user.PasswordSalt.Value, user.PasswordHash.Value);

        var loginUser = User.Login(user, passwordIsCorrect);

        var userToken = _jwtProvider.CreateToken(loginUser.Value);
        return userToken;
    }
}
