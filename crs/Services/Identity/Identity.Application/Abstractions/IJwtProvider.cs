namespace Identity.Application.Abstractions;

public interface IJwtProvider
{
    int TokenExpirationTimeMinutes { get; }
    int RefreshTokenExpirationTimeMinutes { get; }

    string CreateTokenString(User user, string audience);
    string CreateRefreshTokenString();
    Result<RefreshToken> CreateRefreshToken();
    IEnumerable<Claim> GetClaimsInToken(string token);
    string GetEmailFromToken(string token);
}
