namespace Identity.App.OptionsSetup;

internal sealed class JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions) 
    : IConfigureOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public void Configure(JwtBearerOptions options)
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidIssuer = Env.AUTH_ISSUER,
            ValidAudiences = [Env.WEB_AUDIENCE],
            RoleClaimType = ClaimTypes.Role,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Env.JWT_SECURITY_KEY)),
        };
    }
}
