namespace Catalog.App.Configurations.Interfaces;

public interface IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration);
}
