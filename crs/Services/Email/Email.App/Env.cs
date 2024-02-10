namespace Email.App;

/// <summary>
/// Environment variables.
/// </summary>
internal static class Env
{
    public static string IDENTITY_GRPC_URL => GetEnvironmentVariable("IDENTITY_GRPC_URL");
    public static string RABBITMQ_DEFAULT_USER => GetEnvironmentVariable("RABBITMQ_DEFAULT_USER");
    public static string RABBITMQ_DEFAULT_PASS => GetEnvironmentVariable("RABBITMQ_DEFAULT_PASS");
    public static string AUTH_ISSUER => GetEnvironmentVariable("AUTH_ISSUER");
    public static string WEB_AUDIENCE => GetEnvironmentVariable("WEB_AUDIENCE");
    public static string JWT_SECURITY_KEY => GetEnvironmentVariable("JWT_SECURITY_KEY");

    public static class ConnectionString
    {
        public static string RABBITMQ =>
            $"amqp://{RABBITMQ_DEFAULT_USER}:{RABBITMQ_DEFAULT_PASS}@rabbitmq:5672";
    }

    private static string GetEnvironmentVariable(string key) =>
    Environment.GetEnvironmentVariable(key) ??
   throw new Exception($"Environment variable {key} not found");
}
