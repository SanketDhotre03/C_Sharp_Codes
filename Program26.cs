using System;

class Program26
{
    static void Main()
    {
        double principal = 10000, rate = 10, years = 2;
        double amount = principal * Math.Pow(1 + (rate / 100), years);
        Console.WriteLine($"Compound Amount: {amount:F2}");
    }
}
