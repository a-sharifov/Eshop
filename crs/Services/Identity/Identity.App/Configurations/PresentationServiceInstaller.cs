namespace Identity.App.Configurations;

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


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.AddAuthorization();

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();


        services.AddControllers();
    }
}
