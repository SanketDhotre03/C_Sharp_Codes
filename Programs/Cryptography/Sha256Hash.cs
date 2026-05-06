// Program: Sha256Hash
// Difficulty: Medium
// Description: Computes SHA-256 hash for data integrity verification.
using System;
using System.Security.Cryptography;
using System.Text;

class Sha256Hash
{
    static string ComputeSha256(string input)
    {
        using var sha = SHA256.Create();
        byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(hash).ToLower();
    }

    static bool VerifyIntegrity(string data, string expectedHash) =>
        ComputeSha256(data) == expectedHash;

    static void Main(string[] args)
    {
        string data = "Important document content";
        string hash = ComputeSha256(data);
        Console.WriteLine($"Data: {data}");
        Console.WriteLine($"SHA-256: {hash}");

        Console.WriteLine($"Verify original: {VerifyIntegrity(data, hash)}");
        Console.WriteLine($"Verify tampered: {VerifyIntegrity("Tampered content", hash)}");
    }
}
