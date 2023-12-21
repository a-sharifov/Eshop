namespace Catalog.App;

public sealed class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.InstallServicesFromAssembly(
            _configuration, 
            App.AssemblyReference.Assembly);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(
                $"/swagger/{SD.ProjectVersion}/swagger.json", 
                $"{SD.ProjectName} {SD.ProjectVersion}"));
        }

        app.UseCors(SD.DefaultCorsPolicyName);

        app.MigrateDbContext<CatalogDbContext>();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
