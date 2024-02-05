namespace Identity.App;

public sealed class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services) =>
        services.InstallServicesFromAssembly(_configuration, App.AssemblyReference.Assembly);

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }   

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseCors(SD.DefaultCorsPolicyName);

        app.MigrateDbContext<UserDbContext>();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(configure =>
        {
            configure.MapControllers();
            configure.MapPrometheusScrapingEndpoint();
            configure.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        });
    }

}
