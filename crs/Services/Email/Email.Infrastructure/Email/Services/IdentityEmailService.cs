namespace Email.Infrastructure.Email.Services;

internal sealed class IdentityEmailService
    (IOptions<EmailOptions> options) : 
    EmailBaseService(options), 
    IIdentityEmailService
{
    public async Task SendConfirmationEmailAsync(SendConfirmationEmailRequest request, CancellationToken cancellationToken = default)
    {
        //var confirmEmailTemplatePath = EmailTemplatePath.ConfirmEmailTemplate;

        //string confirmEmailTemplate =
        //    await File.ReadAllTextAsync(confirmEmailTemplatePath, cancellationToken);

        //var confirmUrl =
        //   $@"{request.SendUrl}?UserId={request.UserId}&EmailConfirmationToken={request.EmailConfirmationToken}&ReturnUrl={request.ReturnUrl}";

        //var confirmUrlEncode = HtmlEncoder.Default.Encode(confirmUrl);

        //confirmEmailTemplate =
        //    confirmEmailTemplate
        //    .Replace("{{firstName}}", request.FirstName)
        //    .Replace("{{lastName}}", request.LastName)
        //    .Replace("{{confirmationLink}}", confirmUrlEncode);

        //var sendMessageRequest = new SendMessageRequest(
        //    To: request.Email,
        //    Subject: $"Eshop - confirm email",
        //    Body: confirmEmailTemplate
        //    );

        //await SendMessageAsync(sendMessageRequest, cancellationToken);

        for (int i = 0; i < 1000; i++)
        {
            await Console.Out.WriteLineAsync("hi");
        }
    }
}
