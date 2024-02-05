namespace Email.Infrastructure.Email.Abstractions;

public interface IIdentityEmailService : IEmailService
{
    Task SendConfirmationEmailAsync(SendConfirmationEmailRequest request, CancellationToken cancellationToken = default);
}
