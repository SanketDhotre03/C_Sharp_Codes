// Program: PasswordHash
// Difficulty: High
// Description: Securely hashes passwords using PBKDF2 with salt.
using System;
using System.Security.Cryptography;
using System.Text;

class PasswordHash
{
    const int SALT_SIZE = 16, HASH_SIZE = 32, ITERATIONS = 100000;

    static string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SALT_SIZE);
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(HASH_SIZE);
        byte[] combined = new byte[SALT_SIZE + HASH_SIZE];
        Buffer.BlockCopy(salt, 0, combined, 0, SALT_SIZE);
        Buffer.BlockCopy(hash, 0, combined, SALT_SIZE, HASH_SIZE);
        return Convert.ToBase64String(combined);
    }

    static bool VerifyPassword(string password, string storedHash)
    {
        byte[] combined = Convert.FromBase64String(storedHash);
        byte[] salt = combined[..SALT_SIZE];
        byte[] stored = combined[SALT_SIZE..];
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS, HashAlgorithmName.SHA256);
        byte[] computed = pbkdf2.GetBytes(HASH_SIZE);
        return CryptographicOperations.FixedTimeEquals(computed, stored);
    }

    static void Main(string[] args)
    {
        string password = "MySecurePassword123!";
        string hash = HashPassword(password);
        Console.WriteLine($"Hash: {hash}");
        Console.WriteLine($"Correct password: {VerifyPassword(password, hash)}");
        Console.WriteLine($"Wrong password:   {VerifyPassword("wrong", hash)}");
    }
}
