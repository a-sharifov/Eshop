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
    public const string JwtSectionKey = "jwt";
}
