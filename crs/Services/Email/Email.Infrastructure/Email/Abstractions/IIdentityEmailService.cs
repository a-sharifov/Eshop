namespace Email.Infrastructure.Email.Abstractions;

public interface IIdentityEmailService : IEmailService
{
    Task SendConfirmationEmailAsync(User user, string emailConfirmPagePath, string returnUrl, CancellationToken cancellationToken = default);
}
