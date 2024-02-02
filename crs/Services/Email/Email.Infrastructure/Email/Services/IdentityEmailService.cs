namespace Email.Infrastructure.Email.Services;

public class IdentityEmailService : EmailBaseService, IIdentityEmailService
{
    public Task SendConfirmationEmailAsync(User user, string emailConfirmPagePath, string returnUrl, CancellationToken cancellationToken = default)
    {
    }
}
