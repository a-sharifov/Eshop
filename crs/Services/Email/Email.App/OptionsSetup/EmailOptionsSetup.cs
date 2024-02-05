namespace Email.App.OptionsSetup;

internal sealed class EmailOptionsSetup(IConfiguration configuration) : IConfigureOptions<EmailOptions>
{
    private readonly IConfiguration _configuration = configuration;

    public void Configure(EmailOptions options) =>
        _configuration.GetSection(SD.EmailSectionKey).Bind(options);
}
