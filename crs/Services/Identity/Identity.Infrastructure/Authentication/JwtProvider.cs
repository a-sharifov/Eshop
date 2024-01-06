using Microsoft.IdentityModel.Tokens;
using Services.Common.Domain.Primitives.Results;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Identity.Infrastructure.Authentication;

public class JwtProvider(IOptions<JwtOptions> jwtOptions) : IJwtProvider
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public int RefreshTokenExpirationTimeMinutes => 
        _jwtOptions.RefreshTokenExpirationTimeMinutes;

    public int TokenExpirationTimeMinutes => 
        _jwtOptions.TokenExpirationTimeMinutes;

    public string CreateTokenString(User user)
    {
        var claims = CreateClaims(user);

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtOptions.Key));

        var signingCredentials = new SigningCredentials(
            key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(TokenExpirationTimeMinutes),
            signingCredentials: signingCredentials
        );

        var tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }

    private Claim[] CreateClaims(User user)
    {
        Claim[] claims = [
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email.Value),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iss, _jwtOptions.Issuer),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
            ClaimValueTypes.Integer64),
            new Claim(ClaimTypes.Role, user.Role.ToString())
                ];

        foreach (var item in _jwtOptions.Audiences)
        {
            claims.Append(new Claim(JwtRegisteredClaimNames.Aud, item));
        }

        return claims;
    }

    public string CreateRefreshTokenString()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public IEnumerable<Claim> GetClaimsInToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        if (securityToken is null)
        {
            throw new SecurityTokenException("Invalid token");
        }

        return securityToken.Claims;
    }

    public Result<RefreshToken> CreateRefreshToken()
    {
        var refreshTokenValue = CreateRefreshTokenString();
        var refreshTokenExpirationTime = DateTime.UtcNow.AddMinutes(RefreshTokenExpirationTimeMinutes);

        return RefreshToken.Create(refreshTokenValue, refreshTokenExpirationTime);
    }
}
