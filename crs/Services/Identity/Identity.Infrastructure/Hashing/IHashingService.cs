namespace Identity.Infrastructure.Hashing;

public interface IHashingService
{
    string Hash(string password, string salt);
    bool Verify(string password, string salt, string hash);
    string GenerateSalt();
    string GenerateToken();
}
