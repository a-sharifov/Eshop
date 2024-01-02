namespace Identity.Infrastructure.Authentication;

public sealed class JwtOptions
{
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string Key { get; set; } = null!;
    public int RefreshTokenExpirationTimeMinutes { get; set; }
    public int TokenExpirationTimeMinutes { get; set; }
}
