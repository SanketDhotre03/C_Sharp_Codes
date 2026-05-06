using System;
using System.Collections.Generic;

class Program38
{
    static void Main()
    {
        Dictionary<string, string> phoneBook = new Dictionary<string, string>
        {
            ["Alice"] = "9999999999",
            ["Bob"] = "8888888888"
        };

        Console.WriteLine(phoneBook["Alice"]);
    }
}
