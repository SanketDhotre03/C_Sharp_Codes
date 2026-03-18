using System;

class Program16
{
    static void Main()
    {
        int[] numbers = { 8, 2, 19, 4, 11 };
        int min = numbers[0], max = numbers[0];
        foreach (int n in numbers)
        {
            if (n < min) min = n;
            if (n > max) max = n;
        }
        Console.WriteLine($"Min: {min}, Max: {max}");
    }
}
