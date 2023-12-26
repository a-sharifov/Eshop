namespace Identity.Application.Abstractions;

public interface IHashingService
{
    public string Hash(string password, string salt);
    public bool Verify(string password, string salt, string hash);
    public string GenerateSalt();
}
