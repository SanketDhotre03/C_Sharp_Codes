using System;

class Program5
{
    static void Main()
    {
        int x = 15, y = 28, z = 9;
        int largest = Math.Max(x, Math.Max(y, z));
        Console.WriteLine($"Largest number is: {largest}");
    }
}
