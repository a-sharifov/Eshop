using Identity.Domain.UserAggregate.Enums;

namespace Identity.Application.Users.Commands.Register;

internal sealed class RegisterCommandHandler(
    IHashingService hashingService,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterCommand>
{
    private readonly IHashingService _hashingService = hashingService;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userId = new UserId(Guid.NewGuid());
        var emailResult = Email.Create(request.Email);
        var firstNameResult = FirstName.Create(request.FirstName);
        var lastNameResult = LastName.Create(request.LastName);

        var generateSalt = _hashingService.GenerateSalt();
        var passwordSaltResult = PasswordSalt.Create(generateSalt);

        var hash = _hashingService.Hash(request.Password, generateSalt);
        var passwordHashResult = PasswordHash.Create(hash);

        var user = User.Create(
            userId,
            emailResult.Value,
            firstNameResult.Value,
            lastNameResult.Value,
            passwordHashResult.Value,
            passwordSaltResult.Value,
            Enum.Parse<Role>(request.Role),
            isEmailUnique: true);

        await _userRepository.AddUserAsync(user.Value, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
