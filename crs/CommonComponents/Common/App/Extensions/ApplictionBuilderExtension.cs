﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace Common.App.Extensions;

/// <summary>
/// Extension methods for <see cref="IApplicationBuilder"/>.
/// </summary>
public static class ApplictionBuilderExtension
{
    /// <summary>
    /// Migrates the database for the given <typeparamref name="TDbContext"/>.
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    /// <param name="builder"> The <see cref="IApplicationBuilder" />.</param>
    /// <returns> The <see cref="IApplicationBuilder" />.</returns>
    public static IApplicationBuilder MigrateDbContext<TDbContext>(this IApplicationBuilder builder) 
        where TDbContext : DbContext
    {
        using var scope = builder.ApplicationServices.CreateScope();   
        using var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

        Policy
            .Handle<Exception>()
            .WaitAndRetry(
            retryCount: 3,
            _ => TimeSpan.FromSeconds(15))
            .Execute(dbContext.Database.Migrate);

        return builder;
    }

    /// <summary>
    /// Uses Swagger UI and sets up the Swagger endpoint for each API version.
    /// </summary>
    /// <param name="builder"> The <see cref="IApplicationBuilder" />. </param>
    /// <returns> The <see cref="IApplicationBuilder" />. </returns>
    public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder builder)
    {
        // Register the Swagger generator and the Swagger UI middlewares
        var apiVersionDescriptionProvider = 
            builder.ApplicationServices.GetService<IApiVersionDescriptionProvider>()!;  

        // Enable middleware to serve generated Swagger as a JSON endpoint.
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
