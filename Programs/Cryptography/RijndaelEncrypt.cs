// Program: RijndaelEncrypt
// Difficulty: High
// Description: AES/Rijndael encryption with key derivation from a passphrase.
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class RijndaelEncrypt
{
    static (byte[] cipher, byte[] salt, byte[] iv) EncryptWithPassphrase(string plaintext, string passphrase)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        using var key = new Rfc2898DeriveBytes(passphrase, salt, 100000, HashAlgorithmName.SHA256);
        using var aes = Aes.Create();
        aes.Key = key.GetBytes(32); // 256-bit key
        aes.GenerateIV();

        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
        byte[] data = Encoding.UTF8.GetBytes(plaintext);
        cs.Write(data, 0, data.Length);
        cs.FlushFinalBlock();
        return (ms.ToArray(), salt, aes.IV);
    }

    static string DecryptWithPassphrase(byte[] cipher, string passphrase, byte[] salt, byte[] iv)
    {
        using var key = new Rfc2898DeriveBytes(passphrase, salt, 100000, HashAlgorithmName.SHA256);
        using var aes = Aes.Create();
        aes.Key = key.GetBytes(32);
        aes.IV = iv;
        using var ms = new MemoryStream(cipher);
        using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using var reader = new StreamReader(cs);
        return reader.ReadToEnd();
    }

    static void Main(string[] args)
    {
        string secret = "Sensitive data: account number 1234-5678";
        string pass = "my_strong_passphrase_2024!";

        var (cipher, salt, iv) = EncryptWithPassphrase(secret, pass);
        Console.WriteLine($"Encrypted ({cipher.Length} bytes): {Convert.ToBase64String(cipher)[..40]}...");

        string decrypted = DecryptWithPassphrase(cipher, pass, salt, iv);
        Console.WriteLine($"Decrypted: {decrypted}");
        Console.WriteLine($"Match: {secret == decrypted}");

        try
        {
            DecryptWithPassphrase(cipher, "wrong_passphrase", salt, iv);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wrong passphrase rejected: {ex.GetType().Name}");
        }
    }
}
