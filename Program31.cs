using System;

class Program31
{
    static void Main()
    {
        int a = 24, b = 36;
        int x = a, y = b;
        while (y != 0)
        {
            int temp = y;
            y = x % y;
            x = temp;
        }
        int gcd = x;
        int lcm = (a * b) / gcd;
        Console.WriteLine($"GCD: {gcd}, LCM: {lcm}");
    }
}
