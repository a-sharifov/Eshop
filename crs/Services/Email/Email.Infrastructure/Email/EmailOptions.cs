namespace Email.Infrastructure.Email;

public class EmailOptions
{
    public string From { get; set; } = null!;
    public string Host { get; set; } = null!;
    public int Port { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
