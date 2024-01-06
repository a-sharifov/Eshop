namespace Identity.Application.Abstractions;

public interface IIdentityEmailService : IEmailService
{
    Task SendConfirmationEmailAsync(User user, string emailConfirmPagePath, string returnUrl, CancellationToken cancellationToken = default);
    EmailConfirmationToken CreateConfirmationEmailToken();
}
