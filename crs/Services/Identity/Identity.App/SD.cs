namespace Identity.App;

/// <summary>
/// Static details.
/// </summary>
public static class SD
{
    //Is default values
    public const string EmailSectionKey = "Email";
    public const string DefaultCorsPolicyName = "CorsPolicy";
    public const string ProjectName = "Identity.App";
    public static string ProjectVersion => $"v{1}.{0}";

    //Jwt default configuration
    public const string JwtSectionKey = "Jwt";
    public const string JwtIssuerKey = "Jwt:Issuer";
    public const string JwtAudiencesKey = "Jwt:Audiences";
    public const string JwtSecurityKey = "Jwt:Key";

    //Is required environments
    public static string POSTGRES_USER = GetEnvironmentVariable("POSTGRES_USER");
    public static string POSTGRES_PASSWORD = GetEnvironmentVariable("POSTGRES_PASSWORD");
    public static string POSTGRES_DB = GetEnvironmentVariable("POSTGRES_DB");

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
