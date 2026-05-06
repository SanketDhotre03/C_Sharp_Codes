// Program: Md5Hash
// Difficulty: Medium
// Description: Computes MD5 hash of a string (for checksums, not passwords).
using System;
using System.Security.Cryptography;
using System.Text;

class Md5Hash
{
    static string ComputeMd5(string input)
    {
        using var md5 = MD5.Create();
        byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
    }

    static void Main(string[] args)
    {
        string[] texts = { "Hello, World!", "The quick brown fox", "" };
        foreach (var t in texts)
            Console.WriteLine($"MD5("{t}") = {ComputeMd5(t)}");

        // Verify same input gives same hash
        string h1 = ComputeMd5("test"), h2 = ComputeMd5("test");
        Console.WriteLine($"Deterministic: {h1 == h2}");
    }
}
