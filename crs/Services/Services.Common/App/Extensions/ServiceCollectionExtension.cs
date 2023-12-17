using Microsoft.Extensions.DependencyInjection;

namespace Services.Common.App.Extensions;

public static class ServiceCollectionExtension
{
    public static void InstallServicesFromAssembly(
        this IServiceCollection services,
        IConfiguration configuration,
        Assembly assembly) =>
        assembly
        .DefinedTypes
        .Where(IsServiceInstaller)
        .Select(x => (IServiceInstaller) Activator.CreateInstance(x)!)
        .Foreach(x => x.Install(services, configuration));


    private static bool IsServiceInstaller(Type type) =>
        !type.IsInterface &&
        !type.IsAbstract &&
        typeof(IServiceInstaller).IsAssignableFrom(type);

}
