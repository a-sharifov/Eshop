namespace Catalog.App;

internal static class SD
{
    //Is default values
    public const string DefaultCorsPolicyName = "CorsPolicy";
    public const string ProjectName = "Catalog.App";

    //Is required environments
    public static string REDIS_PASSWORD => GetEnvironmentVariable("REDIS_PASSWORD");
    public static string MSSQL_INITIAL_CATALOG => GetEnvironmentVariable("MSSQL_INITIAL_CATALOG");
    public static string MSSQL_USER_ID => GetEnvironmentVariable("MSSQL_USER_ID");
    public static string MSSQL_SA_PASSWORD => GetEnvironmentVariable("MSSQL_SA_PASSWORD");

    private static string GetEnvironmentVariable(string key)
    {
        var environment = Environment.GetEnvironmentVariable(key);

        if(environment is null)
        {
            throw new ArgumentNullException($"Environment {environment} not add.");
        }

        return environment;
    }
}
