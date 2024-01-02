namespace Identity.Persistence.Repositories;

internal sealed class UserRepository(UserDbContext dbContext) : IUserRepository
{
    private readonly UserDbContext _dbContext = dbContext;

    public async Task AddUserAsync(User user, CancellationToken cancellationToken = default)
    {
        await _dbContext
            .Set<User>()
            .AddAsync(user);
    }

    public Task ChangeEmailAsync(UserId userId, Email newEmail, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task ChangePasswordAsync(UserId userId, string currentPassowrd, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckPasswordAsync(User user, string password, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task ConfirmEmailAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        return await _dbContext
            .Set<User>()
            .SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public Task<User?> GetUserByIdAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsEmailConfirmedAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsEmailUnigueAsync(Email email, CancellationToken cancellationToken = default)
    {
        return !await _dbContext
            .Set<User>()
            .AnyAsync(u => u.Email == email, cancellationToken);
    }

    public Task<bool> IsUserExistsAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsUserExistsAsync(Email userId, CancellationToken cancellationToken = default)
    {
        return _dbContext
            .Set<User>()
            .AnyAsync(u => u.Email == userId, cancellationToken);
    }

    public Task UpdateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
