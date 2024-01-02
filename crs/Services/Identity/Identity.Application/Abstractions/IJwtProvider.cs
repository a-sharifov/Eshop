namespace Identity.Application.Abstractions;

public interface IJwtProvider
{
    public int TokenExpirationTimeMinutes { get; }
    public int RefreshTokenExpirationTimeMinutes { get; }

    public string CreateTokenString(User user);
    public string CreateRefreshTokenString();
    public Result<RefreshToken> CreateRefreshToken();   
    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
