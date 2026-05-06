using System;

class Program14
{
    static void Main()
    {
        string text = "CSharp Programming";
        int count = 0;
        foreach (char c in text.ToLower())
        {
            if ("aeiou".Contains(c)) count++;
        }
        Console.WriteLine($"Vowel count: {count}");
    }
}
