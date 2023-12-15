namespace Catalog.Persistence.Factories.Interfaces;

internal interface ISqlConnectionFactory
{
    public IDbConnection GetOpenConnection();
}
