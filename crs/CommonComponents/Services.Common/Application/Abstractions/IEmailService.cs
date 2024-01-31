namespace Services.Common.Application.Abstractions;

/// <summary>
/// Interface for email service.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Send email async.
    /// </summary>
    /// <param name="to"> The email address to send to.</param>
    /// <param name="subject"> The email subject.</param>
    /// <param name="body"> The email body.</param>
    /// <param name="cancellationToken"> The <see cref="CancellationToken"/>.</param>
    /// <returns> A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task SendAsync(string to, string subject, string body, CancellationToken cancellationToken = default);
}
