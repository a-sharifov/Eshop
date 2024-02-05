using System.Security.Cryptography;

namespace Identity.Infrastructure.Hashing;

public class HashingService : IHashingService
{
    public string GenerateSalt() => GenerateToken();

    public string Hash(string password, string salt)
    {
        var saltBytes = ConvertToBytes(salt);
        var passwordBytes = ConvertToBytes(password);
        using var hmac = new HMACSHA256(saltBytes);
        var hash = hmac.ComputeHash(passwordBytes);
        return Convert.ToBase64String(hash);
    }

    public bool Verify(string password, string salt, string hash)
    {
        var HashedPassword = Hash(password, salt);
        var isVerify = HashedPassword == hash;
        return isVerify;
    }

    private static byte[] ConvertToBytes(string value) =>
        Convert.FromBase64String(value);

    private static string ConvertToString(byte[] value) =>
        Convert.ToBase64String(value);

    public string GenerateToken()
    {
        using var hmac = new HMACSHA256();
        var token = ConvertToString(hmac.Key);
        return token;
    }
}
