namespace Email.Infrastructure.Email.Abstractions;

public interface IEmailService
{
    /// <summary>
    /// Send email async.
    /// </summary>
    /// <param name="request">The <see cref="SendMessageRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns></returns>
    Task SendAsync(SendMessageRequest request, CancellationToken cancellationToken = default);
}