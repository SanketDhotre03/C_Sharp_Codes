// Program: HmacSha256
// Difficulty: High
// Description: Creates and verifies HMAC-SHA256 message authentication codes.
using System;
using System.Security.Cryptography;
using System.Text;

class HmacSha256
{
    static string ComputeHmac(string message, string secret)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
        return Convert.ToBase64String(hash);
    }

    static bool VerifyHmac(string message, string secret, string expectedHmac)
    {
        string actual = ComputeHmac(message, secret);
        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(actual),
            Encoding.UTF8.GetBytes(expectedHmac));
    }

    static void Main(string[] args)
    {
        string secret = "my_secret_key";
        string message = "Hello, World!";
        string hmac = ComputeHmac(message, secret);
        Console.WriteLine($"Message: {message}");
        Console.WriteLine($"HMAC:    {hmac}");
        Console.WriteLine($"Valid:   {VerifyHmac(message, secret, hmac)}");
        Console.WriteLine($"Tampered: {VerifyHmac("Tampered!", secret, hmac)}");
    }
}
