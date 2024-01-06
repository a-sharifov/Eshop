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
        var userResult = await CreateUserResult(request);

        if (userResult.IsFailure)
        {
            return Result.Failure(userResult.Error);
        }

        var user = userResult.Value;

        await _userRepository.AddUserAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _emailService.SendConfirmationEmailAsync(
            user,
            request.EmailConfirmPagePath,
            request.ReturnUrl,
            cancellationToken);

        return Result.Success();
    }

    private async Task<Result<User>> CreateUserResult(
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

        var emailConfirmationToken = _emailService.CreateConfirmationEmailToken();

        var isEmailUnique = await _userRepository
            .IsEmailUnigueAsync(emailResult.Value, cancellationToken);

        var user = User.Create(
            userId,
            emailResult.Value,
            firstNameResult.Value,
            lastNameResult.Value,
            passwordHashResult.Value,
            passwordSaltResult.Value,
            emailConfirmationToken,
            isEmailUnique,
            Enum.Parse<Role>(request.Role));

        return user;
    }
}
