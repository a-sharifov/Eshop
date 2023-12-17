using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Common.App.Extensions;

public static class ApplictionBuilderExtension
{
    public static void MigrateDbContext<TDbContext>(this IApplicationBuilder builder) 
        where TDbContext : DbContext
    {
        using var scope = builder.ApplicationServices.CreateScope();   
        using var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
        
        dbContext.Database.Migrate();
    }
}
