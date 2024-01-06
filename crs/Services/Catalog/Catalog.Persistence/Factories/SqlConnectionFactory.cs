namespace Catalog.Persistence.Factories;

internal sealed class SqlConnectionFactory(IOptions<SqlConnectionFactoryOptions> options) : 
    ISqlConnectionFactory, 
    IDisposable
{
    private readonly SqlConnectionFactoryOptions _option = options.Value;
    private IDbConnection _connection = null!;

    public IDbConnection GetOpenConnection()
    {
        if (_connection == null || _connection.State != ConnectionState.Open)
        {
            _connection = new SqlConnection(_option.ConnectionString);
            _connection.Open();
        }

        return _connection;
    }

    public void Dispose()
    {
        if (_connection is not null 
            && _connection.State == ConnectionState.Open)
        {
            _connection.Dispose();
        }
    }
}
