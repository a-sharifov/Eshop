using Identity.Domain.UserAggregate;
using Identity.Domain.UserAggregate.Ids;
using Identity.Domain.UserAggregate.ValueObjects;

namespace Identity.Domain.UserAggregate.Repositories;

public interface IUserRepository
{
    public Task AddUserAsync(User user, CancellationToken cancellationToken = default);
    public Task<User> GetUserByEmailAsync(Email email, CancellationToken cancellationToken = default);
    public Task<User> GetUserByIdAsync(UserId userId, CancellationToken cancellationToken = default);
    public Task<bool> CheckPasswordAsync(User user, string password, CancellationToken cancellationToken = default);
    public Task ChangePasswordAsync(UserId userId, string currentPassowrd, string newPassword);
    public Task ChangeEmailAsync(UserId userId, Email newEmail, CancellationToken cancellationToken = default);
    public Task ConfirmEmailAsync(UserId userId, CancellationToken cancellationToken = default);
    public Task DeleteUserAsync(UserId userId, CancellationToken cancellationToken = default);
    public Task<bool> IsEmailConfirmedAsync(UserId userId, CancellationToken cancellationToken = default);
    public Task<bool> IsUserExistsAsync(UserId userId, CancellationToken cancellationToken = default);
    public Task<bool> IsUserExistsAsync(Email userId, CancellationToken cancellationToken = default);
    public Task UpdateUserAsync(User user, CancellationToken cancellationToken = default);
}
