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

        services.AddControllers();

        services.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = ApiVersion.Default;
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.ReportApiVersions = true;
            setup.UnsupportedApiVersionStatusCode = StatusCodes.Status400BadRequest;
            setup.ApiVersionReader =
            ApiVersionReader.Combine(
            new UrlSegmentApiVersionReader(),
            new HeaderApiVersionReader("x-version"));
        }).AddMvc()
        .AddApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });
    }
}
