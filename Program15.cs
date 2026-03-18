using System;

class Program15
{
    static void Main()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };
        int sum = 0;
        foreach (int n in numbers) sum += n;
        double average = (double)sum / numbers.Length;
        Console.WriteLine($"Sum: {sum}, Average: {average}");
    }
}
