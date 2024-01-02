namespace Identity.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public Email Email { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
    public PasswordSalt PasswordSalt { get; private set; }
    public RefreshToken? RefreshToken { get; private set; }
    public Role Role { get; private set; }

    public bool IsEmailConfirmed { get; private set; }

    private User()
    {
    }

    private User(
        UserId id,
        Email email,
        FirstName firstName,
        LastName lastName,
        PasswordHash passwordHash,
        PasswordSalt passwordSalt,
        Role role,
        bool isEmailConfirmed)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PasswordHash = passwordHash;
        Role = role;
        PasswordSalt = passwordSalt;
        IsEmailConfirmed = isEmailConfirmed;
    }

    public static Result<User> Create(
        UserId id,
        Email email,
        FirstName firstName,
        LastName lastName,
        PasswordHash passwordHash,
        PasswordSalt passwordSalt,
        Role role,
        bool isEmailUnique)
    {
        if (!isEmailUnique)
        {
            return Result.Failure<User>(
                UserErrors.EmailIsNotUnique(email.Value));
        }

        var user = new User(
            id,
            email,
            firstName,
            lastName,
            passwordHash,
            passwordSalt,
            role,
            isEmailConfirmed: false);

        user.AddDomainEvent(
            new UserCreatedDomainEvent(Guid.NewGuid(), id));

        return user;
    }

    public static Result<User> Login(User user, bool passwordIsCorrect)
    {
        //if (!user.IsEmailConfirmed)
        //{
        //    return Result.Failure<User>(
        //        UserErrors.EmailIsNotConfirmed);
        //}

        if (!passwordIsCorrect)
        {
            return Result.Failure<User>(
                UserErrors.PasswordIsNotCorrect);
        }

        user.AddDomainEvent(
            new UserLoggedInDomainEvent(Guid.NewGuid(), user.Id));

        return user;
    }


    public void ConfirmEmail() => IsEmailConfirmed = true;

    public void ChangeEmail(Email email)
    {
        Email = email;

        AddDomainEvent(
            new UserEmailChangedDomainEvent(Guid.NewGuid(), Id));
    }

    public void UpdateRefreshToken(RefreshToken refreshToken) =>
        RefreshToken = refreshToken;
}
