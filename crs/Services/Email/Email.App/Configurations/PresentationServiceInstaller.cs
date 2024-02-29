namespace Email.App.Configurations;

internal sealed class PresentationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(SD.DefaultCorsPolicyName,
                builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        services.AddOptions<IdentityEndpointOptions>()
        .Bind(configuration.GetSection(SD.IdentityEndpointSectionKey))
        .ValidateDataAnnotations();
    }
}
