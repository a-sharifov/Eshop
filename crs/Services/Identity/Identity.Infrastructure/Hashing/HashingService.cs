using System.Security.Cryptography;

namespace Identity.Infrastructure.Hashing;

public class HashingService : IHashingService
{
    public string GenerateSalt()
    {
        using var hmac = new HMACSHA256();
        var salt = ConvertToString(hmac.Key);
        return salt;
    }

    public string Hash(string password, string salt)
    {
        var saltBytes = ConvertToBytes(salt);

        using var hmac = new HMACSHA256(saltBytes);
        var passwordBytes = ConvertToBytes(password);
        return Convert.ToBase64String(passwordBytes);
    }

    public bool Verify(string password, string salt, string hash)
    {
        var HashedPassword = Hash(password, salt);
        var isVerify = HashedPassword == hash;
        return isVerify;
    }

    private static byte[] ConvertToBytes(string value) =>
        Encoding.UTF8.GetBytes(value);

    private static string ConvertToString(byte[] value) =>
        Encoding.UTF8.GetString(value);

}
