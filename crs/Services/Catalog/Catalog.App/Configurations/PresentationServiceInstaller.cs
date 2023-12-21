namespace Catalog.App.Configurations;

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

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                SD.ProjectVersion, 
                new() { Title = SD.ProjectName, Version = SD.ProjectVersion });
        });

        services.AddControllers();
    }
}
