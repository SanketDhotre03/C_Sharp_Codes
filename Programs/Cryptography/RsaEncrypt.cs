// Program: RsaEncrypt
// Difficulty: High
// Description: RSA asymmetric encryption for small data (like keys).
using System;
using System.Security.Cryptography;
using System.Text;

class RsaEncrypt
{
    static void Main(string[] args)
    {
        using var rsa = RSA.Create(2048);
        string publicKeyXml  = rsa.ToXmlString(false); // public key
        string privateKeyXml = rsa.ToXmlString(true);  // private + public

        string message = "Secret symmetric key: ABCDEF123456";
        Console.WriteLine($"Original: {message}");

        // Encrypt with public key
        using var encryptor = RSA.Create();
        encryptor.FromXmlString(publicKeyXml);
        byte[] encrypted = encryptor.Encrypt(
            Encoding.UTF8.GetBytes(message), RSAEncryptionPadding.OaepSHA256);
        Console.WriteLine($"Encrypted ({encrypted.Length} bytes): {Convert.ToBase64String(encrypted)[..40]}...");

        // Decrypt with private key
        using var decryptor = RSA.Create();
        decryptor.FromXmlString(privateKeyXml);
        byte[] decrypted = decryptor.Decrypt(encrypted, RSAEncryptionPadding.OaepSHA256);
        Console.WriteLine($"Decrypted: {Encoding.UTF8.GetString(decrypted)}");
    }
}
