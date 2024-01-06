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

            //setup.AddSecurityDefinition(
            //JwtBearerDefaults.AuthenticationScheme,
            //new OpenApiSecurityScheme
            //{
            //    Name = "Authorization",
            //    Description = "Please enter JWT with Bearer into field",
            //    BearerFormat = "JWT",
            //    In = ParameterLocation.Header,
            //    Type = SecuritySchemeType.Http,
            //    Scheme = JwtBearerDefaults.AuthenticationScheme,
            //});

            //setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //    {
            //        new OpenApiSecurityScheme
            //        {
            //            Name = JwtBearerDefaults.AuthenticationScheme,
            //            In = ParameterLocation.Header,
            //            Reference = new OpenApiReference
            //            {
            //                Id = JwtBearerDefaults.AuthenticationScheme,
            //                Type = ReferenceType.SecurityScheme
            //            }
            //        },
            //        new string[] {}
            //    }
            //});
        });

        services.ConfigureOptions<ConfigureSwaggerOptions>();
    }
}
