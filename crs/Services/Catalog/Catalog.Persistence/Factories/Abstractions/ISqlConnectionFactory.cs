namespace Catalog.Persistence.Factories.Abstractions;

internal interface ISqlConnectionFactory
{
    public IDbConnection GetOpenConnection();
}
