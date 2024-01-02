namespace Identity.Application.Users.Commands.Register;

internal sealed class RegisterCommandHandler(
    IHashingService hashingService,
    IIdentityEmailService emailService,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterCommand>
{
    private readonly IHashingService _hashingService = hashingService;
    private readonly IIdentityEmailService _emailService = emailService;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = await CreateUser(request);

        if (user.IsFailure)
        {
            return Result.Failure(user.Error);
        }

        await _userRepository.AddUserAsync(user.Value, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //await _emailService.SendConfirmationEmailAsync(user.Value, cancellationToken);

        return Result.Success();
    }

    private async Task<Result<User>> CreateUser(
        RegisterCommand request , 
        CancellationToken cancellationToken = default)
    {
        var userId = new UserId(Guid.NewGuid());
        var emailResult = Email.Create(request.Email);
        var firstNameResult = FirstName.Create(request.FirstName);
        var lastNameResult = LastName.Create(request.LastName);

        var generateSalt = _hashingService.GenerateSalt();
        var passwordSaltResult = PasswordSalt.Create(generateSalt);

        var hash = _hashingService.Hash(request.Password, generateSalt);
        var passwordHashResult = PasswordHash.Create(hash);

        var isEmailUnique = await _userRepository
            .IsEmailUnigueAsync(emailResult.Value, cancellationToken);

        var user = User.Create(
            userId,
            emailResult.Value,
            firstNameResult.Value,
            lastNameResult.Value,
            passwordHashResult.Value,
            passwordSaltResult.Value,
            Enum.Parse<Role>(request.Role),
            isEmailUnique);

        return user;
    }
}
