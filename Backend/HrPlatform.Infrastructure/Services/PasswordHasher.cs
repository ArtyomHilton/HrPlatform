using System.Security.Cryptography;

using HrPlatform.Application.Abstractions;

namespace HrPlatform.Infrastructure.Services;

class PasswordHasher : IPasswordHasher
{
    private readonly int HashSize = 32;
    private readonly int SaltSize = 16;
    private readonly int Iterations = 100000;
    private readonly HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA512;
    public string HashPassword(string password)
    {
        var salt = GenerateSalt();

        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName, HashSize);

        return $"{Convert.ToHexString(hash)}{Convert.ToHexString(salt)}";
    }

    public bool Verify(string password, string hashPassword)
    {
        var hash = Convert.FromHexString(hashPassword.Substring(0, HashSize));
        var salt = Convert.FromHexString(hashPassword.Substring(HashSize + 1));

        var verifyHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName, HashSize);

        return CryptographicOperations.FixedTimeEquals(verifyHash, hash);
    }

    private byte[] GenerateSalt() =>
        RandomNumberGenerator.GetBytes(SaltSize);
}
