namespace Identity.Domain.UserAggregate.Repositories;

public interface IUserRepository
{
    Task AddUserAsync(User user, CancellationToken cancellationToken = default);
    Task<User?> GetUserByEmailAsync(Email email, CancellationToken cancellationToken = default);
    Task<User?> GetUserByIdAsync(UserId userId, CancellationToken cancellationToken = default);
    Task<bool> CheckPasswordAsync(User user, string password, CancellationToken cancellationToken = default);
    Task ChangePasswordAsync(UserId userId, string currentPassowrd, string newPassword);
    Task ChangeEmailAsync(UserId userId, Email newEmail, CancellationToken cancellationToken = default);
    Task ConfirmEmailAsync(UserId userId, CancellationToken cancellationToken = default);
    Task<bool> IsEmailUnigueAsync(Email email, CancellationToken cancellationToken = default);
    Task DeleteUserAsync(UserId userId, CancellationToken cancellationToken = default);
    Task<bool> IsEmailConfirmedAsync(UserId userId, CancellationToken cancellationToken = default);
    Task<bool> IsUserExistsAsync(UserId userId, CancellationToken cancellationToken = default);
    Task<bool> IsUserExistsAsync(Email userId, CancellationToken cancellationToken = default);
    void UpdateUser(User user);
}
