// Program: BinaryDeserialize
// Difficulty: Medium
// Description: Demonstrates reading back binary-serialized data.
using System;
using System.IO;

class BinaryDeserialize
{
    static void Main(string[] args)
    {
        // Write records to a MemoryStream (simulating a binary file)
        string[] names = { "Alice", "Bob", "Carol" };
        double[] scores = { 95.5, 87.3, 92.1 };
        int count = names.Length;

        using var ms = new MemoryStream();
        using (var bw = new BinaryWriter(ms, System.Text.Encoding.UTF8, leaveOpen: true))
        {
            bw.Write(count);
            for (int i = 0; i < count; i++)
            {
                bw.Write(i + 1);
                bw.Write(names[i]);
                bw.Write(scores[i]);
            }
        }

        // Read back the records
        ms.Position = 0;
        using var br = new BinaryReader(ms);
        int n = br.ReadInt32();
        Console.WriteLine($"Reading {n} records:");
        for (int i = 0; i < n; i++)
        {
            int id     = br.ReadInt32();
            string name = br.ReadString();
            double score = br.ReadDouble();
            Console.WriteLine($"  [{id}] {name}: {score:F1}");
        }
    }
}
