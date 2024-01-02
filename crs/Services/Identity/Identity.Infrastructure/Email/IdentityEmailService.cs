using MimeKit;
using MailKit.Security;

namespace Identity.Infrastructure.Email;

public sealed class IdentityEmailService(IOptions<EmailOptions> emailOptions) : IIdentityEmailService
{
    private readonly EmailOptions _emailOptions = emailOptions.Value;

    public async Task<bool> CheckIsEmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        MimeMessage message = new();
        message.From.Add(MailboxAddress.Parse(_emailOptions.From));
        message.To.Add(MailboxAddress.Parse(email));
        message.Subject = "Test email subject";
        message.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = "Test email body" };

        using SmtpClient client = new();
        await client.ConnectAsync(
            _emailOptions.Host,
            _emailOptions.Port,
            SecureSocketOptions.StartTls,
            cancellationToken);

        await client.AuthenticateAsync(
            _emailOptions.Username,
            _emailOptions.Password,
            cancellationToken);



        await client.DisconnectAsync(true, cancellationToken);

        return true;
    }

    public Task SendAsync(string to, string subject, string body, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SendConfirmationEmailAsync(User user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SendResetPasswordEmailAsync(User user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
