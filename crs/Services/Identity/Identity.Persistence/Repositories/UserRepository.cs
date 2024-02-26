namespace Identity.Persistence.Repositories;

internal sealed class UserRepository(UserDbContext dbContext) : IUserRepository
{
    private readonly UserDbContext _dbContext = dbContext;

    public async Task AddUserAsync(User user, CancellationToken cancellationToken = default) => 
        await _dbContext
        .Set<User>()
        .AddAsync(user, cancellationToken);

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

    public async Task DeleteUserAsync(UserId userId, CancellationToken cancellationToken = default) => 
        await _dbContext
        .Set<User>()
        .Where(u => u.Id == userId)
        .ExecuteDeleteAsync(cancellationToken);

    public async Task<User?> GetUserByEmailAsync(Email email, CancellationToken cancellationToken = default) => 
        await _dbContext
        .Set<User>()
        .SingleOrDefaultAsync(u => u.Email == email, cancellationToken);

    public async Task<User> GetUserByIdAsync(UserId userId, CancellationToken cancellationToken = default) => 
        await _dbContext
        .Set<User>()
        .SingleAsync(u => u.Id == userId, cancellationToken);

    public Task<bool> IsEmailConfirmedAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsEmailUnigueAsync(Email email, CancellationToken cancellationToken = default) => 
        !await _dbContext
        .Set<User>()
        .AnyAsync(u => u.Email == email, cancellationToken);

    public Task<bool> IsUserExistsAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsUserExistsAsync(Email userId, CancellationToken cancellationToken = default) => 
        _dbContext
        .Set<User>()
        .AnyAsync(u => u.Email == userId, cancellationToken);

    public void UpdateUser(User user) => 
        _dbContext
        .Set<User>()
        .Update(user);
}
