// Program: RandomBytesGenerator
// Difficulty: Medium
// Description: Generates cryptographically secure random values.
using System;
using System.Security.Cryptography;
using System.Text;

class RandomBytesGenerator
{
    static string GenerateToken(int length)
    {
        byte[] bytes = RandomNumberGenerator.GetBytes(length);
        return Convert.ToBase64String(bytes);
    }

    static string GenerateHex(int byteCount)
    {
        byte[] bytes = RandomNumberGenerator.GetBytes(byteCount);
        return Convert.ToHexString(bytes);
    }

    static int GenerateInt(int min, int max)
    {
        uint range = (uint)(max - min);
        uint rand;
        uint limit = uint.MaxValue - (uint.MaxValue % range);
        do { rand = BitConverter.ToUInt32(RandomNumberGenerator.GetBytes(4)); }
        while (rand >= limit);
        return (int)(rand % range) + min;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Random tokens:");
        for (int i = 0; i < 3; i++)
            Console.WriteLine("  " + GenerateToken(24));

        Console.WriteLine("Random hex (16 bytes):");
        Console.WriteLine("  " + GenerateHex(16));

        Console.WriteLine("Random ints (1-100):");
        for (int i = 0; i < 5; i++) Console.Write(GenerateInt(1, 101) + " ");
        Console.WriteLine();
    }
}
