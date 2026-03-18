using System;

class Program11
{
    static void Main()
    {
        int n = 12345, reverse = 0;
        while (n > 0)
        {
            reverse = reverse * 10 + (n % 10);
            n /= 10;
        }
        Console.WriteLine($"Reversed number: {reverse}");
    }
}
