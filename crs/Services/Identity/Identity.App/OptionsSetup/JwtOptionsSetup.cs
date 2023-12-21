namespace Identity.App.OptionsSetup;

internal sealed class JwtOptionsSetup(IConfiguration configuration) 
    : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration _configuration = configuration;

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(SD.JwtSectionKey).Bind(options);
    }
}
