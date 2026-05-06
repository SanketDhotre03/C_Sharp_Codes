// Program: Base64Encode
// Difficulty: Medium
// Description: Encodes and decodes data using Base64 and URL-safe Base64.
using System;
using System.Text;

class Base64Encode
{
    static string EncodeBase64(string text) =>
        Convert.ToBase64String(Encoding.UTF8.GetBytes(text));

    static string DecodeBase64(string encoded) =>
        Encoding.UTF8.GetString(Convert.FromBase64String(encoded));

    static string EncodeUrlSafe(string text)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(text))
            .Replace('+', '-').Replace('/', '_').TrimEnd('=');
    }

    static string DecodeUrlSafe(string encoded)
    {
        string padded = encoded.Replace('-', '+').Replace('_', '/');
        int pad = padded.Length % 4;
        if (pad != 0) padded += new string('=', 4 - pad);
        return Encoding.UTF8.GetString(Convert.FromBase64String(padded));
    }

    static void Main(string[] args)
    {
        string original = "Hello, Base64! Special: +/=";
        string encoded = EncodeBase64(original);
        string decoded = DecodeBase64(encoded);
        Console.WriteLine($"Original:    {original}");
        Console.WriteLine($"Base64:      {encoded}");
        Console.WriteLine($"Decoded:     {decoded}");
        Console.WriteLine($"Match:       {original == decoded}");

        string urlSafe = EncodeUrlSafe(original);
        Console.WriteLine($"URL-safe:    {urlSafe}");
        Console.WriteLine($"URL decode:  {DecodeUrlSafe(urlSafe)}");
    }
}
