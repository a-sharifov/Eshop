namespace Email.Infrastructure.Email;

public abstract class EmailBaseService(IOptions<EmailOptions> options) : IEmailService
{
    private readonly EmailOptions _options = options.Value;

    public async Task SendAsync(SendMessageRequest request, CancellationToken cancellationToken = default)
    {
        MimeMessage message = new();
        message.From.Add(MailboxAddress.Parse(_options.From));
        message.To.Add(MailboxAddress.Parse(request.To));
        message.Subject = request.Subject;
        message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };

        using SmtpClient client = new();

        await client.ConnectAsync(
            _options.Host,
            _options.Port,
            SecureSocketOptions.Auto,
            cancellationToken);

        await client.AuthenticateAsync(
            _options.Username,
            _options.Password,
        cancellationToken);

        await client.SendAsync(message, cancellationToken);
        await client.DisconnectAsync(true, cancellationToken);
    }
}
