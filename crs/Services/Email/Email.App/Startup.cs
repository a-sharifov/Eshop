namespace Email.App;

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
        }
        
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapPrometheusScrapingEndpoint();
        });
    }
}
