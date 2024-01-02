using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Services.Common.App.Extensions;

public static class ApplictionBuilderExtension
{
    public static IApplicationBuilder MigrateDbContext<TDbContext>(this IApplicationBuilder builder) 
        where TDbContext : DbContext
    {
        using var scope = builder.ApplicationServices.CreateScope();   
        using var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
        
        dbContext.Database.Migrate();

        return builder;
    }

    public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder builder)
    {
        var apiVersionDescriptionProvider = 
            builder.ApplicationServices.GetService<IApiVersionDescriptionProvider>()!;  

        builder.UseSwaggerUI(options =>
        {
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });

        return builder;
    }
}
