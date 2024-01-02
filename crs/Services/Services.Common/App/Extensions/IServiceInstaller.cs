using Microsoft.Extensions.DependencyInjection;

namespace Services.Common.App.Extensions;

public interface IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration);
}
