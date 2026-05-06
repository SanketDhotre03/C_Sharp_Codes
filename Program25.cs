using System;

class Program25
{
    static void Main()
    {
        double principal = 10000, rate = 8, time = 2;
        double si = (principal * rate * time) / 100;
        Console.WriteLine($"Simple Interest: {si}");
    }
}
