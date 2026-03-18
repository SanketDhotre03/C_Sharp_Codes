using System;
using System.Collections.Generic;

class Program37
{
    static void Main()
    {
        List<int> numbers = new List<int> { 10, 20, 30 };
        numbers.Add(40);
        numbers.Remove(20);
        Console.WriteLine(string.Join(", ", numbers));
    }
}
