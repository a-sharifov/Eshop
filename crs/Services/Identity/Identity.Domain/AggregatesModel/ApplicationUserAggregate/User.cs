namespace Identity.Domain.AggregatesModel.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public Email Email { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
    public Role Role { get; private set; }

    public bool IsEmailConfirmed { get; private set; }

    private User()
    {
    }

    public User(
        UserId id,
        Email email,
        FirstName firstName,
        LastName lastName,
        PasswordHash passwordHash,
        Role role,
        bool isEmailConfirmed)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PasswordHash = passwordHash;
        Role = role;
        IsEmailConfirmed = isEmailConfirmed;

        AddDomainEvent(
            new UserCreatedDomainEvent(Guid.NewGuid(), Id));
    }

    public void ConfirmEmail() => IsEmailConfirmed = true;

    public void ChangeEmail(Email email)
    {
        Email = email;

        AddDomainEvent(
            new UserEmailChangedDomainEvent(Guid.NewGuid(), Id));
    }
}
