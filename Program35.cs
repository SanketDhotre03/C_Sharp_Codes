using System;
using System.IO;

class Program35
{
    static void Main()
    {
        string path = "sample.txt";
        File.WriteAllText(path, "Learning C# file handling");
        string content = File.ReadAllText(path);
        Console.WriteLine(content);
    }
}
