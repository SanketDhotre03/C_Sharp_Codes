// Program: Sha512Hash
// Difficulty: Medium
// Description: Computes SHA-512 hash for strong data integrity verification.
using System;
using System.Security.Cryptography;
using System.Text;

class Sha512Hash
{
    static string ComputeSha512(string input)
    {
        using var sha = SHA512.Create();
        byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(hash).ToLower();
    }

    static void Main(string[] args)
    {
        string message = "Secure message";
        string hash = ComputeSha512(message);
        Console.WriteLine($"Input: {message}");
        Console.WriteLine($"SHA-512 ({hash.Length / 2} bytes):");
        Console.WriteLine(hash[..64] + "...");

        // Compare hash sizes
        using var sha256 = SHA256.Create();
        using var sha512 = SHA512.Create();
        byte[] data = Encoding.UTF8.GetBytes("test");
        Console.WriteLine($"SHA-256 size: {sha256.ComputeHash(data).Length} bytes");
        Console.WriteLine($"SHA-512 size: {sha512.ComputeHash(data).Length} bytes");
    }
}
