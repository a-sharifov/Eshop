namespace Identity.App.OptionsSetup;

internal sealed class JwtOptionsSetup(IConfiguration configuration) 
    : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration _configuration = configuration;

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(SD.JwtSectionKey).Bind(options);
        options.Issuer = Env.AUTH_ISSUER;
        options.Audiences = [Env.WEB_AUDIENCE];
        options.Key = Env.JWT_SECURITY_KEY;
    }
}
