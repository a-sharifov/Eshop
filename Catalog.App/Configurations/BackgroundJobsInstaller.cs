namespace Catalog.App.Configurations;

internal sealed class BackgroundJobsInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddQuartz(configure =>
        {
            var jobKey = new JobKey(nameof(OutboxBackgroundJob));

            configure
            .AddJob<OutboxBackgroundJob>(jobKey)
            .AddTrigger(
                trigger => trigger
                .ForJob(jobKey)
                .WithSimpleSchedule(
                    schedule => schedule
                    .WithIntervalInSeconds(10)
                    .RepeatForever()));
        });

        services.AddQuartzHostedService(configure => 
        configure.WaitForJobsToComplete = true);
    }
}
