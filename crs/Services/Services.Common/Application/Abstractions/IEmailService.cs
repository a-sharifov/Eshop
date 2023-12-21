namespace Services.Common.Application.Abstractions;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string? htmlMessage = default, CancellationToken cancellationToken = default);
}
