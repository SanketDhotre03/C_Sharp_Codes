using System;

class Program4
{
    static void Main()
    {
        int a = 10, b = 25;
        Console.WriteLine($"Before swap: a={a}, b={b}");
        int temp = a;
        a = b;
        b = temp;
        Console.WriteLine($"After swap: a={a}, b={b}");
    }
}
