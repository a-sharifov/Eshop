namespace Catalog.App;

public sealed class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        //переместить в common
        App.AssemblyConfiguration.Assembly
            .DefinedTypes
            .Where(IsServiceInstaller)
            .Select(x => (IServiceInstaller)Activator.CreateInstance(x)!)
            .Foreach(x => x.Install(services, _configuration));

        static bool IsServiceInstaller(Type type) =>
            !type.IsInterface &&
            !type.IsAbstract &&
            typeof(IServiceInstaller).IsAssignableFrom(type);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.App v1"));
        }

        app.UseCors(SD.DefaultCorsPolicyName);

        //migrate db
        //don't forget to make extension method from this
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
        dbContext.Database.Migrate();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
