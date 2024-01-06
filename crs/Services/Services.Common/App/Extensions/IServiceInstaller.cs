namespace Services.Common.App.Extensions;

/// <summary>
/// Interface for service installers.
/// </summary>
public interface IServiceInstaller
{
    /// <summary>
    /// Installs the services.
    /// </summary>
    /// <param name="services"> The <see cref="IServiceCollection" />.</param>
    /// <param name="configuration"> The <see cref="IConfiguration" />.</param>
    void Install(IServiceCollection services, IConfiguration configuration);
}
