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

    private static string GetEnvironmentVariable(string key) =>
         Environment.GetEnvironmentVariable(key) ??
        throw new Exception($"Environment variable {key} not found");

    public static class ConnectionStrings
    {
        public static string MSSQL => 
            $"Server=mssql,1433;" +
            $"Initial Catalog={MSSQL_INITIAL_CATALOG};" +
            $"User ID={MSSQL_USER_ID};" +
            $"Password={MSSQL_SA_PASSWORD};" +
            $"TrustServerCertificate=true";

        public static string REDIS => $"redis:6379,password={REDIS_PASSWORD}";
    }
}
