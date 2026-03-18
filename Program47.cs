using System;

class Program47
{
    static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    static void Main()
    {
        int x = 1, y = 2;
        Swap(ref x, ref y);
        Console.WriteLine($"x={x}, y={y}");
    }
}
