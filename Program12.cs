using System;

class Program12
{
    static void Main()
    {
        int n = 54321, sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        Console.WriteLine($"Sum of digits: {sum}");
    }
}
