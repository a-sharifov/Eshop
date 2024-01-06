namespace Identity.App;

/// <summary>
/// Static details.
/// </summary>
public static class SD
{
    //Project name
    public const string ProjectName = "Identity.App";

    //Project version
    public const int ProjectMajorVersion = 1;
    public const int ProjectMinorVersion = 0;
    public static string ProjectVersion =>
      $"v{ProjectMajorVersion}.{ProjectMinorVersion}";

    //Jwt configuration
    public const string JwtSectionKey = "Jwt";
    public const string JwtIssuerKey = "Jwt:Issuer";
    public const string JwtAudiencesKey = "Jwt:Audiences";
    public const string JwtSecurityKey = "Jwt:Key";

    //Default cors policy name
    public const string DefaultCorsPolicyName = "CorsPolicy";

    //Connection string
    public const string DbConfigurationKey = "DefaultConnection";

    //Email configuration
    public const string EmailSectionKey = "Email";
}
