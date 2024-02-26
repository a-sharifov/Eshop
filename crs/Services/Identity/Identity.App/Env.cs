namespace Identity.App;

/// <summary>
/// Environment variables.
/// </summary>
public static class Env
{
    //Is required environments
    public static string POSTGRES_USER => GetEnvironmentVariable("POSTGRES_USER");
    public static string POSTGRES_PASSWORD => GetEnvironmentVariable("POSTGRES_PASSWORD");
    public static string POSTGRES_DB => GetEnvironmentVariable("POSTGRES_DB");
    public static string AUTH_ISSUER => GetEnvironmentVariable("AUTH_ISSUER");
    public static string WEB_AUDIENCE => GetEnvironmentVariable("WEB_AUDIENCE");
    public static string JWT_SECURITY_KEY => GetEnvironmentVariable("JWT_SECURITY_KEY");
    public static string RABBITMQ_DEFAULT_USER => GetEnvironmentVariable("RABBITMQ_DEFAULT_USER");
    public static string RABBITMQ_DEFAULT_PASS => GetEnvironmentVariable("RABBITMQ_DEFAULT_PASS");
    public static int GRPC_PORT = int.Parse(GetEnvironmentVariable("GRPC_PORT"));
    public static int HTTP_PORT = int.Parse(GetEnvironmentVariable("HTTP_PORT"));

    public static class ConnectionStrings
    {
        public static string POSTGRES => $"""
            Server=postgres;
            Port=5432;
            Database={POSTGRES_DB};
            Username={POSTGRES_USER};
            Password={POSTGRES_PASSWORD};
            TimeZone=UTC;
            """;

        public static string RABBITMQ =>
           $"amqp://{RABBITMQ_DEFAULT_USER}:{RABBITMQ_DEFAULT_PASS}@rabbitmq:5672";
    }

    private static string GetEnvironmentVariable(string key) =>
         Environment.GetEnvironmentVariable(key) ??
        throw new Exception($"environment variable {key} not found");
}
