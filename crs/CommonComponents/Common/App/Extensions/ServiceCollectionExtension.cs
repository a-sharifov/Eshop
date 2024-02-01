namespace Common.App.Extensions;


/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Installs the services from the given assembly.
    /// </summary>
    /// <param name="services"> The <see cref="IServiceCollection" />.</param>
    /// <param name="configuration"> The <see cref="IConfiguration"/>.</param>
    /// <param name="assembly"> The <see cref="Assembly"/>.</param>
    public static void InstallServicesFromAssembly(
        this IServiceCollection services,
        IConfiguration configuration,
        Assembly assembly) =>
        assembly
        .DefinedTypes
        .Where(IsServiceInstaller)
        .Select(x => (IServiceInstaller) Activator.CreateInstance(x)!)
        .Foreach(x => x.Install(services, configuration));

    /// <summary>
    /// Check if the given type is a service installer.
    /// </summary>
    /// <param name="type"> The <see cref="Type"/>.</param>
    /// <returns></returns>
    private static bool IsServiceInstaller(Type type) =>
        !type.IsInterface &&
        !type.IsAbstract &&
        typeof(IServiceInstaller).IsAssignableFrom(type);
}
