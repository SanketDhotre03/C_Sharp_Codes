using System;

class Program32
{
    static void Main()
    {
        int number = 25;
        string binary = Convert.ToString(number, 2);
        Console.WriteLine($"Binary of {number} is {binary}");
    }
}
