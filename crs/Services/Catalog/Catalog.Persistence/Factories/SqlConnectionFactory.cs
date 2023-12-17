namespace Catalog.Persistence.Factories;

internal sealed class SqlConnectionFactory : 
    ISqlConnectionFactory, 
    IDisposable
{
    private readonly string _connectionString;
    private IDbConnection _connection = null!;

    public IDbConnection GetOpenConnection()
    {
        if (_connection == null || _connection.State != ConnectionState.Open)
        {
            _connection = new SqlConnection(_connectionString);
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
