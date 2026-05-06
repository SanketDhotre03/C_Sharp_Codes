// Program: AesDecrypt
// Difficulty: High
// Description: Decrypts AES-encrypted data from a base64 string.
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class AesDecrypt
{
    static byte[] EncryptToBytes(string plaintext, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key; aes.IV = iv;
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
        byte[] data = Encoding.UTF8.GetBytes(plaintext);
        cs.Write(data, 0, data.Length);
        cs.FlushFinalBlock();
        return ms.ToArray();
    }

    static string DecryptFromBytes(byte[] ciphertext, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key; aes.IV = iv;
        using var ms = new MemoryStream(ciphertext);
        using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using var reader = new StreamReader(cs);
        return reader.ReadToEnd();
    }

    static void Main(string[] args)
    {
        // Generate key and IV
        using var aes = Aes.Create();
        aes.KeySize = 128;
        aes.GenerateKey(); aes.GenerateIV();

        string secret = "Confidential Data: Account Balance $50,000";
        byte[] encrypted = EncryptToBytes(secret, aes.Key, aes.IV);
        string b64 = Convert.ToBase64String(encrypted);

        Console.WriteLine($"Plaintext:  {secret}");
        Console.WriteLine($"Ciphertext: {b64}");

        // Decrypt from base64
        byte[] data = Convert.FromBase64String(b64);
        string result = DecryptFromBytes(data, aes.Key, aes.IV);
        Console.WriteLine($"Decrypted:  {result}");
    }
}
