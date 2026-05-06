using System;

class Program22
{
    static void Main()
    {
        string sentence = "C sharp code examples are useful";
        int words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        Console.WriteLine($"Word count: {words}");
    }
}
