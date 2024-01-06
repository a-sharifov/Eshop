namespace Catalog.App.OptionsSetup;

internal sealed class SqlConnectionFactoryOptionsSetup(IConfiguration configuration) 
    : IConfigureOptions<SqlConnectionFactoryOptions>
{
    private readonly IConfiguration _configuration = configuration;

    public void Configure(SqlConnectionFactoryOptions options)
    {
        options.ConnectionString = _configuration[SD.DbConfigurationKey]!;
    }
}
