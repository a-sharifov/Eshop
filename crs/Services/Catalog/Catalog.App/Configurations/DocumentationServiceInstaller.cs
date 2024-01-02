namespace Catalog.App.Configurations;

internal sealed class DocumentationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                SD.ProjectVersion,
                new() { Title = SD.ProjectName, Version = SD.ProjectVersion });
        });

        services.ConfigureOptions<ConfigureSwaggerOptions>();
    }
}
