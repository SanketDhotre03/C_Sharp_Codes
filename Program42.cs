using System;
using System.Linq;

class Program42
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6 };
        var evenSquares = numbers.Where(n => n % 2 == 0).Select(n => n * n);
        Console.WriteLine(string.Join(", ", evenSquares));
    }
}
