using MimeKit; 
using MailKit.Security;
using System.Text.Encodings.Web;

namespace Identity.Infrastructure.Email;

public sealed class IdentityEmailService(
    IOptions<EmailOptions> emailOptions) : IIdentityEmailService
{
    private readonly EmailOptions _emailOptions = emailOptions.Value;

    public EmailConfirmationToken CreateConfirmationEmailToken()
    {
        var CreateConfirmationEmailTokenString = Guid.NewGuid().ToString();
        return EmailConfirmationToken.Create(CreateConfirmationEmailTokenString).Value;
    }

    public async Task SendAsync(string to, string subject, string body, CancellationToken cancellationToken = default)
    {
        MimeMessage message = new();
        message.From.Add(MailboxAddress.Parse(_emailOptions.From));
        message.To.Add(MailboxAddress.Parse(to));
        message.Subject = subject;
        message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

        using SmtpClient client = new();

        await client.ConnectAsync(
            _emailOptions.Host,
            _emailOptions.Port,
            SecureSocketOptions.Auto,
            cancellationToken);

        await client.AuthenticateAsync(
            _emailOptions.Username,
            _emailOptions.Password,
            cancellationToken);

        await client.SendAsync(message, cancellationToken);
        await client.DisconnectAsync(true, cancellationToken);
    }

    public async Task SendConfirmationEmailAsync(User user, string emailConfirmPagePath, string returnPath, CancellationToken cancellationToken = default)
    {
        var subject = $"Confirm your email {user.FirstName.Value}  {user.LastName.Value}";

        string confirmEmailTemplate =
            await File.ReadAllTextAsync(emailConfirmPagePath, cancellationToken);

        var confirmUrl = 
            $@"{returnPath}?UserId={user.Id.Value}&EmailConfirmationToken={user.EmailConfirmationToken.Value}";

        var confirmUrlEncode = HtmlEncoder.Default.Encode(confirmUrl);

        var body = 
            confirmEmailTemplate
            .Replace("{{confirmationLink}}", confirmUrlEncode)
            .Replace("{{firstName}}", user.FirstName.Value)
            .Replace("{{lastName}}", user.LastName.Value);

        await SendAsync(user.Email.Value, subject, body, cancellationToken);
    }
}
