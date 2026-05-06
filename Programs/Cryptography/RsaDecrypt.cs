// Program: RsaDecrypt
// Difficulty: High
// Description: RSA key generation, export, import, and decryption.
using System;
using System.Security.Cryptography;
using System.Text;

class RsaDecrypt
{
    static void Main(string[] args)
    {
        // Generate key pair
        using var rsa = RSA.Create(2048);
        var publicParams  = rsa.ExportParameters(false);
        var privateParams = rsa.ExportParameters(true);

        string message = "Hello RSA!";
        byte[] msgBytes = Encoding.UTF8.GetBytes(message);

        // Encrypt using public key
        using var pub = RSA.Create();
        pub.ImportParameters(publicParams);
        byte[] cipher = pub.Encrypt(msgBytes, RSAEncryptionPadding.Pkcs1);

        // Decrypt using private key
        using var priv = RSA.Create();
        priv.ImportParameters(privateParams);
        byte[] plain = priv.Decrypt(cipher, RSAEncryptionPadding.Pkcs1);

        Console.WriteLine($"Message:   {message}");
        Console.WriteLine($"Encrypted: {Convert.ToBase64String(cipher)[..50]}...");
        Console.WriteLine($"Decrypted: {Encoding.UTF8.GetString(plain)}");

        // Try wrong key (should fail)
        using var wrongKey = RSA.Create(2048);
        try { wrongKey.Decrypt(cipher, RSAEncryptionPadding.Pkcs1); Console.WriteLine("Wrong key worked?"); }
        catch (CryptographicException) { Console.WriteLine("Wrong key correctly rejected."); }
    }
}
