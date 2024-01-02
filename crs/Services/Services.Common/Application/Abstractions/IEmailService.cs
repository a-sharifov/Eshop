namespace Services.Common.Application.Abstractions;

public interface IEmailService
{
    public Task SendAsync(string to, string subject, string body, CancellationToken cancellationToken = default);
    public Task<bool> CheckIsEmailExistsAsync(string email, CancellationToken cancellationToken = default);
}
