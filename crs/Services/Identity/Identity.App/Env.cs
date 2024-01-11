namespace Identity.App;

/// <summary>
/// Environment variables.
/// </summary>
public static class Env
{
    //Is required environments
    public static string POSTGRES_USER => GetEnvironmentVariable("POSTGRES_USER");
    public static string POSTGRES_PASSWORD => GetEnvironmentVariable("POSTGRES_PASSWORD");
    public static string POSTGRES_DB => GetEnvironmentVariable("POSTGRES_DB");
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
