// Program: DigitalSignature
// Difficulty: High
// Description: Creates and verifies digital signatures using RSA.
using System;
using System.Security.Cryptography;
using System.Text;

class DigitalSignature
{
    static (byte[] signature, string publicKeyXml) Sign(string message)
    {
        using var rsa = RSA.Create(2048);
        byte[] data = Encoding.UTF8.GetBytes(message);
        byte[] signature = rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        return (signature, rsa.ToXmlString(false));
    }

    static bool Verify(string message, byte[] signature, string publicKeyXml)
    {
        using var rsa = RSA.Create();
        rsa.FromXmlString(publicKeyXml);
        byte[] data = Encoding.UTF8.GetBytes(message);
        return rsa.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }

    static void Main(string[] args)
    {
        string message = "Contract: Alice agrees to terms.";
        var (sig, pubKey) = Sign(message);
        Console.WriteLine($"Message:   {message}");
        Console.WriteLine($"Signature: {Convert.ToBase64String(sig)[..50]}...");
        Console.WriteLine($"Valid sig: {Verify(message, sig, pubKey)}");
        Console.WriteLine($"Tampered:  {Verify("Tampered message", sig, pubKey)}");
    }
}
