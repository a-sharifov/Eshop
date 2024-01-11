namespace Catalog.App;

/// <summary>
/// Environment variables.
/// </summary>
public static class Env
{
    //Is required environments
    public static string REDIS_PASSWORD => GetEnvironmentVariable("REDIS_PASSWORD");
    public static string MSSQL_INITIAL_CATALOG => GetEnvironmentVariable("MSSQL_INITIAL_CATALOG");
    public static string MSSQL_USER_ID => GetEnvironmentVariable("MSSQL_USER_ID");
    public static string MSSQL_SA_PASSWORD => GetEnvironmentVariable("MSSQL_SA_PASSWORD");
    public static string AUTH_ISSUER => GetEnvironmentVariable("AUTH_ISSUER");
    public static string WEB_AUDIENCE => GetEnvironmentVariable("WEB_AUDIENCE");
    public static string JWT_SECURITY_KEY => GetEnvironmentVariable("JWT_SECURITY_KEY");

    private static string GetEnvironmentVariable(string key)
    {
        var environment = Environment.GetEnvironmentVariable(key);

        if (environment is null)
        {
            throw new ArgumentNullException($"Environment {environment} not add.");
        }

        return environment;
    }
}
