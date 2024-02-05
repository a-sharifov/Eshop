namespace Identity.App.Configurations;

internal sealed class GrpcServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpc();
    }
}
