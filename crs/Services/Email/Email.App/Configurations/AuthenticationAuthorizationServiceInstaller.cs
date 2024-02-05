namespace Email.App.Configurations;

internal sealed class AuthenticationAuthorizationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, configureOptions =>
          {
              configureOptions.RequireHttpsMetadata = true;
              configureOptions.SaveToken = true;
              configureOptions.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidIssuer = Env.AUTH_ISSUER,

                  ValidateAudience = true,
                  ValidAudiences = [Env.WEB_AUDIENCE],

                  RequireExpirationTime = true,
                  ValidateLifetime = true,
                  ClockSkew = TimeSpan.Zero,

                  RoleClaimType = ClaimTypes.Role,

                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(Env.JWT_SECURITY_KEY)),
              };
          });

        services.AddAuthorization();
    }
}
