using System;

class Program21
{
    static void Main()
    {
        string sentence = "learn c sharp today";
        string[] words = sentence.Split(' ');
        Array.Reverse(words);
        Console.WriteLine(string.Join(" ", words));
    }
}
