namespace Email.Infrastructure.Email.Services;

internal sealed class IdentityEmailService
    (IOptions<EmailOptions> options,
     IOptions<IdentityEndpointOptions> identityEndpointOptions) : 
    EmailBaseService(options), 
    IIdentityEmailService
{
    private readonly IdentityEndpointOptions _identityEndpointOptions = identityEndpointOptions.Value;

    public async Task SendConfirmationEmailAsync(SendConfirmationEmailRequest request, CancellationToken cancellationToken = default)
    {
        var confirmEmailTemplatePath = EmailTemplatePath.ConfirmEmailTemplate;

        string confirmEmailTemplate =
            await File.ReadAllTextAsync(confirmEmailTemplatePath, cancellationToken);

        var confirmUrl =
           $@"{_identityEndpointOptions.BaseUrl}/confirm-email?UserId={request.UserId}&EmailConfirmationToken={request.EmailConfirmationToken}&ReturnUrl={request.ReturnUrl}";

        var confirmUrlEncode = HtmlEncoder.Default.Encode(confirmUrl);

        confirmEmailTemplate =
            confirmEmailTemplate
            .Replace("{{firstName}}", request.FirstName)
            .Replace("{{lastName}}", request.LastName)
            .Replace("{{confirmationLink}}", confirmUrlEncode);

        var sendMessageRequest = new SendMessageRequest(
            To: request.Email,
            Subject: $"Eshop - confirm email",
            Body: confirmEmailTemplate
            );

        await SendMessageAsync(sendMessageRequest, cancellationToken);
    }
}
