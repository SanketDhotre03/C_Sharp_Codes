// Program: AesEncrypt
// Difficulty: High
// Description: Encrypts data using AES symmetric encryption.
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class AesEncrypt
{
    static (byte[] ciphertext, byte[] key, byte[] iv) Encrypt(string plaintext)
    {
        using var aes = Aes.Create();
        aes.KeySize = 256;
        aes.GenerateKey();
        aes.GenerateIV();

        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
        byte[] data = Encoding.UTF8.GetBytes(plaintext);
        cs.Write(data, 0, data.Length);
        cs.FlushFinalBlock();
        return (ms.ToArray(), aes.Key, aes.IV);
    }

    static string Decrypt(byte[] ciphertext, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key; aes.IV = iv;
        using var ms = new MemoryStream(ciphertext);
        using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using var reader = new StreamReader(cs, Encoding.UTF8);
        return reader.ReadToEnd();
    }

    static void Main(string[] args)
    {
        string original = "Secret message: Hello, AES!";
        var (cipher, key, iv) = Encrypt(original);
        Console.WriteLine($"Original:  {original}");
        Console.WriteLine($"Encrypted: {Convert.ToBase64String(cipher)}");
        string decrypted = Decrypt(cipher, key, iv);
        Console.WriteLine($"Decrypted: {decrypted}");
        Console.WriteLine($"Match: {original == decrypted}");
    }
}
