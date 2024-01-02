namespace Identity.Application.Abstractions;

public interface IIdentityEmailService : IEmailService
{
    public Task SendConfirmationEmailAsync(User user, CancellationToken cancellationToken = default);
    public Task SendResetPasswordEmailAsync(User user, CancellationToken cancellationToken = default);
}
