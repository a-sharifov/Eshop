namespace Email.Infrastructure.Email.Abstractions;

public interface IEmailService
{
    Task SendAsync(SendMessageRequest request, CancellationToken cancellationToken = default);
}